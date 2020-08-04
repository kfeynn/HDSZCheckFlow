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

SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.Dispname
FROM Base_AccountSubject RIGHT OUTER JOIN
      Base_CommonRelation ON 
      Base_AccountSubject.subjectCode = Base_CommonRelation.sunCode




SELECT Base_inventory.invCode, Base_inventory.invName, Base_inventory.INVSPEC, 
      Base_inventory.MEASNAME, ApplySheetBody_Purchase.Number, 
      ApplySheetBody_Purchase.originalcurrPrice, 
      ApplySheetBody_Purchase.Money
FROM ApplySheetBody_Purchase INNER JOIN
      Base_inventory ON 
      ApplySheetBody_Purchase.InventoryCode = Base_inventory.invCode


GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
