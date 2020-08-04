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

SELECT COUNT(0) AS Expr1
FROM CheckFlowInDept CROSS JOIN
      CheckPersonInRole
WHERE (CheckFlowInDept.CheckPersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = '084150') AND (IsDisplays = 1) OR
               (UserName = '084150'))) AND 
      (CheckFlowInDept.CheckRoleCode = 'ITKezhang') AND 
      (CheckFlowInDept.DeptCode = '002100') OR
      (CheckPersonInRole.CheckRoleCode = 'ITKezhang') AND 
      (CheckPersonInRole.PersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = '084150') AND (IsDisplays = 1) OR
               (UserName = '084150')))




SELECT ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
      ApplyType.ApplyTypeName, Base_Dept.DeptName, 
      ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '‘§À„ƒ⁄' WHEN 2 THEN '‘§À„Õ‚'
       WHEN 3 THEN 'ΩÙº±' END AS SubmitType, Base_Person.Name, 
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
WHERE (ApplyProcessType.IsDisallow = 1) AND (ApplySheetHead.IsCheckInCompany = 0)


GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
