IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'b_getQuarterBudgetChange')
	BEGIN
		PRINT 'Dropping Procedure b_getQuarterBudgetChange'
		DROP  Procedure  b_getQuarterBudgetChange
	END

GO

PRINT 'Creating Procedure b_getQuarterBudgetChange'
GO
CREATE Procedure b_getQuarterBudgetChange
	@year int,                   -- 年
	@quarter int,                -- 季度
	@dept varchar(50),           -- 部门
	@subjectcode varchar(50),     -- 科目
	@changemoney decimal output   --返回参数(调整金额)
AS

/******************************************************************************

**		Desc: 获得科目季度调整金额
**
*******************************************************************************/

declare @InMoney decimal
declare @OutMoney decimal 

set @InMoney = 0.00
set @OutMoney = 0.00
-- 1. 转入金额 - 转出金额 
if @quarter = 1 
begin 
SELECT @InMoney = sum(Money) 
FROM budget_change_Sheet
WHERE (InSubject = @subjectcode ) AND (Imonth IN (1,2,3)) AND (DeptCode = @dept) and iyear = @year

SELECT @OutMoney = sum(Money) 
FROM budget_change_Sheet
WHERE (OutSubject = @subjectcode ) AND (Imonth IN (1,2,3)) AND (DeptCode = @dept) and iyear = @year

end

if @quarter = 2
begin 
SELECT @InMoney = sum(Money) 
FROM budget_change_Sheet
WHERE (InSubject = @subjectcode ) AND (Imonth IN (4,5,6)) AND (DeptCode = @dept) and iyear = @year

SELECT @OutMoney = sum(Money) 
FROM budget_change_Sheet
WHERE (OutSubject = @subjectcode ) AND (Imonth IN (4,5,6)) AND (DeptCode = @dept) and iyear = @year

end

if @quarter = 3 
begin 
SELECT @InMoney = sum(Money) 
FROM budget_change_Sheet
WHERE (InSubject = @subjectcode ) AND (Imonth IN (7,8,9)) AND (DeptCode = @dept) and iyear = @year

SELECT @OutMoney = sum(Money) 
FROM budget_change_Sheet
WHERE (OutSubject = @subjectcode ) AND (Imonth IN (7,8,9)) AND (DeptCode = @dept) and iyear = @year

end

if @quarter = 4 
begin 
SELECT @InMoney = sum(Money) 
FROM budget_change_Sheet
WHERE (InSubject = @subjectcode ) AND (Imonth IN (10, 11, 12)) AND (DeptCode = @dept) and iyear = @year

SELECT @OutMoney = sum(Money) 
FROM budget_change_Sheet
WHERE (OutSubject = @subjectcode ) AND (Imonth IN (10, 11, 12)) AND (DeptCode = @dept) and iyear = @year

end

select @changemoney =  isnull(@InMoney,0.00) - isnull(@OutMoney,0.00)  


GO

GRANT EXEC ON b_getQuarterBudgetChange TO PUBLIC

GO
