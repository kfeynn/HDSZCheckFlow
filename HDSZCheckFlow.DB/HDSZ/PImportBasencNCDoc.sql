 
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'PImportBasencNCDoc')
	BEGIN
		PRINT 'Dropping Procedure PImportBasencNCDoc'
		DROP  Procedure  PImportBasencNCDoc
	END

GO

PRINT 'Creating Procedure PImportBasencNCDoc'
GO  


CREATE   procedure  PImportBasencNCDoc  as


--�ȸ��� HDSZPublic ���� 
exec HDSZPUBLICDATA.DBO.PImportBasencNCDoc


--����NC��������

-- 

--����������
delete from Base_inventory
insert into Base_inventory
(inv_pk,	--�������
invCode,        --�������
invName,        --�������
MEASNAME,       -- ������λ
InvClass_pk,    --����������
INVSPEC,        --���
INVTYPE,         -- �ͺ�
CurrTypeCode,         --����
OriginalcurPrice,     --ԭ�ҵ���
OrderDate              --�۸�����
)
(select 
InvID,InvCode,InvName,MEASName,InvClassID,invspec ,invtype ,CurrTypeCode,OriginalcurPrice,OrderDate
from HDSZPUBLICDATA.DBO.BaseNCInv
)


update Base_inventory set invName=replace(invName,'"','')   -- where invCode LIKE '245%'

--���벿�ŵ���

--����, �������
update Base_NC_Dept set NC_DeptCode=(select DeptCode from   HDSZPUBLICDATA.DBO.BaseNCDept a where a.DeptID=Base_NC_Dept.NC_Dept_pk )

--���룬�������
insert into Base_NC_Dept 
(
NC_Dept_pk,   --��������
NC_DeptCode,  --���ű���
NC_DeptName   --��������
)
select DeptID,DeptCode,DeptName from  HDSZPUBLICDATA.DBO.BaseNCDept a where a.DeptID not in 
(
select NC_Dept_pk from Base_NC_Dept  
)


--���������൵����ֱ�ģ�����

delete from Base_InvClass	
insert into Base_InvClass
(InvClass_pk,			--�ֿ�����
invClassCode,			--�ֿ����
InvClassName			--�ֿ�����

)
(SELECT InvClassID,InvClassCode,InvClassName
 FROM  HDSZPUBLICDATA.DBO.BaseNCInvClass)


--��������Ŀ

delete from Base_AccountSubject

insert into Base_AccountSubject  
(	 
AccountSubject_pk, subjectCode, subjectName, subjectLevel, IsEnd, SealFlag,dr,Dispname
)
(
SELECT 
	PK_ACCSUBJ,	--��Ŀ���� 
 	SUBJCODE, 	--��Ŀ���� 
	SUBJNAME,	--��Ŀ���� 
	SUBJLEV,	--��Ŀ���� 
 	ENDFLAG,	--ĩ����־ 
	SEALFLAG,       --����־
	dr,		--ɾ����־
	Dispname

FROM  HDSZPUBLICDATA.DBO.BASENCACCSUBJ o where o.PK_CORP='1001'   --ȡ����˾�Ŀ�Ŀ
)


--������Ա�����ڲ��ŵ���Ŀ����

delete from Base_Person 

insert into Base_Person (personCode , Name,DeptCode ,Rank)
select gzbh,xm,bmbh ,zw from  HDSZPUBLICDATA.DBO.HDSZ_Person

UPDATE Base_Person
SET DeptCode =substring(deptcode,0,len(deptcode)-1)+'00'  where left(deptcode,1)!='Z'
GO
