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
-- shiwulei
SELECT ApplySheetHead.ApplySheetNo, ApplySheetBody_Purchase.InventoryCode, 
      Base_inventory.invName, Base_Person.Name, Base_Dept.DeptName, 
      ApplySheetHead.ApplyDate, Base_inventory.MEASNAME, Base_inventory.INVTYPE, 
      ApplySheetHead.ApplySheetHead_Pk, ApplySheetBody_Purchase.Number, 
      ApplySheetBody_Purchase.Money, ApplySheetBody_Purchase.RMBPrice
FROM Base_inventory INNER JOIN
      ApplySheetBody_Purchase ON 
      Base_inventory.invCode = ApplySheetBody_Purchase.InventoryCode RIGHT OUTER JOIN
      ApplySheetHead INNER JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode ON 
      ApplySheetBody_Purchase.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk
WHERE (ApplySheetBody_Purchase.ApplySheetHead_Pk = 130)






--fei shi wu lei 


SELECT ApplySheetHead.ApplySheetNo, Base_Person.Name, Base_Dept.DeptName, 
      ApplySheetHead.ApplyDate, ApplySheetHead.ApplySheetHead_Pk, 
      ApplySheetBody_Pay.Item, ApplySheetBody_Pay.Money
FROM ApplySheetHead INNER JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
      ApplySheetBody_Pay ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetBody_Pay.ApplySheetHead_Pk

GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
