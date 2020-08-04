IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Flow_GetMyDuditingTemp')
	BEGIN
		PRINT 'Dropping Procedure p_Flow_GetMyDuditingTemp'
		DROP  Procedure  p_Flow_GetMyDuditingTemp
	END

GO

PRINT 'Creating Procedure p_Flow_GetMyDuditingTemp'
GO
CREATE Procedure p_Flow_GetMyDuditingTemp
	@UserCode varchar(50) ,
	@filter  varchar(500)
AS

/******************************************************************************
**		File: 
**		Name: p_Flow_GetMyDuditingTemp
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

--  属于自己审批的单据信息
/*
SELECT a.*,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptclasscode) AS DeptClass,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptcode) AS Dept, 
      CASE g.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外' WHEN 3 THEN '紧急'
       END AS SubmitType, f.ApplyTypeName AS ApplyTypeName,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.ApplyPersonCode) AS submitPerson,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.applyMakercode) AS MakerName, 
      d .CheckRoleName AS CheckRoleName, e.Name AS UserName, 
      c.PersonCode AS PersonCode,appBud.SheetMoney
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      CheckPersonInRole c ON b.CheckRoleCode = c.CheckRoleCode INNER JOIN
      CheckRole d ON d .CheckRoleCode = c.CheckRoleCode INNER JOIN
      Base_Person e ON c.PersonCode = e.personCode INNER JOIN
      ApplyType f ON f.ApplyTypeCode = a.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget g ON 
      g.ApplySheetHead_Pk = a.ApplySheetHead_Pk INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode inner join ApplySheetHead_Budget appBud on appBud.ApplySheetHead_Pk=a.ApplySheetHead_Pk  
WHERE (c.PersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = @UserCode) AND (IsDisplays = 1) OR
               (UserName = @UserCode))) AND a.IsCheckInCompany = 1 AND (type.IsFinishInCompany = 0) AND (type.IsDisallow = 0)
               
UNION ALL         -- 联合
-- 属于别人转让给自己的审批单据信息
SELECT a.*,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptclasscode) AS DeptClass,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptcode) AS Dept, 
      CASE g.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外' WHEN 3 THEN '紧急'
       END AS SubmitType, f.ApplyTypeName AS ApplyTypeName,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.ApplyPersonCode) AS submitPerson,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.applyMakercode) AS MakerName, 
      b.CheckRoleName AS CheckRoleName, e.Name AS UserName, 
      e.personCode AS PersonCode,appBud.SheetMoney 
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      ApplyType f ON f.ApplyTypeCode = a.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget g ON 
      g.ApplySheetHead_Pk = a.ApplySheetHead_Pk INNER JOIN
      CheckFlowInDept ON a.CurrentCheckRole = CheckFlowInDept.CheckRoleCode AND 
      a.CheckSetp = CheckFlowInDept.CheckSetp and  a.ApplyDeptCode = CheckFlowInDept.DeptCode INNER JOIN
      Base_Person e ON CheckFlowInDept.CheckPersonCode = e.personCode INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode inner join ApplySheetHead_Budget appBud on appBud.ApplySheetHead_Pk=a.ApplySheetHead_Pk  
WHERE (a.IsCheckInCompany = 0) AND (e.personCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson = @UserCode) AND (IsDisplays = 1) OR
               (UserName = @UserCode))) AND (type.IsFinishInCompany = 0) AND (type.IsDisallow = 0)

*/

SELECT a.*,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptclasscode) AS DeptClass,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptcode) AS Dept, 
      CASE g.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外' WHEN 3 THEN '紧急'
       END AS SubmitType, f.ApplyTypeName AS ApplyTypeName,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.ApplyPersonCode) AS submitPerson,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.applyMakercode) AS MakerName, 
      e.Name AS UserName, c.PersonCode AS PersonCode, g.SheetMoney, 
      b.CheckRoleName into #temp 
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      CheckPersonInRole c ON b.CheckRoleCode = c.CheckRoleCode INNER JOIN
      Base_Person e ON c.PersonCode = e.personCode INNER JOIN
      ApplyType f ON f.ApplyTypeCode = a.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget g ON 
      g.ApplySheetHead_Pk = a.ApplySheetHead_Pk INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode
WHERE (c.PersonCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson =  @UserCode) AND (IsDisplays = 1) OR
               (UserName =  @UserCode))) AND (type.IsFinishInCompany = 0) AND 
      (type.IsDisallow = 0)

union all 

SELECT a.*,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptclasscode) AS DeptClass,
          (SELECT deptName
         FROM Base_Dept
         WHERE Base_Dept.deptcode = a.applydeptcode) AS Dept, 
      CASE g.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外' WHEN 3 THEN '紧急'
       END AS SubmitType, f.ApplyTypeName AS ApplyTypeName,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.ApplyPersonCode) AS submitPerson,
          (SELECT Name
         FROM Base_Person
         WHERE Base_Person.personCode = a.applyMakercode) AS MakerName, 
      e.Name AS UserName, e.personCode AS PersonCode, g.SheetMoney, 
      b.CheckRoleName
FROM ApplySheetHead a INNER JOIN
      CheckRole b ON a.CurrentCheckRole = b.CheckRoleCode INNER JOIN
      ApplyType f ON f.ApplyTypeCode = a.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget g ON 
      g.ApplySheetHead_Pk = a.ApplySheetHead_Pk INNER JOIN
      CheckFlowInDept ON a.CurrentCheckRole = CheckFlowInDept.CheckRoleCode AND 
      a.CheckSetp = CheckFlowInDept.CheckSetp AND 
      a.ApplyDeptCode = CheckFlowInDept.DeptCode INNER JOIN
      Base_Person e ON CheckFlowInDept.CheckPersonCode = e.personCode INNER JOIN
      ApplyProcessType type ON 
      a.ApplyProcessCode = type.ApplyProcessTypeCode
WHERE (type.IsFinishInCompany = 0) AND (type.IsDisallow = 0) AND 
      (a.IsCheckInCompany = 0) AND (e.personCode IN
          (SELECT UserName
         FROM xpGrid_User
         WHERE (displaysPerson =  @UserCode) AND (IsDisplays = 1) OR
               (UserName =  @UserCode)))
               
   
declare @sqlStr varchar(500)
set @sqlStr = 'select * from #temp  ' + @filter
exec (@sqlStr)
GO

GRANT EXEC ON p_Flow_GetMyDuditingTemp TO PUBLIC

GO
