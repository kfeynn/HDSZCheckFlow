CREATE VIEW dbo.v_AllApplyFlowInfo
AS
-- ���е��ݵ�����������Ϣ
-- ������

SELECT Base_Dept.DeptName, Base_Person.Name, ApplySheetHead.ApplyDate, 
      ApplyType.ApplyTypeName, ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN 'Ԥ����' WHEN 2 THEN 'Ԥ����'
       WHEN 3 THEN '�� ��' END AS SubmitType, ApplySheetHead.ApplySheetHead_Pk, 
      ApplySheetHead.ApplySheetNo, ApplyProcessType.ApplyProcessTypeName, 
      ApplySheetHead.ApplyTypeCode, ApplySheetHead.ApplyDeptClassCode, 
      ApplySheetHead.ApplyDeptCode, ApplySheetHead.ApplyProcessCode, 
      CheckFlowInDept.CheckRoleCode, CheckFlowInDept.CheckPersonCode, 
      ApplyProcessType.IsFinishInCompany

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
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode RIGHT
       OUTER JOIN
      CheckFlowInDept ON 
      ApplySheetHead.ApplyDeptCode = CheckFlowInDept.DeptCode
WHERE (ApplySheetHead.IsKeeping = 0) AND (ApplyProcessType.IsSubmit = 1)

union all 
-- ��˾�� 






SELECT Base_Dept.DeptName, Base_Person.Name, ApplySheetHead.ApplyDate, 
      ApplyType.ApplyTypeName, ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN 'Ԥ����' WHEN 2 THEN 'Ԥ����'
       WHEN 3 THEN '�� ��' END AS SubmitType, ApplySheetHead.ApplySheetHead_Pk, 
      ApplySheetHead.ApplySheetNo, ApplyProcessType.ApplyProcessTypeName, 
      ApplySheetHead.ApplyTypeCode, ApplySheetHead.ApplyDeptClassCode, 
      ApplySheetHead.ApplyDeptCode, ApplySheetHead.ApplyProcessCode, 
      CheckPersonInRole.CheckRoleCode, CheckPersonInRole.PersonCode, 
      ApplyProcessType.IsFinishInCompany

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
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode INNER
       JOIN
      CheckFlowInCompany_head ON 
      ApplySheetHead.CheckFlowInCompany_Head_pk = CheckFlowInCompany_head.CheckFlowInCompany_Head_pk
       INNER JOIN
      CheckFlowInCompany_Body ON 
      CheckFlowInCompany_head.CheckFlowInCompany_Head_pk = CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk
       INNER JOIN
      CheckPersonInRole ON 
      CheckFlowInCompany_Body.CheckRoleCode = CheckPersonInRole.CheckRoleCode
WHERE (ApplySheetHead.IsKeeping = 0) AND (ApplyProcessType.IsSubmit = 1)

