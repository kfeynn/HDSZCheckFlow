-- 预算/Nc 定单对照表

alter VIEW dbo.v_BudNcOrderInfo
AS
SELECT a.inventoryCode as AinventoryCode,a.orderno as AOrderNo, B_Order.*, v_NOrder.*,OrderDifference.id,OrderDifference.orderno as Dorderno,OrderDifference.InventoryCode as DInventoryCode,
OrderDifference.IsDone,OrderDifference.ReMark
FROM (SELECT inventoryCode, orderno 
        FROM v_BaseApplyPurchase
        UNION
        SELECT 存货编码, 申请单号
        FROM v_NcOrder) a LEFT OUTER JOIN
          (SELECT orderno as orderno, inventorycode, invName, Invtype, SUM(Number) AS number, 
               SUM(money) AS money
         FROM v_BaseApplyPurchase
         GROUP BY orderno, inventorycode, invName, Invtype) B_Order ON 
      a.inventoryCode = B_Order.inventorycode AND 
      B_Order.orderno = a.orderno LEFT OUTER JOIN
          (SELECT 申请单号, 存货编码, 存货名称, SUM(订单数量) AS 订单数量, 
               SUM(订单本币金额) AS 订单本币金额
         FROM v_NcOrder
         GROUP BY 申请单号, 存货编码, 存货名称) v_NOrder ON 
      a.inventoryCode = v_NOrder.存货编码 AND 
      v_NOrder.申请单号 = a.orderno LEFT OUTER JOIN
      dbo.OrderDifference ON a.inventoryCode = dbo.OrderDifference.InventoryCode AND 
      dbo.OrderDifference.OrderNo = a.orderno





 