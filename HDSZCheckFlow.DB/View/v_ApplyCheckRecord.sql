CREATE VIEW
 v_ApplyCheckRecord AS SELECT TOP 100 PERCENT p.CheckComment,
 CASE p.ispass WHEN 0 THEN '拒绝' WHEN 1 THEN '同意' ELSE '未审批' END AS ispass,
 p.ApplySheetNo, p.ApplyDate, a.ApplySheetHead_Pk, p.personCode, A.NAME AS CheckName,
p.IsDisplays, p.DisplaysPersonCode, p.displayName,p.Checkdate, isnull(p.FullCheckName,A.NAME ) AS FullCheckName,
isnull(p.CheckRole,a.CheckRoleCode) AS CheckRole, a.CheckRoleName FROM ( SELECT CheckRole.CheckRoleCode,
CheckRole.CheckRoleName, Base_Person.Name, '0' AS IsCheckInCompany, CheckFlowInDept.CheckSetp,ApplySheetHead.ApplySheetHead_Pk
 FROM CheckFlowInDept INNER JOIN CheckRole ON CheckFlowInDept.CheckRoleCode = CheckRole.CheckRoleCode INNER 
JOIN Base_Person ON CheckFlowInDept.CheckPersonCode = Base_Person.personCode INNER JOIN ApplySheetHead 
ON CheckFlowInDept.DeptCode = ApplySheetHead.ApplyDeptCode UNION ALL SELECT CheckRole.CheckRolecode,CheckRole.CheckRoleName,
 Base_Person.Name, '1' AS IsCheckInCompany, CheckFlowInCompany_Body.CheckStep,ApplySheetHead.ApplySheetHead_Pk FROM Base_Person
 INNER JOIN CheckPersonInRole ON Base_Person.personCode = CheckPersonInRole.PersonCode INNER JOIN CheckRole 
ON CheckPersonInRole.CheckRoleCode = CheckRole.CheckRoleCode INNER JOIN CheckFlowInCompany_Body 
ON CheckPersonInRole.CheckRoleCode = CheckFlowInCompany_Body.CheckRoleCode INNER JOIN ApplySheetHead
 ON CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = ApplySheetHead.CheckFlowInCompany_Head_pk 
 INNER JOIN ApplyProcessType ON
 ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode ) a LEFT JOIN 
(SELECT applySheetCheckRecord.CheckComment, applySheetCheckRecord.IsPass,
 ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, ApplySheetHead.ApplySheetHead_Pk, 
Base_Person_Check.personCode, Base_Person_Check.Name AS CheckName, applySheetCheckRecord.IsDisplays, 
applySheetCheckRecord.DisplaysPersonCode, Base_Person_Displays.Name AS displayName, applySheetCheckRecord.Checkdate,
 CASE isdisplays WHEN 1 THEN rtrim(Base_Person_Check.Name) + ' 代 ' + Base_Person_Displays.Name ELSE rtrim(Base_Person_Check.Name) 
END AS FullCheckName, applySheetCheckRecord.CheckRole, CheckRole.CheckRoleName FROM Base_Person Base_Person_Check RIGHT
 OUTER JOIN CheckRole INNER JOIN applySheetCheckRecord ON CheckRole.CheckRoleCode = applySheetCheckRecord.CheckRole 
ON Base_Person_Check.personCode = applySheetCheckRecord.CheckPersonCode LEFT OUTER JOIN Base_Person Base_Person_Displays 
ON applySheetCheckRecord.DisplaysPersonCode = Base_Person_Displays.personCode LEFT OUTER JOIN ApplySheetHead 
ON applySheetCheckRecord.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk ) p ON a.ApplySheetHead_Pk=p.ApplySheetHead_Pk 
AND a.CheckRoleCode=p.CheckRole ORDER BY a.applysheethead_pk ,a.ischeckincompany ,a.checksetp 

