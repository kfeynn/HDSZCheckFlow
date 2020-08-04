IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'p_Order_GetMaxOrderNo')
	BEGIN
		PRINT 'Dropping Procedure p_Order_GetMaxOrderNo'
		DROP  Procedure  p_Order_GetMaxOrderNo
	END

GO

PRINT 'Creating Procedure p_Order_GetMaxOrderNo'
GO
CREATE Procedure p_Order_GetMaxOrderNo
	/* Param List */
	@perFix varchar(50)
AS

/******************************************************************************
**		File: 
**		Name: p_Order_GetMaxOrderNo
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
select Max(RIGHT(OrderNo,5)) AS MaxNum from OrderSheet    where substring(OrderNo,0,len(OrderNo)-4)= @perFix




GO

GRANT EXEC ON p_Order_GetMaxOrderNo TO PUBLIC

GO
