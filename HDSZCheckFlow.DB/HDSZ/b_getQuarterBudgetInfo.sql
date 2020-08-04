IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'b_getQuarterBudgetInfo')
	BEGIN
		PRINT 'Dropping Procedure b_getQuarterBudgetInfo'
		DROP  Procedure  b_getQuarterBudgetInfo
	END
GO

PRINT 'Creating Procedure b_getQuarterBudgetInfo'
GO
CREATE Procedure b_getQuarterBudgetInfo
	@year int,                   -- ��
	@quarter int,                -- ����
	@dept varchar(50),           -- ����
	@subjectcode varchar(50)     -- ��Ŀ
AS

/******************************************************************************

**		Desc: ��ȡ���ſ�Ŀ����Ԥ����Ϣ

*******************************************************************************/
declare @months varchar(50)
--������ת��Ϊ �·� �ö��ŷָ�
if @quarter = 1 
begin
	SELECT isnull(sum(budgetmoney),0) as budgetmoney,isnull(sum(planmoney),0) as planmoney,isnull(sum(checkmoney),0) as checkmoney,isnull(sum(readypay),0) as readypay ,isnull(sum(TotalAllowOutMoney),0) as TotalAllowOutMoney FROM budget_account WHERE (Iyear = @year) AND (Imonth IN (1,2,3)) AND (SubjectCode =@subjectcode) AND (deptCode = @dept )
end 

else if @quarter = 2 
begin
	SELECT isnull(sum(budgetmoney),0) as budgetmoney,isnull(sum(planmoney),0) as planmoney,isnull(sum(checkmoney),0) as checkmoney,isnull(sum(readypay),0) as readypay,isnull(sum(TotalAllowOutMoney),0) as TotalAllowOutMoney  FROM budget_account WHERE (Iyear = @year) AND (Imonth IN (4,5,6)) AND (SubjectCode =@subjectcode) AND (deptCode = @dept )
end 

else if @quarter = 3 
begin
	SELECT isnull(sum(budgetmoney),0) as budgetmoney,isnull(sum(planmoney),0) as planmoney,isnull(sum(checkmoney),0) as checkmoney,isnull(sum(readypay),0) as readypay,isnull(sum(TotalAllowOutMoney),0) as TotalAllowOutMoney  FROM budget_account WHERE (Iyear = @year) AND (Imonth IN (7,8,9)) AND (SubjectCode =@subjectcode) AND (deptCode = @dept )
end 

else if @quarter = 4
begin
	SELECT isnull(sum(budgetmoney),0) as budgetmoney,isnull(sum(planmoney),0) as planmoney,isnull(sum(checkmoney),0) as checkmoney,isnull(sum(readypay),0) as readypay,isnull(sum(TotalAllowOutMoney),0) as TotalAllowOutMoney  FROM budget_account WHERE (Iyear = @year) AND (Imonth IN (10,11,12)) AND (SubjectCode =@subjectcode) AND (deptCode = @dept )
end 




GO

GRANT EXEC ON b_getQuarterBudgetInfo TO PUBLIC

GO
