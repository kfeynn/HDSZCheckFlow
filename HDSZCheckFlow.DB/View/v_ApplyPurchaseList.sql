CREATE VIEW dbo.v_ApplyPurchaseList 
AS SELECT TOP 100
 PERCENT dbo.ApplySheetHead.ApplySheetNo, dbo.ApplySheetHead.ApplyTypeCode,
 dbo.ApplySheetHead.ApplyProcessCode,dbo.ApplySheetHead.ApplyDate, 
dbo.ApplySheetBody_Purchase.InventoryCode, dbo.ApplySheetBody_Purchase.Number, 
dbo.ApplySheetBody_Purchase.RMBPrice, dbo.ApplySheetBody_Purchase.Money,
 dbo.Base_inventory.invName, dbo.ApplyType.ApplyTypeName, dbo.ApplySheetBody_Purchase.IsOrder, 
dbo.ApplySheetBody_Purchase.orderDate, dbo.ApplySheetBody_Purchase.OrderNo, 
dbo.ApplySheetBody_Purchase.ApplySheetHead_Pk, 
dbo.ApplySheetBody_Purchase.ApplySheetBody_Purchase_pk
 FROM dbo.ApplySheetBody_Purchase INNER JOIN dbo.ApplySheetHead 
ON dbo.ApplySheetBody_Purchase.ApplySheetHead_Pk = dbo.ApplySheetHead.ApplySheetHead_Pk
 INNER JOIN dbo.Base_inventory ON
 dbo.ApplySheetBody_Purchase.InventoryCode = dbo.Base_inventory.invCode
 INNER JOIN dbo.ApplyType ON dbo.ApplySheetHead.ApplyTypeCode = dbo.ApplyType.ApplyTypeCode
 ORDER BY dbo.ApplySheetBody_Purchase.ApplySheetHead_Pk DESC 

 