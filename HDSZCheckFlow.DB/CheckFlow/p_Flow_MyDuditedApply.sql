IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Flow_MyDuditedApply')
	BEGIN
		PRINT 'Dropping Procedure p_Flow_MyDuditedApply'
		DROP  Procedure  p_Flow_MyDuditedApply
	END

GO

PRINT 'Creating Procedure p_Flow_MyDuditedApply'
GO
CREATE Procedure p_Flow_MyDuditedApply
	@UserCode varchar(50),                  --审核人工号
	@isPass int                             --审核标记是否通过
AS

/******************************************************************************
**		File: 
**		Name: p_Flow_MyDuditedApply
**
**		Desc:  查询属于我的已审批记录
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
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外'
       WHEN 3 THEN '紧急' END AS SubmitType, Base_Person.Name, 
      applySheetCheckRecord.IsPass, applySheetCheckRecord.IsCheckInCompany, 
      applySheetCheckRecord.CheckRole, applySheetCheckRecord.CheckSetp, 
      ApplyProcessType.ApplyProcessTypeCode
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
      (ApplyProcessType.IsDisallow = 1) and applySheetCheckRecord.isPass= @isPass  and 
      (CheckFlowInDept.CheckPersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = @UserCode) AND (IsDisplays = 1) OR
               (UserName = @UserCode))) 
      UNION all
    SELECT applySheetCheckRecord.ApplySheetHead_Pk, CheckPersonInRole.PersonCode, 
      ApplySheetHead.ApplySheetNo, ApplySheetHead.ApplyDate, 
      applySheetCheckRecord.Checkdate, ApplyType.ApplyTypeName, 
      Base_Dept.DeptName, ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外'
       WHEN 3 THEN '紧急' END AS SubmitType, Base_Person.Name, 
      applySheetCheckRecord.IsPass, applySheetCheckRecord.IsCheckInCompany, 
      applySheetCheckRecord.CheckRole, applySheetCheckRecord.CheckSetp, 
      ApplyProcessType.ApplyProcessTypeCode
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
      (ApplyProcessType.IsDisallow = 1) and applySheetCheckRecord.isPass= @isPass  and 
      (CheckPersonInRole.PersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = @UserCode) AND (IsDisplays = 1) OR
               (UserName = @UserCode))) 
      
    

GO


GRANT EXEC ON p_Flow_MyDuditedApply TO PUBLIC

GO
