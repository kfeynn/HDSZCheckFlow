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

SELECT Base_Dept.DeptName, Base_Person.Name, ApplySheetHead.ApplyDate, 
      ApplyType.ApplyTypeName, ApplySheetHead_Budget.SheetMoney, 
      CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '‘§À„ƒ⁄' WHEN 2 THEN '‘§À„Õ‚'
       WHEN 3 THEN 'ΩÙ º±' END AS SubmitType, 
      ApplySheetHead.ApplySheetHead_Pk
FROM ApplySheetHead INNER JOIN
      Base_Person ON 
      ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
      Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
      ApplyType ON 
      ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
      ApplySheetHead_Budget ON 
      ApplySheetHead.ApplySheetHead_Pk = ApplySheetHead_Budget.ApplySheetHead_Pk INNER
       JOIN
      ApplyProcessType ON 
      ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode




SELECT Base_inventory.invCode, Base_inventory.invName, Base_inventory.INVSPEC, 
      Base_inventory.MEASNAME, ApplySheetBody_Purchase.Number, 
      ApplySheetBody_Purchase.RMBPrice, ApplySheetBody_Purchase.Money, 
      ApplySheetBody_Purchase.Memo, ApplySheetBody_Purchase.currTypeCode, 
      ApplySheetBody_Purchase.ExchangeRate, 
      ApplySheetBody_Purchase.originalcurrPrice
FROM ApplySheetBody_Purchase INNER JOIN
      Base_inventory ON 
      ApplySheetBody_Purchase.InventoryCode = Base_inventory.invCode
WHERE (ApplySheetBody_Purchase.ApplySheetHead_Pk = 216)









GO

GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
