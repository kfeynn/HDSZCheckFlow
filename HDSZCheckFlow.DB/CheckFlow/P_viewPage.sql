 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'P_viewPage')
	BEGIN
		PRINT 'Dropping Procedure P_viewPage'
		DROP  Procedure  P_viewPage
	END

GO

PRINT 'Creating Procedure P_viewPage'
GO
 
 CREATE PROC P_viewPage
    /*
        no_mIss ��ҳ�洢���� 2007.2.20 
        �����ڵ�һ���������Ψһֵ�еı����ͼ          
    */

    @TableName VARCHAR(200),     --����
    @FieldList VARCHAR(2000),    --��ʾ����
    @PrimaryKey VARCHAR(100),    --��һ������Ψһֵ��
    @Where VARCHAR(1000),        --��ѯ���� ����'where'�ַ�
    @Order VARCHAR(1000),        --���� ����'order by'�ַ�����id asc,userid desc����@SortType=3ʱ��Ч
    @SortType INT,               --������� 1:����asc 2:����desc 3:��������
    @RecorderCount INT,          --��¼���� 0:�᷵���ܼ�¼
    @PageSize INT,               --ÿҳ����ļ�¼��
    @PageIndex INT,              --��ǰҳ��
    @TotalCount INT OUTPUT,      --���ؼ�¼����
    @TotalPageCount INT OUTPUT   --������ҳ��
AS
    SET NOCOUNT ON
    IF ISNULL(@TableName,'') = '' OR ISNULL(@FieldList,'') = '' 
        OR ISNULL(@PrimaryKey,'') = ''
        OR @SortType < 1 OR @SortType >3
        OR @RecorderCount < 0 OR @PageSize < 0 OR @PageIndex < 0
    BEGIN        
        RETURN
    END
 
    DECLARE @new_where1 VARCHAR(1000)
    DECLARE @new_where2 VARCHAR(1000)
    DECLARE @new_order VARCHAR(1000)   
    DECLARE @Sql VARCHAR(8000)
    DECLARE @SqlCount NVARCHAR(4000)

    IF ISNULL(@where,'') = ''
        BEGIN
            SET @new_where1 = ' '
            SET @new_where2 = ' WHERE  '
        END
    ELSE
        BEGIN
            SET @new_where1 = ' WHERE ' + @where 
            SET @new_where2 = ' WHERE ' + @where + ' AND '
        END

    IF ISNULL(@order,'') = '' OR @SortType = 1  OR @SortType = 2 
        BEGIN
            IF @SortType = 1 SET @new_order = ' ORDER BY ' + @PrimaryKey + ' ASC'
            IF @SortType = 2 SET @new_order = ' ORDER BY ' + @PrimaryKey + ' DESC'
        END
    ELSE
        BEGIN
            SET @new_order = ' ORDER BY ' + @Order
        END

    SET @SqlCount = 'SELECT @TotalCount=COUNT(*),@TotalPageCount=CEILING((COUNT(*)+0.0)/'
                    + CAST(@PageSize AS VARCHAR)+') FROM ' + @TableName + @new_where1
    
    IF @RecorderCount = 0
        BEGIN
             EXEC SP_EXECUTESQL @SqlCount,N'@TotalCount INT OUTPUT,@TotalPageCount INT OUTPUT',
                               @TotalCount OUTPUT,@TotalPageCount OUTPUT
        END
    ELSE
        BEGIN
             SELECT @TotalCount = @RecorderCount            
        END

    IF @PageIndex > CEILING((@TotalCount+0.0)/@PageSize)
        BEGIN
            SET @PageIndex =  CEILING((@TotalCount+0.0)/@PageSize)
        END
    IF @PageIndex = 0
		BEGIN
			set @PageIndex = 1
		END
    IF @PageIndex = 1
        BEGIN
            SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ' 
                       + @TableName + @new_where1 + @new_order
        END
    ELSE
        BEGIN
            IF @SortType = 1
                BEGIN
                    SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ' 
                               + @TableName + @new_where2 + @PrimaryKey + ' > '
                               + '(SELECT MAX(' + @PrimaryKey + ') FROM (SELECT TOP '
                               + STR(@PageSize*(@PageIndex-1)) + ' ' + @PrimaryKey 
                               + ' FROM ' + @TableName
                               + @new_where1 + @new_order +' ) AS TMP) '+ @new_order
                END
            IF @SortType = 2
                BEGIN
                    SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ' 
                               + @TableName + @new_where2 + @PrimaryKey + ' < '
                               + '(SELECT MIN(' + @PrimaryKey + ') FROM (SELECT TOP '
                               + STR(@PageSize*(@PageIndex-1)) + ' ' + @PrimaryKey 
                               +' FROM '+ @TableName
                               + @new_where1 + @new_order + ') AS TMP) '+ @new_order                               
                END       
            IF @SortType = 3
                BEGIN
                    IF CHARINDEX(',',@Order) = 0 BEGIN RETURN END
                    SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM '
                               + @TableName + @new_where2 + @PrimaryKey + ' NOT IN (SELECT TOP '
                               + STR(@PageSize*(@PageIndex-1)) + ' ' + @PrimaryKey
                               + ' FROM ' + @TableName + @new_where1 + @new_order + ')'
                               + @new_order
                END
        END
    EXEC(@Sql)
GO
