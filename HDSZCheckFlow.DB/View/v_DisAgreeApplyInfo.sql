 CREATE VIEW dbo.VIEW1
AS
SELECT TOP 100 PERCENT ISNULL(a.DisplaysPersonCode, a.CheckPersonCode) 
      AS checkPerson, dbo.ApplySheetHead.ApplySheetHead_Pk, 
      a.applySheetCheckRecord_pk, a.IsCheckInCompany, a.CheckRole, 
      a.CheckPersonCode, a.IsPass, a.Checkdate, a.CheckComment, a.IsDisplays, 
      a.DisplaysPersonCode, a.CheckSetp, dbo.ApplySheetHead.ApplySheetNo, 
      dbo.ApplySheetHead.ApplyTypeCode, dbo.ApplySheetHead.ApplyDate, 
      dbo.ApplySheetHead.ApplyDeptClassCode, dbo.ApplySheetHead.ApplyDeptCode, 
      dbo.ApplySheetHead.ApplyPersonCode, dbo.ApplySheetHead.ApplyProcessCode, 
      dbo.ApplySheetHead.CurrentCheckRole, dbo.ApplySheetHead.ApplyPersonName, 
      dbo.ApplySheetHead.ApplyMakerCode, dbo.ApplySheetHead.ApplyMakerName, 
      dbo.ApplySheetHead.CheckFlowInCompany_Head_pk, 
      dbo.ApplySheetHead.IsKeeping, dbo.ApplySheetHead.SubmitDate, 
      dbo.ApplyType.ApplyTypeName, dbo.Base_Dept.DeptName
FROM dbo.applySheetCheckRecord a INNER JOIN
      dbo.ApplySheetHead ON a.Checkdate =
          (SELECT TOP 1 checkdate
         FROM applySheetCheckRecord
         WHERE applysheethead_pk = a.applysheethead_pk
         ORDER BY checkdate DESC) AND 
      dbo.ApplySheetHead.ApplySheetHead_Pk = a.ApplySheetHead_Pk AND 
      a.IsPass = 1 AND dbo.ApplySheetHead.ApplyProcessCode <> 106 INNER JOIN
      dbo.ApplyType ON 
      dbo.ApplySheetHead.ApplyTypeCode = dbo.ApplyType.ApplyTypeCode INNER JOIN
      dbo.Base_Dept ON 
      dbo.ApplySheetHead.ApplyDeptCode = dbo.Base_Dept.DeptCode
ORDER BY a.ApplySheetHead_Pk DESC

