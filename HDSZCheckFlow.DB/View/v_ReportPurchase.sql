CREATE VIEW dbo.v_ReportPurchase
AS
SELECT applySheetCheckRecord.CheckComment, applySheetCheckRecord.IsPass, 
      ApplySheetHead.ApplySheetNo, ApplySheetBody_Purchase.InventoryCode, 
      Base_inventory.invName, Base_Person.Name, Base_Dept.DeptName, 
      ApplySheetHead.ApplyDate, Base_inventory.MEASNAME, 
      ApplySheetBody_Purchase.INVTYPE, ApplySheetHead.ApplySheetHead_Pk, 
      Base_Person_Check.personCode, Base_Person_Check.Name AS CheckName
FROM ApplySheetHead INNER JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      Base_Dept ON 
      ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode LEFT OUTER JOIN
      Base_inventory INNER JOIN
      ApplySheetBody_Purchase ON 
      Base_inventory.invCode = ApplySheetBody_Purchase.InventoryClassCode ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetBody_Purchase.ApplySheetHead_Pk
       RIGHT OUTER JOIN
      Base_Person Base_Person_Check INNER JOIN
      applySheetCheckRecord ON 
      Base_Person_Check.personCode = applySheetCheckRecord.CheckPersonCode ON 
      ApplySheetHead.ApplySheetHead_Pk = applySheetCheckRecord.ApplySheetHead_Pk

