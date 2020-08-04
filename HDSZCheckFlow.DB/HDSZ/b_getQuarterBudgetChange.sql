IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'b_getQuarterBudgetChange')
	BEGIN
		PRINT 'Dropping Procedure b_getQuarterBudgetChange'
		DROP  Procedure  b_getQuarterBudgetChange
	END

GO

PRINT 'Creating Procedure b_getQuarterBudgetChange'
GO
CREATE Procedure b_getQuarterBudgetChange
	@year int,                   -- ��
	@quarter int,                -- ����
	@dept varchar(50),           -- ����
	@subjectcode varchar(50),     -- ��Ŀ
	@changemoney decimal output   --���ز���(�������)
AS

/******************************************************************************

**		Desc: ��ÿ�Ŀ���ȵ������
**
*******************************************************************************/

declare @InMoney decimal
declare @OutMoney decimal 

set @InMoney = 0.00
set @OutMoney = 0.00
-- 1. ת���� - ת����� 
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
