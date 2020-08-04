CREATE VIEW dbo.v_BaseApplyPay
AS
SELECT ApplySheetHead.ApplySheetNo, Base_Person.Name, Base_Dept.DeptName, 
      ApplySheetHead.ApplyDate, ApplySheetHead.ApplySheetHead_Pk, 
      ApplySheetBody_Pay.Item, ApplySheetBody_Pay.Money, 
      ApplySheetHead.DeliveryDate
FROM ApplySheetHead INNER JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
      ApplySheetBody_Pay ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetBody_Pay.ApplySheetHead_Pk




