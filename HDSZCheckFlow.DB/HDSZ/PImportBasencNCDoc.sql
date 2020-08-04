 
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'PImportBasencNCDoc')
	BEGIN
		PRINT 'Dropping Procedure PImportBasencNCDoc'
		DROP  Procedure  PImportBasencNCDoc
	END

GO

PRINT 'Creating Procedure PImportBasencNCDoc'
GO  


CREATE   procedure  PImportBasencNCDoc  as


--先更新 HDSZPublic 资料 
exec HDSZPUBLICDATA.DBO.PImportBasencNCDoc


--导入NC基础当案

-- 

--导入存货档案
delete from Base_inventory
insert into Base_inventory
(inv_pk,	--存货主键
invCode,        --存货编码
invName,        --存货名称
MEASNAME,       -- 计量单位
InvClass_pk,    --存货分类编码
INVSPEC,        --规格
INVTYPE,         -- 型号
CurrTypeCode,         --币种
OriginalcurPrice,     --原币单价
OrderDate              --价格日期
)
(select 
InvID,InvCode,InvName,MEASName,InvClassID,invspec ,invtype ,CurrTypeCode,OriginalcurPrice,OrderDate
from HDSZPUBLICDATA.DBO.BaseNCInv
)


update Base_inventory set invName=replace(invName,'"','')   -- where invCode LIKE '245%'

--导入部门档案

--更新, 有则更新
update Base_NC_Dept set NC_DeptCode=(select DeptCode from   HDSZPUBLICDATA.DBO.BaseNCDept a where a.DeptID=Base_NC_Dept.NC_Dept_pk )

--插入，无则插入
insert into Base_NC_Dept 
(
NC_Dept_pk,   --部门主键
NC_DeptCode,  --部门编码
NC_DeptName   --部门名称
)
select DeptID,DeptCode,DeptName from  HDSZPUBLICDATA.DBO.BaseNCDept a where a.DeptID not in 
(
select NC_Dept_pk from Base_NC_Dept  
)


--导入存货分类档案，直材，辅材

delete from Base_InvClass	
insert into Base_InvClass
(InvClass_pk,			--仓库主键
invClassCode,			--仓库编码
InvClassName			--仓库名称

)
(SELECT InvClassID,InvClassCode,InvClassName
 FROM  HDSZPUBLICDATA.DBO.BaseNCInvClass)


--导入财务科目

delete from Base_AccountSubject

insert into Base_AccountSubject  
(	 
AccountSubject_pk, subjectCode, subjectName, subjectLevel, IsEnd, SealFlag,dr,Dispname
)
(
SELECT 
	PK_ACCSUBJ,	--科目主键 
 	SUBJCODE, 	--科目编码 
	SUBJNAME,	--科目名称 
	SUBJLEV,	--科目级次 
 	ENDFLAG,	--末级标志 
	SEALFLAG,       --封存标志
	dr,		--删除标志
	Dispname

FROM  HDSZPUBLICDATA.DBO.BASENCACCSUBJ o where o.PK_CORP='1001'   --取本公司的科目
)


--更新人员所属于部门到科目级别

delete from Base_Person 

insert into Base_Person (personCode , Name,DeptCode ,Rank)
select gzbh,xm,bmbh ,zw from  HDSZPUBLICDATA.DBO.HDSZ_Person

UPDATE Base_Person
SET DeptCode =substring(deptcode,0,len(deptcode)-1)+'00'  where left(deptcode,1)!='Z'
GO
