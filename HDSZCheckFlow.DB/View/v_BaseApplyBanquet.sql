CREATE VIEW dbo.v_BaseApplyBanquet AS 
SELECT dbo.ApplySheetHead.ApplySheetNo, dbo.Base_Person.Name, dbo.Base_Dept.DeptName, dbo.ApplySheetHead.ApplyDate,
 dbo.ApplySheetHead.ApplySheetHead_Pk, dbo.Base_AccountSubject.subjectCode, dbo.Base_AccountSubject.Dispname, dbo.ApplySheetHead.DeliveryDate,
  dbo.ApplySheetBody_Banquet.DateFrom, dbo.ApplySheetBody_Banquet.DateTo, dbo.ApplySheetBody_Banquet.CallinCompany,
   dbo.ApplySheetBody_Banquet.CallinPerson, dbo.ApplySheetBody_Banquet.CallinMemo, dbo.ApplySheetBody_Banquet.inviteDept, 
   dbo.ApplySheetBody_Banquet.invitePerson, dbo.ApplySheetBody_Banquet.invietDeptInfo, dbo.ApplySheetBody_Banquet.relationDept,
    dbo.ApplySheetBody_Banquet.talkplace, CASE dbo.ApplySheetBody_Banquet.needTea WHEN 1 THEN '需要' ELSE '不需要' END AS needTea,
    CASE dbo.ApplySheetBody_Banquet.lookFactory WHEN 1 THEN '是' ELSE '否' END AS lookFactory, dbo.ApplySheetBody_Banquet.numofvisit,
    CASE dbo.ApplySheetBody_Banquet.lunch WHEN 1 THEN '食堂' ELSE '' END AS lunch, dbo.ApplySheetBody_Banquet.other, 
    CASE dbo.ApplySheetBody_Banquet.carplan WHEN 1 THEN '接' WHEN 2 THEN '送' WHEN 3 THEN '往返' ELSE '无' END AS carplan, 
    dbo.ApplySheetBody_Banquet.especialRequest, dbo.ApplySheetBody_Pay.Item, dbo.ApplySheetBody_Pay.Money, dbo.ApplySheetBody_Pay.currTypeCode,
     dbo.ApplySheetBody_Pay.ExchangeRate, dbo.ApplySheetBody_Pay.originalcurrPrice, dbo.ApplySheetHead.ApplyPersonCode FROM dbo.ApplySheetHead_Budget
      INNER JOIN dbo.ApplySheetHead INNER JOIN dbo.Base_Person ON dbo.ApplySheetHead.ApplyPersonCode = dbo.Base_Person.personCode INNER JOIN
       dbo.Base_Dept ON dbo.ApplySheetHead.ApplyDeptCode = dbo.Base_Dept.DeptCode ON dbo.ApplySheetHead_Budget.ApplySheetHead_Pk = 
       dbo.ApplySheetHead.ApplySheetHead_Pk INNER JOIN dbo.Base_AccountSubject ON dbo.ApplySheetHead_Budget.SheetSubject = 
       dbo.Base_AccountSubject.subjectCode INNER JOIN dbo.ApplySheetBody_Banquet ON dbo.ApplySheetHead.ApplySheetHead_Pk =
        dbo.ApplySheetBody_Banquet.ApplySheetHead_Pk INNER JOIN dbo.ApplySheetBody_Pay ON dbo.ApplySheetHead.ApplySheetHead_Pk = 
        dbo.ApplySheetBody_Pay.ApplySheetHead_Pk 
