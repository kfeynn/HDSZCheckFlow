IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'OrderContrast')
	BEGIN
		PRINT 'Dropping Procedure OrderContrast'
		DROP  Procedure  OrderContrast
	END

GO

PRINT 'Creating Procedure OrderContrast'
GO
CREATE Procedure OrderContrast
	/* Param List */
AS

/******************************************************************************
**		File: 
**		Name: OrderContrast
**		Desc: 用于查找 预算系统的定单数据 和 nc系统的定单数据，分析差异。
   
              两表关联项：inventoryCode
              分析  对策：inventoryCode 合计出物品，合计数量，原币金额，参照判断标准表。给出 正常/异常 判断标识。
              判断  标准：数量相同，价格浮动区间判断
**
**		
**              
**		
** 
**
**		Auth: zyq
**		Date: 2009-04-21
*******************************************************************************/



select 
* --v_BaseApplyPurchase.inventoryCode,v_NcOrder.序号
from 
(select inventoryCode from v_BaseApplyPurchase  where orderno = 'dd2009040600003'
  union  
select 存货编码 from v_NcOrder where 申请单号 = 'dd2009040600003') a
left join 
 v_BaseApplyPurchase  on a.inventoryCode = v_BaseApplyPurchase.inventoryCode and v_BaseApplyPurchase.orderno = 'dd2009040600003'
left join v_NcOrder on a.inventoryCode = v_NcOrder.存货编码 and v_NcOrder.申请单号 = 'dd2009040600003'

group by v_BaseApplyPurchase.inventoryCode,v_NcOrder.序号





-- 04-22 
/*
	      用于查找 预算系统的定单数据 和 nc系统的定单数据，分析差异。
   
              两表关联项：inventoryCode
              分析  对策：inventoryCode 合计出物品，合计数量，原币金额，参照判断标准表。给出 正常/异常 判断标识。
              判断  标准：数量相同，价格浮动区间判断
*/

select --a.inventoryCode as aaa,a.orderno as bbb,
* --v_BaseApplyPurchase.inventoryCode,v_NcOrder.序号
from 
(select inventoryCode,orderno from v_BaseApplyPurchase -- where orderno = 'dd2009040600003'
  union  
select 存货编码,申请单号 from v_NcOrder-- where 申请单号 = 'dd2009040600003'
--order by orderno desc 
) a
left join 
 v_BaseApplyPurchase  on a.inventoryCode = v_BaseApplyPurchase.inventoryCode and v_BaseApplyPurchase.orderno = a.orderno
left join v_NcOrder on a.inventoryCode = v_NcOrder.存货编码  and v_NcOrder.申请单号 = a.orderno

where v_NcOrder.申请单号  = 'dd2009040600003'  or v_BaseApplyPurchase.orderno = 'dd2009040600003'
order by a.orderno desc 


--group by v_BaseApplyPurchase.inventoryCode,v_NcOrder.序号



select 
* --v_BaseApplyPurchase.inventoryCode,v_NcOrder.序号
from 
(select inventoryCode from v_BaseApplyPurchase  where orderno = 'dd2009040600003'
  union  
select 存货编码 from v_NcOrder where 申请单号 = 'dd2009040600003') a
left join 
 v_BaseApplyPurchase  on a.inventoryCode = v_BaseApplyPurchase.inventoryCode and v_BaseApplyPurchase.orderno = 'dd2009040600003'
left join v_NcOrder on a.inventoryCode = v_NcOrder.存货编码 and v_NcOrder.申请单号 = 'dd2009040600003'



GO

GRANT EXEC ON OrderContrast TO PUBLIC

GO
