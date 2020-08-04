 SELECT ApplyType.ApplyTypeName, ApplySheetHead.ApplySheetNo, 
       ApplySheetHead.ApplyDate, applySheetCheckRecord.IsPass
 FROM ApplySheetHead INNER JOIN
       ApplyProcessType ON 
       ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode INNER
        JOIN
       ApplyType ON 
       ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
       applySheetCheckRecord ON 
       ApplySheetHead.ApplySheetHead_Pk = applySheetCheckRecord.ApplySheetHead_Pk
 WHERE (ApplyProcessType.IsDisallow = 1)
 
 
 SELECT budget_account.*
 FROM budget_account
 WHERE (deptCode IN
           (SELECT budget_deptcode
          FROM base_dept
          WHERE superior_dept_pk =
                    (SELECT Base_Dept.superior_Dept_pk
                   FROM Base_Person INNER JOIN
                         Base_Dept ON 
                         Base_Person.DeptCode = Base_Dept.DeptCode
                   WHERE (Base_Person.personCode = '084150'))))
                   
                   
                   
                   