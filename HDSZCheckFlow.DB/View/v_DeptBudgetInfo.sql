CREATE VIEW dbo.v_DeptBudgetInfo
AS
SELECT budget_account_pk, dbo.budget_account.Iyear, dbo.budget_account.Imonth, 
      dbo.Base_NC_Dept.budget_DeptCode, dbo.Base_NC_Dept.NC_DeptName, 
      dbo.Base_AccountSubject.subjectCode, dbo.Base_AccountSubject.subjectName, Base_AccountSubject.dispname,
      dbo.budget_account.budgetMoney, dbo.budget_account.PlanMoney, 
      dbo.budget_account.CheckMoney, aa.InMoney, bb.OutMoney, ISNULL(aa.InMoney, 0) 
      - ISNULL(bb.OutMoney, 0) AS changeMoney, isnull(dbo.budget_account.readypay,0) as readypay, isnull(dbo.budget_account.TotalAllowOutMoney,0) as TotalAllowOutMoney,
      dbo.budget_account.budgetMoney +  isnull(dbo.budget_account.TotalAllowOutMoney,0)  - dbo.budget_account.CheckMoney - isnull(dbo.budget_account.readypay,0) + ISNULL(aa.InMoney,
       0) - ISNULL(bb.OutMoney, 0) AS leftMoney
FROM dbo.budget_account INNER JOIN
      dbo.Base_AccountSubject ON 
      dbo.budget_account.SubjectCode = dbo.Base_AccountSubject.subjectCode INNER JOIN
      dbo.Base_NC_Dept ON 
      dbo.budget_account.deptCode = dbo.Base_NC_Dept.budget_DeptCode LEFT OUTER JOIN
          (SELECT Iyear, Imonth, DeptCode, InSubject, SUM(Money) AS InMoney
         FROM budget_change_Sheet
         GROUP BY Iyear, Imonth, DeptCode, InSubject) aa ON 
      aa.Iyear = dbo.budget_account.Iyear AND 
      aa.Imonth = dbo.budget_account.Imonth AND 
      aa.DeptCode = dbo.budget_account.deptCode AND 
      aa.InSubject = dbo.budget_account.SubjectCode LEFT OUTER JOIN
          (SELECT Iyear, Imonth, DeptCode, OutSubject, SUM(Money) AS OutMoney
         FROM budget_change_Sheet
         GROUP BY Iyear, Imonth, DeptCode, OutSubject) bb ON 
      bb.Iyear = dbo.budget_account.Iyear AND 
      bb.Imonth = dbo.budget_account.Imonth AND 
      bb.DeptCode = dbo.budget_account.deptCode AND 
      bb.OutSubject = dbo.budget_account.SubjectCode









