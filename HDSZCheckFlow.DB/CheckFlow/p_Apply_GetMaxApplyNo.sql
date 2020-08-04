IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Apply_GetMaxApplyNo')
	BEGIN
		PRINT 'Dropping Procedure p_Apply_GetMaxApplyNo'
		DROP  Procedure  p_Apply_GetMaxApplyNo
	END

GO

PRINT 'Creating Procedure p_Apply_GetMaxApplyNo'
GO
CREATE Procedure p_Apply_GetMaxApplyNo
	@perFix varchar(50)
AS

/******************************************************************************
**		File: 
**		Name: p_Apply_GetMaxApplyNo
**		Desc: 取目前最大流水号 
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


select Max(RIGHT(ApplySheetNo,5)) AS MaxNum from applysheethead where substring(applysheetno,0,len(applysheetno)-4)= @perFix


GO

GRANT EXEC ON p_Apply_GetMaxApplyNo TO PUBLIC

GO
