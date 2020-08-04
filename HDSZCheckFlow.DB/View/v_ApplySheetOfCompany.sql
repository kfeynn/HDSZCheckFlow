CREATE VIEW dbo.v_ApplySheetOfCompany    --公司单据状态
AS
SELECT Base_Dept.DeptName, Base_Person.Name, ApplySheetHead.ApplyDate, 
      ApplyType.ApplyTypeName, ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外'
       WHEN 3 THEN '紧 急' END AS SubmitType, ApplySheetHead.ApplySheetHead_Pk, 
      ApplySheetHead.ApplySheetNo, ApplyProcessType.ApplyProcessTypeName, 
      ApplySheetHead.ApplyTypeCode, ApplySheetHead.ApplyDeptClassCode, 
      ApplySheetHead.ApplyDeptCode, ApplySheetHead.ApplyProcessCode, 
      ApplySheetHead.IsKeeping, ApplyProcessType.IsFinishInCompany, 
      ApplySheetHead.IsOverBudget, ApplySheetHead_Budget.SheetSubject,
      ApplySheetHead.isexpense,ApplySheetHead.ExpenseDate,case  ApplySheetHead.isexpense when 1 then '是' else  '否' end as Cisexpense
FROM ApplySheetHead INNER JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
      ApplyType ON 
      ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetHead_Budget.ApplySheetHead_Pk INNER
       JOIN
      ApplyProcessType ON 
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode




