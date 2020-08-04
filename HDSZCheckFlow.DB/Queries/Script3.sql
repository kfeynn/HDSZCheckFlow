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

SELECT rec.*, 
      CASE rec.IsPass WHEN 1 THEN 'Í¬Òâ' WHEN 0 THEN '¾Ü¾ø' END AS IsAgree, 
      ApplyType.ApplyTypeName, per.Name,
          (SELECT name
         FROM base_person per
         WHERE per.personcode = rec.displayspersoncode AND isdisplays = 1) 
      AS displaysName, CheckRole.CheckRoleName
FROM applySheetCheckRecord rec INNER JOIN
      ApplySheetHead ON 
      rec.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk INNER JOIN
      ApplyType ON 
      ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
      Base_Person per ON rec.CheckPersonCode = per.personCode INNER JOIN
      CheckRole ON rec.CheckRole = CheckRole.CheckRoleCode
WHERE (rec.ApplySheetHead_Pk = 91)
ORDER BY rec.Checkdate


SELECT COUNT(0) AS Expr1
FROM CheckFlowInDept CROSS JOIN
      CheckPersonInRole
WHERE (CheckFlowInDept.CheckPersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = '084150') AND (IsDisplays = 1) OR
               (UserName = '084150')))) AND 
      (CheckFlowInDept.CheckRoleCode = 'ITKezhang') AND 
      (CheckFlowInDept.DeptCode = '002300') OR
      (CheckPersonInRole.CheckRoleCode = 'FinKezhang') AND 
      (CheckPersonInRole.PersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = '084150') AND (IsDisplays = 1) OR
               (UserName = '084150'))))
      SELECT Base_inventory.*, Base_InvClass.InvClassName, 
            Base_InvClass.invClassCode
      FROM Base_InvClass INNER JOIN
            Base_inventory ON Base_InvClass.InvClass_pk = Base_inventory.InvClass_pk

GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
