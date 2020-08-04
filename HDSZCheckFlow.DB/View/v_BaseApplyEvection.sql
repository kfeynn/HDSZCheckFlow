CREATE VIEW dbo.v_BaseApplyEvection AS 
SELECT dbo.ApplySheetHead.ApplySheetNo, dbo.Base_Person.Name, dbo.Base_Dept.DeptName, 
dbo.ApplySheetHead.ApplyDate, dbo.ApplySheetHead.ApplySheetHead_Pk, dbo.ApplySheetBody_EvectionCharge.Money,
 dbo.Base_AccountSubject.subjectCode, dbo.Base_AccountSubject.Dispname, dbo.ApplySheetHead.DeliveryDate, 
 dbo.ApplySheetBody_Evection.DateFrom, dbo.ApplySheetBody_Evection.DateTo, dbo.ApplySheetBody_Evection.GoCity,
  dbo.Base_CommonCode.CodeName, dbo.ApplySheetBody_EvectionCharge.currcode, dbo.ApplySheetBody_Evection.EvecionType,
   dbo.ApplySheetBody_Evection.appClass, dbo.ApplySheetBody_Evection.withapps, dbo.ApplySheetBody_Evection.withwho,
    dbo.ApplySheetBody_Evection.appduty, dbo.ApplySheetBody_Evection.preabroaddate, dbo.ApplySheetBody_Evection.prebackdate,
    CASE dbo.ApplySheetBody_Evection.visa WHEN 1 THEN '有' ELSE '无' END AS visa, dbo.ApplySheetBody_Evection.visadate,
     CASE dbo.ApplySheetBody_Evection.passport WHEN 1 THEN '有' ELSE '无' END AS passport, dbo.ApplySheetBody_Evection.passportno, 
     dbo.ApplySheetBody_Evection.passportdate,CASE dbo.ApplySheetBody_Evection.bacterin WHEN 1 THEN '有' ELSE '无' END AS bacterin, 
     dbo.ApplySheetBody_Evection.bacterindate, dbo.ApplySheetBody_Evection.memo, CASE dbo.ApplySheetBody_Evection.limitdartcle 
     WHEN 1 THEN '是' ELSE '否' END AS limitdartcle,CASE dbo.ApplySheetBody_Evection.limittech WHEN 1 THEN '是' ELSE '否' END AS limittech,
      CASE dbo.ApplySheetBody_Evection.checkup WHEN 1 THEN '是' ELSE '否' END AS checkup , dbo.ApplySheetBody_Evection.meetcondition,
       dbo.ApplySheetBody_Evection.checkupdate, dbo.ApplySheetBody_EvectionCharge.ExchangeRate, dbo.ApplySheetBody_EvectionCharge.memo
        AS Evectionmemo, dbo.ApplySheetHead.ApplyPersonCode FROM dbo.ApplySheetHead_Budget INNER JOIN dbo.ApplySheetHead INNER JOIN
         dbo.Base_Person ON dbo.ApplySheetHead.ApplyPersonCode = dbo.Base_Person.personCode INNER JOIN dbo.Base_Dept ON dbo.ApplySheetHead.ApplyDeptCode =
          dbo.Base_Dept.DeptCode ON dbo.ApplySheetHead_Budget.ApplySheetHead_Pk = dbo.ApplySheetHead.ApplySheetHead_Pk INNER JOIN dbo.Base_AccountSubject
           ON dbo.ApplySheetHead_Budget.SheetSubject = dbo.Base_AccountSubject.subjectCode INNER JOIN dbo.ApplySheetBody_Evection ON 
           dbo.ApplySheetHead.ApplySheetHead_Pk = dbo.ApplySheetBody_Evection.ApplySheetHead_Pk INNER JOIN dbo.ApplySheetBody_EvectionCharge 
           ON dbo.ApplySheetHead.ApplySheetHead_Pk = dbo.ApplySheetBody_EvectionCharge.ApplySheetHead_Pk INNER JOIN dbo.Base_CommonCode
            ON dbo.ApplySheetBody_EvectionCharge.ChargePro = dbo.Base_CommonCode.Code 
