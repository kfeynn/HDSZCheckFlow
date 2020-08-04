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
      ApplyProcessType.ApplyProcessTypeCode, 
      applySheetCheckRecord.applySheetCheckRecord_pk
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
      (ApplyProcessType.IsDisallow = 1) AND (applySheetCheckRecord.IsPass = 0)
      
      union all 
      
    SELECT applySheetCheckRecord.ApplySheetHead_Pk, CheckPersonInRole.PersonCode, 
          ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
          applySheetCheckRecord.Checkdate, ApplyType.ApplyTypeName, 
          Base_Dept.DeptName, ApplySheetHead_Budget.SheetMoney, 
          CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '‘§À„ƒ⁄' WHEN 2 THEN '‘§À„Õ‚'
           WHEN 3 THEN 'ΩÙº±' END AS SubmitType, Base_Person.Name, 
          applySheetCheckRecord.IsPass, applySheetCheckRecord.IsCheckInCompany, 
          applySheetCheckRecord.CheckRole, applySheetCheckRecord.CheckSetp, 
          ApplyProcessType.ApplyProcessTypeCode, 
          applySheetCheckRecord.applySheetCheckRecord_pk
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
          (ApplyProcessType.IsDisallow = 1) AND (applySheetCheckRecord.IsPass = 0)  
      
      




      SELECT applySheetCheckRecord.ApplySheetHead_Pk, CheckFlowInDept.CheckPersonCode, 
            ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
            applySheetCheckRecord.Checkdate, ApplyType.ApplyTypeName, 
            Base_Dept.DeptName, ApplySheetHead_Budget.SheetMoney, 
            CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '‘§À„ƒ⁄' WHEN 2 THEN '‘§À„Õ‚'
             WHEN 3 THEN 'ΩÙº±' END AS SubmitType, Base_Person.Name, 
            applySheetCheckRecord.IsPass, applySheetCheckRecord.IsCheckInCompany
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
            ApplySheetHead.ApplyPersonCode = Base_Person.personCode
      WHERE (applySheetCheckRecord.IsCheckInCompany = 0)
      UNION
      SELECT applySheetCheckRecord.ApplySheetHead_Pk, CheckPersonInRole.PersonCode, 
            ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
            applySheetCheckRecord.Checkdate, ApplyType.ApplyTypeName, 
            Base_Dept.DeptName, ApplySheetHead_Budget.SheetMoney, 
            CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '‘§À„ƒ⁄' WHEN 2 THEN '‘§À„Õ‚'
             WHEN 3 THEN 'ΩÙº±' END AS SubmitType, Base_Person.Name, 
            applySheetCheckRecord.IsPass, applySheetCheckRecord.IsCheckInCompany
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
            applySheetCheckRecord.CheckRole = CheckPersonInRole.CheckRoleCode
      WHERE (applySheetCheckRecord.IsCheckInCompany = 1)
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
