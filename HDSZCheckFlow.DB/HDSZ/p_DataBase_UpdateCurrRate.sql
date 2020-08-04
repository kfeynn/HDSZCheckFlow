IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_DataBase_UpdateCurrRate')
	BEGIN
		PRINT 'Dropping Procedure p_DataBase_UpdateCurrRate'
		DROP  Procedure  p_DataBase_UpdateCurrRate
	END

GO

PRINT 'Creating Procedure p_DataBase_UpdateCurrRate'
GO  

CREATE    procedure  p_DataBase_UpdateCurrRate 

@IYear int,
@IMonth int

 as

declare @count int 

-- ���»��һ���

-- 1.ִ��publicData �е� �洢���� ͬ�� nc������ 
-- 2.���ݲ����������Ƿ�������
-- 3.�����ݣ�ɾ�����б��е����ݣ������ѯ����������
-- 4.û�����ݣ� �����κβ���
exec hdszpublicdata.dbo.PImportCurrRate

select @count=count(*) from  hdszpublicdata.dbo.BaseMyCurrency where IYear = @IYear and IMonth=@IMonth

if @count > 0  
	begin 
		update Base_currencyType  set ExchangeRate = 
			(select ExchangeRate from hdszpublicdata.dbo.BaseMyCurrency b 
			where b.currTypeCode = Base_currencyType.currTypeCode and IYear= @IYear and IMonth= @IMonth)
	end 



GO
