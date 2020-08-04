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

-- 更新货币汇率

-- 1.执行publicData 中的 存储过程 同步 nc中数据 
-- 2.根据参数，查找是否有数据
-- 3.有数据，删除现有表中的数据，插入查询得来的数据
-- 4.没有数据， 不做任何操作
exec hdszpublicdata.dbo.PImportCurrRate

select @count=count(*) from  hdszpublicdata.dbo.BaseMyCurrency where IYear = @IYear and IMonth=@IMonth

if @count > 0  
	begin 
		update Base_currencyType  set ExchangeRate = 
			(select ExchangeRate from hdszpublicdata.dbo.BaseMyCurrency b 
			where b.currTypeCode = Base_currencyType.currTypeCode and IYear= @IYear and IMonth= @IMonth)
	end 



GO
