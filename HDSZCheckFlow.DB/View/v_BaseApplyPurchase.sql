alter  VIEW dbo.v_BaseApplyPurchase                    --单据的基本详细信息
AS

SELECT ApplySheetHead.ApplySheetNo, ApplySheetBody_Purchase.InventoryCode, 
      Base_inventory.invName, Base_Person.Name, Base_Dept.DeptName, 
      ApplySheetHead.ApplyDate, Base_inventory.MEASNAME, isnull(Base_inventory.INVTYPE,Base_inventory.Invspec)  as INVTYPE, 
      ApplySheetHead.ApplySheetHead_Pk, ApplySheetBody_Purchase.Number, 
      ApplySheetBody_Purchase.Money, ApplySheetBody_Purchase.RMBPrice, 
      Base_AccountSubject.subjectCode, Base_AccountSubject.Dispname, 
      ApplySheetHead.DeliveryDate,ApplySheetBody_Purchase.Memo
FROM ApplySheetHead_Budget INNER JOIN
      ApplySheetHead INNER JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode ON 
      ApplySheetHead_Budget.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk INNER
       JOIN
      Base_AccountSubject ON 
      ApplySheetHead_Budget.SheetSubject = Base_AccountSubject.subjectCode LEFT OUTER
       JOIN
      Base_inventory INNER JOIN
      ApplySheetBody_Purchase ON 
      Base_inventory.invCode = ApplySheetBody_Purchase.InventoryCode ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetBody_Purchase.ApplySheetHead_Pk








