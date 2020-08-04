IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Stored_Procedure_Name')
	BEGIN
		PRINT 'Dropping Procedure Stored_Procedure_Name'
		DROP  Procedure  Stored_Procedure_Name
	END

GO

PRINT 'Creating Procedure Stored_Procedure_Name'
GO
CREATE Procedure Stored_Procedure_Name
	/* Param List */
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.subjectName
FROM Base_AccountSubject INNER JOIN
      Base_SubjectCodeInApplyType ON 
      Base_SubjectCodeInApplyType.firstSubjectCode = LEFT(Base_AccountSubject.subjectCode,
       4) AND Base_AccountSubject.IsEnd = 'y' AND Base_AccountSubject.DR = 0 AND 
      LEFT(Base_AccountSubject.subjectCode, 4) = '4105' AND 
      Base_SubjectCodeInApplyType.ApplyTypeCode = 'ad0502' AND 
      Base_SubjectCodeInApplyType.subjectCode = Base_AccountSubject.subjectCode
ORDER BY Base_AccountSubject.subjectCode

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
      d.CheckRoleName AS CheckRoleName, e.Name AS UserName, 
      c.PersonCode AS PersonCode, appBud.SheetMoney
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      CheckPersonInRole c ON b.CheckRoleCode = c.CheckRoleCode INNER JOIN
      CheckRole d ON d.CheckRoleCode = c.CheckRoleCode INNER JOIN
      Base_Person e ON c.PersonCode = e.personCode INNER JOIN
      ApplyType f ON f.ApplyTypeCode = a.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget g ON 
      g.ApplySheetHead_Pk = a.ApplySheetHead_Pk INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode INNER JOIN
      ApplySheetHead_Budget appBud ON 
      appBud.ApplySheetHead_Pk = a.ApplySheetHead_Pk
WHERE (c.PersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = '930038') AND (IsDisplays = 1) OR
               (UserName = '930038'))) AND (a.IsCheckInCompany = 1) AND 
      (type.IsFinishInCompany = 0) AND (type.IsDisallow = 0) AND (b.IsRefer = 0)
      
      
      
      SELECT CheckRole.CheckRoleName, Base_Person.Name, 
            CheckFlowInCompany_Body.CheckStep
      FROM Base_Person INNER JOIN
            CheckPersonInRole ON 
            Base_Person.personCode = CheckPersonInRole.PersonCode INNER JOIN
            CheckRole ON CheckPersonInRole.CheckRoleCode = CheckRole.CheckRoleCode AND 
            CheckRole.IsRefer = 0 INNER JOIN
            CheckFlowInCompany_Body ON 
            CheckFlowInCompany_Body.CheckRoleCode = CheckRole.CheckRoleCode
      WHERE (CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = 24)
      ORDER BY CheckFlowInCompany_Body.CheckStep
      
      
      
      
      
GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
