CREATE VIEW dbo.v_ApplyCheckRecord
AS
SELECT applySheetCheckRecord.CheckComment, applySheetCheckRecord.IsPass, 
      ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
      ApplySheetHead.ApplySheetHead_Pk, Base_Person_Check.personCode, 
      Base_Person_Check.Name AS CheckName, applySheetCheckRecord.IsDisplays, 
      applySheetCheckRecord.DisplaysPersonCode, 
      Base_Person_Displays.Name AS displayName, applySheetCheckRecord.Checkdate, 
      CASE isdisplays WHEN 1 THEN rtrim(Base_Person_Check.Name) 
      + ' ´ú ' + Base_Person_Displays.Name ELSE rtrim(Base_Person_Check.Name) 
      END AS FullCheckName, applySheetCheckRecord.CheckRole, 
      CheckRole.CheckRoleName
FROM Base_Person Base_Person_Check RIGHT OUTER JOIN
      CheckRole INNER JOIN
      applySheetCheckRecord ON 
      CheckRole.CheckRoleCode = applySheetCheckRecord.CheckRole ON 
      Base_Person_Check.personCode = applySheetCheckRecord.CheckPersonCode LEFT OUTER
       JOIN
      Base_Person Base_Person_Displays ON 
      applySheetCheckRecord.DisplaysPersonCode = Base_Person_Displays.personCode LEFT
       OUTER JOIN
      ApplySheetHead ON 
      applySheetCheckRecord.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk


