IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Flow_GetNonCheckPerson')
	BEGIN
		PRINT 'Dropping Procedure p_Flow_GetNonCheckPerson'
		DROP  Procedure  p_Flow_GetNonCheckPerson
	END

GO

PRINT 'Creating Procedure p_Flow_GetNonCheckPerson'
GO
CREATE Procedure p_Flow_GetNonCheckPerson
	@applyHeadPk int 
AS

/******************************************************************************
**		File: 
**		Name: p_Flow_GetNonCheckPerson
**		Desc: 根据单句号 ,查询所有还未审批人员 
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

select * into #tempTable  from   (
-- 部门内还未审批 ，参数 ApplySheetHead.ApplySheetHead_Pk  
SELECT CheckRole.CheckRoleName, Base_Person.Name, 
      ApplySheetHead.IsCheckInCompany, CheckFlowInDept.CheckSetp
FROM CheckFlowInDept INNER JOIN
      CheckRole ON 
      CheckFlowInDept.CheckRoleCode = CheckRole.CheckRoleCode INNER JOIN
      Base_Person ON 
      CheckFlowInDept.CheckPersonCode = Base_Person.personCode INNER JOIN
      ApplySheetHead ON 
      CheckFlowInDept.DeptCode = ApplySheetHead.ApplyDeptCode AND 
      CheckFlowInDept.CheckSetp >= ApplySheetHead.CheckSetp
WHERE (ApplySheetHead.ApplySheetHead_Pk = @applyHeadPk) AND 
      (ApplySheetHead.IsCheckInCompany = 0)

union all 

-- 部门外还未审批 ， 参数 ，ApplySheetHead.ApplySheetHead_Pk  


SELECT CheckRole.CheckRoleName, Base_Person.Name, 
     '1' as  IsCheckInCompany, CheckFlowInCompany_Body.CheckStep
FROM Base_Person INNER JOIN
      CheckPersonInRole ON 
      Base_Person.personCode = CheckPersonInRole.PersonCode INNER JOIN
      CheckRole ON 
      CheckPersonInRole.CheckRoleCode = CheckRole.CheckRoleCode INNER JOIN
      CheckFlowInCompany_Body ON 
      CheckPersonInRole.CheckRoleCode = CheckFlowInCompany_Body.CheckRoleCode INNER
       JOIN
      ApplySheetHead ON 
      CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = ApplySheetHead.CheckFlowInCompany_Head_pk
       AND  CheckFlowInCompany_Body.CheckStep >= ApplySheetHead.CheckSetp INNER JOIN
      ApplyProcessType ON 
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode
WHERE (ApplySheetHead.ApplySheetHead_Pk = @applyHeadPk) and (ApplyProcessType.IsFinishInCompany = 0)  AND 
      (ApplyProcessType.IsFinishInDept = 1)

union  all 

SELECT CheckRole.CheckRoleName, Base_Person.Name, 
     '1' as  IsCheckInCompany, CheckFlowInCompany_Body.CheckStep
FROM Base_Person INNER JOIN
      CheckPersonInRole ON 
      Base_Person.personCode = CheckPersonInRole.PersonCode INNER JOIN
      CheckRole ON 
      CheckPersonInRole.CheckRoleCode = CheckRole.CheckRoleCode INNER JOIN
      CheckFlowInCompany_Body ON 
      CheckPersonInRole.CheckRoleCode = CheckFlowInCompany_Body.CheckRoleCode INNER
       JOIN
      ApplySheetHead ON 
      CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = ApplySheetHead.CheckFlowInCompany_Head_pk
  --  AND  CheckFlowInCompany_Body.CheckStep >= ApplySheetHead.CheckSetp 
       INNER JOIN
      ApplyProcessType ON 
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode
WHERE (ApplySheetHead.ApplySheetHead_Pk = @applyHeadPk) AND 
      (ApplyProcessType.IsFinishInCompany = 0)AND 
      (ApplyProcessType.IsFinishInDept = 0)
) temp1 order by temp1.ischeckincompany ,temp1.checksetp 




------------------------------- 审批过的角色,以及信息 
-------------------------------
SELECT rec.applySheetCheckRecord_pk, rec.ApplySheetHead_Pk, rec.IsCheckInCompany, rec.CheckRole, 
      rec.CheckPersonCode,rec. IsPass, CONVERT(varchar(100),rec.Checkdate,120) as Checkdate, rec.CheckComment, rec.IsDisplays, 
     rec. DisplaysPersonCode, rec.CheckSetp
, case rec.IsPass when 1 then '同意' when 0 then '拒绝' end as IsAgree , ApplyType.ApplyTypeName, per.Name,
							(SELECT name
							FROM base_person per
							WHERE per.personcode = rec.displayspersoncode AND isdisplays = 1) 
								AS displaysName,CheckRole.CheckRoleName 
							FROM applySheetCheckRecord rec INNER JOIN
							ApplySheetHead ON 
							rec.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk INNER JOIN
							ApplyType ON 
							ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
							Base_Person per ON rec.CheckPersonCode = per.personCode  INNER JOIN
								CheckRole ON rec.CheckRole = CheckRole.CheckRoleCode
							where rec.ApplySheetHead_Pk= @applyHeadPk    

union all 

-------------------------------- 未审批人的信息 
-------------------------------
select '' as applysheetcheckrecord_pk ,'' as applysheethead_pk, ischeckincompany,'' as checkrole ,'' as checkpersoncode , 0 as ispass ,'' as checkdate,
'' as checkcomment , 0 as isdisplays, '' as displayspersoncode, checksetp , '未审批' as isAgree ,'' as ApplyTypeName , Name,'' as displaysName ,
CheckRoleName
from #tempTable 


drop table  #tempTable
GO


GRANT EXEC ON p_Flow_GetNonCheckPerson TO PUBLIC

GO
