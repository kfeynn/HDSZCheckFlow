-- Ԥ��/Nc �������ձ�

alter VIEW dbo.v_BudNcOrderInfo
AS
SELECT a.inventoryCode as AinventoryCode,a.orderno as AOrderNo, B_Order.*, v_NOrder.*,OrderDifference.id,OrderDifference.orderno as Dorderno,OrderDifference.InventoryCode as DInventoryCode,
OrderDifference.IsDone,OrderDifference.ReMark
FROM (SELECT inventoryCode, orderno 
        FROM v_BaseApplyPurchase
        UNION
        SELECT �������, ���뵥��
        FROM v_NcOrder) a LEFT OUTER JOIN
          (SELECT orderno as orderno, inventorycode, invName, Invtype, SUM(Number) AS number, 
               SUM(money) AS money
         FROM v_BaseApplyPurchase
         GROUP BY orderno, inventorycode, invName, Invtype) B_Order ON 
      a.inventoryCode = B_Order.inventorycode AND 
      B_Order.orderno = a.orderno LEFT OUTER JOIN
          (SELECT ���뵥��, �������, �������, SUM(��������) AS ��������, 
               SUM(�������ҽ��) AS �������ҽ��
         FROM v_NcOrder
         GROUP BY ���뵥��, �������, �������) v_NOrder ON 
      a.inventoryCode = v_NOrder.������� AND 
      v_NOrder.���뵥�� = a.orderno LEFT OUTER JOIN
      dbo.OrderDifference ON a.inventoryCode = dbo.OrderDifference.InventoryCode AND 
      dbo.OrderDifference.OrderNo = a.orderno





 