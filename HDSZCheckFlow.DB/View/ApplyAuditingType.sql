CREATE VIEW dbo.ApplyAuditingType
AS
SELECT a.*,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptclasscode) AS DeptClass,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptcode) AS Dept, 
      CASE g.SubmitType WHEN 1 THEN '‘§À„ƒ⁄' WHEN 2 THEN '‘§À„Õ‚' WHEN 3 THEN 'ΩÙº±'
       END AS SubmitType, f.ApplyTypeName AS ApplyTypeName,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.ApplyPersonCode) AS submitPerson,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.applyMakercode) AS MakerName, 
      d .CheckRoleName AS CheckRoleName, e.Name AS UserName, 
      c.PersonCode AS PersonCode, appBud.SheetMoney
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      CheckPersonInRole c ON b.CheckRoleCode = c.CheckRoleCode INNER JOIN
      CheckRole d ON d .CheckRoleCode = c.CheckRoleCode INNER JOIN
      Base_Person e ON c.PersonCode = e.personCode INNER JOIN
      ApplyType f ON f.ApplyTypeCode = a.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget g ON 
      g.ApplySheetHead_Pk = a.ApplySheetHead_Pk INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode INNER JOIN
      ApplySheetHead_Budget appBud ON 
      appBud.ApplySheetHead_Pk = a.ApplySheetHead_Pk

