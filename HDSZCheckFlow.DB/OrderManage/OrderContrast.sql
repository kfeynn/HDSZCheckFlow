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
**		Desc: ���ڲ��� Ԥ��ϵͳ�Ķ������� �� ncϵͳ�Ķ������ݣ��������졣
   
              ��������inventoryCode
              ����  �Բߣ�inventoryCode �ϼƳ���Ʒ���ϼ�������ԭ�ҽ������жϱ�׼������ ����/�쳣 �жϱ�ʶ��
              �ж�  ��׼��������ͬ���۸񸡶������ж�
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
* --v_BaseApplyPurchase.inventoryCode,v_NcOrder.���
from 
(select inventoryCode from v_BaseApplyPurchase  where orderno = 'dd2009040600003'
  union  
select ������� from v_NcOrder where ���뵥�� = 'dd2009040600003') a
left join 
 v_BaseApplyPurchase  on a.inventoryCode = v_BaseApplyPurchase.inventoryCode and v_BaseApplyPurchase.orderno = 'dd2009040600003'
left join v_NcOrder on a.inventoryCode = v_NcOrder.������� and v_NcOrder.���뵥�� = 'dd2009040600003'

group by v_BaseApplyPurchase.inventoryCode,v_NcOrder.���





-- 04-22 
/*
	      ���ڲ��� Ԥ��ϵͳ�Ķ������� �� ncϵͳ�Ķ������ݣ��������졣
   
              ��������inventoryCode
              ����  �Բߣ�inventoryCode �ϼƳ���Ʒ���ϼ�������ԭ�ҽ������жϱ�׼������ ����/�쳣 �жϱ�ʶ��
              �ж�  ��׼��������ͬ���۸񸡶������ж�
*/

select --a.inventoryCode as aaa,a.orderno as bbb,
* --v_BaseApplyPurchase.inventoryCode,v_NcOrder.���
from 
(select inventoryCode,orderno from v_BaseApplyPurchase -- where orderno = 'dd2009040600003'
  union  
select �������,���뵥�� from v_NcOrder-- where ���뵥�� = 'dd2009040600003'
--order by orderno desc 
) a
left join 
 v_BaseApplyPurchase  on a.inventoryCode = v_BaseApplyPurchase.inventoryCode and v_BaseApplyPurchase.orderno = a.orderno
left join v_NcOrder on a.inventoryCode = v_NcOrder.�������  and v_NcOrder.���뵥�� = a.orderno

where v_NcOrder.���뵥��  = 'dd2009040600003'  or v_BaseApplyPurchase.orderno = 'dd2009040600003'
order by a.orderno desc 


--group by v_BaseApplyPurchase.inventoryCode,v_NcOrder.���



select 
* --v_BaseApplyPurchase.inventoryCode,v_NcOrder.���
from 
(select inventoryCode from v_BaseApplyPurchase  where orderno = 'dd2009040600003'
  union  
select ������� from v_NcOrder where ���뵥�� = 'dd2009040600003') a
left join 
 v_BaseApplyPurchase  on a.inventoryCode = v_BaseApplyPurchase.inventoryCode and v_BaseApplyPurchase.orderno = 'dd2009040600003'
left join v_NcOrder on a.inventoryCode = v_NcOrder.������� and v_NcOrder.���뵥�� = 'dd2009040600003'



GO

GRANT EXEC ON OrderContrast TO PUBLIC

GO
