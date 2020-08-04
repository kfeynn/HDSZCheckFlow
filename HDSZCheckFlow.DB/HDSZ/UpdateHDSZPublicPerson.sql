IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateHDSZPublicPerson')
	BEGIN
		PRINT 'Dropping Procedure UpdateHDSZPublicPerson'
		DROP  Procedure  UpdateHDSZPublicPerson
	END

GO

PRINT 'Creating Procedure UpdateHDSZPublicPerson'
GO
CREATE Procedure UpdateHDSZPublicPerson
	/* Param List */
AS

/******************************************************************************
**		File: 
**		Name: UpdateHDSZPublicPerson
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

delete from  HDSZPublicData.dbo.HDSZ_Person 


--更新人员表

insert into   HDSZPublicData.dbo.HDSZ_Person ( bmid, gzbhid, gzbh, xm, xb, sfz, csny, inf, bmbh, bmmc, zw, mz, xl, hkszd, xw, 
      pict,  fyzk, jg, zzmm, zy,  cjgzsj,  jtzz, qyrq, qysc, byyx, bysj, cyfs, xx, 
      zj, outf, outc, zyjn, jndj, zc, sh, hkxz, gw, syqmr, jbxd, zzzhm, zzzdqny, lxdh, htqm, 
      syqzt, bmmc1,    fycb, bmbh1, bmmc2, fylb, fycode, fybh )
select  bmid, gzbhid, gzbh, xm, xb, sfz, csny, inf, bmbh, bmmc, zw, mz, xl, hkszd, xw, 
      pict,  fyzk, jg, zzmm, zy,  cjgzsj,  jtzz, qyrq, qysc, byyx, bysj, cyfs, xx, 
      zj, outf, outc, zyjn, jndj, zc, sh, hkxz, gw, syqmr, jbxd, zzzhm, zzzdqny, lxdh, htqm, 
      syqzt, bmmc1,    fycb, bmbh1, bmmc2, fylb, fycode, fybh 
 from  HrSysData.dbo.KQ_CS_GZB




 --更新部门表
 
 delete from HDSZPublicData.dbo.HDSZ_BM
 
insert into HDSZPublicData.dbo.HDSZ_BM (  bmid, bmbh, bmmc, bmrs, bmxs, bz, sjbmid, bmcs, bmgx )
select   bmid, bmbh, bmmc, bmrs, bmxs, bz, sjbmid, bmcs, bmgx     FROM HrSysData.dbo.KQ_CS_BM
GO


GRANT EXEC ON UpdateHDSZPublicPerson TO PUBLIC

GO
