 
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'PImportGLNCCost')
	BEGIN
		PRINT 'Dropping Procedure PImportGLNCCost'
		DROP  Procedure  PImportGLNCCost
	END

GO

PRINT 'Creating Procedure PImportGLNCCost'
GO  
 
CREATE  proc PImportGLNCCost @IYear  int,@IMonth int as

--��NC������ÿ�·��õ���


delete from  GL_NC_Cost where IYear=@IYear and IMOnth=@IMonth



insert into GL_NC_Cost
 ( IYEAR ,IMonth, NCDeptCode,  NCDeptName,subjName, subjcode  , localRealCost , localcreditCost)


(
select  cast( D.[YEAR] as int)  AS IYEAR ,
	 D.PERIOD AS IMonth,    
	d.valuecode as NCDeptCode, 
	d.valuename as NCDeptName,
	 d.dispname as subjName,
	d.subjcode  ,	
	sum(d.localdebitamount) AS localRealCost ,   --�跽���ҽ���ʾ����
	sum(localcreditamount) as localcreditamount




from 	NCDATA..HDSZDBA.V_HZ_GL_DETAIL   d 
where 	(left(d.subjcode,1)='4'  OR  left(d.subjcode,1)='5' ) --�������Ŀ

	AND   cast( D.[YEAR] as int) =@IYear  AND 
	  cast(D.PERIOD  as int)=@IMonth


group by   d.dispname,d.subjcode ,d.valuecode,d.valuename,D.[YEAR], D.PERIOD --�ϼƵ��²��ſ�Ŀ����

)









GO
