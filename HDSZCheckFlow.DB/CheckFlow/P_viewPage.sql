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
        no_mIss 分页存储过程 2007.2.20 
        适用于单一主键或存在唯一值列的表或视图          
    */

    @TableName VARCHAR(200),     --表名
    @FieldList VARCHAR(2000),    --显示列名
    @PrimaryKey VARCHAR(100),    --单一主键或唯一值键
    @Where VARCHAR(1000),        --查询条件 不含'where'字符
    @Order VARCHAR(1000),        --排序 不含'order by'字符，如id asc,userid desc，当@SortType=3时生效
    @SortType INT,               --排序规则 1:正序asc 2:倒序desc 3:多列排序
    @RecorderCount INT,          --记录总数 0:会返回总记录
    @PageSize INT,               --每页输出的记录数
    @PageIndex INT,              --当前页数
    @TotalCount INT OUTPUT,      --返回记录总数
    @TotalPageCount INT OUTPUT   --返回总页数
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
