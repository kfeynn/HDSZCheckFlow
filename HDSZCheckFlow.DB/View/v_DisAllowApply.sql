CREATE VIEW dbo.v_DisAllowApply                 --所有被驳回的单据
AS
SELECT ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
      ApplyType.ApplyTypeName, Base_Dept.DeptName, 
      ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外'
       WHEN 3 THEN '紧急' END AS SubmitType, Base_Person.Name, 
      ApplyProcessType.ApplyProcessTypeCode, ApplySheetHead.ApplyDeptClassCode, 
      ApplySheetHead.ApplyDeptCode, ApplyType.ApplyTypeCode, 
      ApplySheetHead.IsCheckInCompany, ApplySheetHead.ApplySheetHead_Pk, 
      CheckFlowInDept.CheckPersonCode
FROM ApplyType INNER JOIN
      ApplySheetHead ON 
      ApplyType.ApplyTypeCode = ApplySheetHead.ApplyTypeCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
      ApplySheetHead_Budget ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetHead_Budget.ApplySheetHead_Pk INNER
       JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      ApplyProcessType ON 
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode INNER
       JOIN
      CheckFlowInDept ON 
      ApplySheetHead.CurrentCheckRole = CheckFlowInDept.CheckRoleCode AND 
      ApplySheetHead.ApplyDeptCode = CheckFlowInDept.DeptCode AND 
      ApplySheetHead.CheckSetp = CheckFlowInDept.CheckSetp
WHERE (ApplyProcessType.IsDisallow = 1) AND (ApplySheetHead.IsCheckInCompany = 0)            --部门内 

union all 

SELECT ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
      ApplyType.ApplyTypeName, Base_Dept.DeptName, 
      ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外'
       WHEN 3 THEN '紧急' END AS SubmitType, Base_Person.Name, 
      ApplyProcessType.ApplyProcessTypeCode, ApplySheetHead.ApplyDeptClassCode, 
      ApplySheetHead.ApplyDeptCode, ApplyType.ApplyTypeCode, 
      ApplySheetHead.IsCheckInCompany, ApplySheetHead.ApplySheetHead_Pk, 
      CheckPersonInRole.PersonCode
FROM ApplyType INNER JOIN
      ApplySheetHead ON 
      ApplyType.ApplyTypeCode = ApplySheetHead.ApplyTypeCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
      ApplySheetHead_Budget ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetHead_Budget.ApplySheetHead_Pk INNER
       JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      ApplyProcessType ON 
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode INNER
       JOIN
      CheckPersonInRole ON 
      ApplySheetHead.CurrentCheckRole = CheckPersonInRole.CheckRoleCode
WHERE (ApplyProcessType.IsDisallow = 1) AND (ApplySheetHead.IsCheckInCompany = 1)              --公司内
