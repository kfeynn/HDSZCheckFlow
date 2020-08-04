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
SELECT applySheetCheckRecord.ApplySheetHead_Pk, CheckFlowInDept.CheckPersonCode, 
      ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
      applySheetCheckRecord.Checkdate, ApplyType.ApplyTypeName, 
      Base_Dept.DeptName, ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '‘§À„ƒ⁄' WHEN 2 THEN '‘§À„Õ‚'
       WHEN 3 THEN 'ΩÙº±' END AS SubmitType, Base_Person.Name, 
      applySheetCheckRecord.IsPass, applySheetCheckRecord.IsCheckInCompany, 
      applySheetCheckRecord.CheckRole, applySheetCheckRecord.CheckSetp, 
      ApplyProcessType.ApplyProcessTypeCode, ApplySheetHead.ApplyTypeCode, 
      Base_Dept.DeptCode, Base_Dept.superior_Dept_pk
FROM applySheetCheckRecord INNER JOIN
      CheckFlowInDept ON 
      applySheetCheckRecord.CheckRole = CheckFlowInDept.CheckRoleCode AND 
      applySheetCheckRecord.CheckSetp = CheckFlowInDept.CheckSetp INNER JOIN
      ApplySheetHead ON 
      applySheetCheckRecord.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk INNER
       JOIN
      ApplyType ON 
      ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
      ApplySheetHead_Budget ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetHead_Budget.ApplySheetHead_Pk INNER
       JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      ApplyProcessType ON 
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode
WHERE (applySheetCheckRecord.IsCheckInCompany = 0) AND 
      (ApplyProcessType.IsDisallow = 1)


SELECT applySheetCheckRecord.ApplySheetHead_Pk, CheckPersonInRole.PersonCode, 
      ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
      applySheetCheckRecord.Checkdate, ApplyType.ApplyTypeName, 
      Base_Dept.DeptName, ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '‘§À„ƒ⁄' WHEN 2 THEN '‘§À„Õ‚'
       WHEN 3 THEN 'ΩÙº±' END AS SubmitType, Base_Person.Name, 
      applySheetCheckRecord.IsPass, applySheetCheckRecord.IsCheckInCompany, 
      applySheetCheckRecord.CheckRole, applySheetCheckRecord.CheckSetp, 
      ApplyProcessType.ApplyProcessTypeCode, ApplySheetHead.ApplyTypeCode, 
      Base_Dept.DeptCode, Base_Dept.superior_Dept_pk
FROM applySheetCheckRecord INNER JOIN
      ApplySheetHead ON 
      applySheetCheckRecord.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk INNER
       JOIN
      ApplyType ON 
      ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
      ApplySheetHead_Budget ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetHead_Budget.ApplySheetHead_Pk INNER
       JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      CheckPersonInRole ON 
      applySheetCheckRecord.CheckRole = CheckPersonInRole.CheckRoleCode INNER JOIN
      ApplyProcessType ON 
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode
WHERE (applySheetCheckRecord.IsCheckInCompany = 1) AND 
      (ApplyProcessType.IsDisallow = 1)



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
      b.CheckRoleName AS CheckRoleName, e.Name AS UserName, 
      e.personCode AS PersonCode
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      ApplyType f ON f.ApplyTypeCode = a.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget g ON 
      g.ApplySheetHead_Pk = a.ApplySheetHead_Pk INNER JOIN
      CheckFlowInDept ON a.CurrentCheckRole = CheckFlowInDept.CheckRoleCode AND 
      a.CheckSetp = CheckFlowInDept.CheckSetp INNER JOIN
      Base_Person e ON CheckFlowInDept.CheckPersonCode = e.personCode INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode
WHERE (a.IsCheckInCompany = 0) AND (e.personCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = '084150') AND (IsDisplays = 1) OR
               (UserName = '084150'))) AND (type.IsFinishInCompany = 0)







GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
