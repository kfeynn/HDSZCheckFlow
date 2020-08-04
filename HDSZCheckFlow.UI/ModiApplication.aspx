<%@ Page CodeBehind="ModiApplication.aspx.vb" Language="c#" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.ModiApplication" %>
<%@ import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Sqlclient" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�ͱ���Ʒ���뵥�޸�</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript">
			function GotNameNo1(){
						var deptcode=(window.document.all("DrpDnApplyDeptCodeName").value).substring(0,2);
						var strUrl="SelectPerson.aspx?DeptCode=" + deptcode+"1";
						wins=window.open(strUrl,"��ѡ����Ա","width=550,height=420,top=180, left=320,resizable=No,status=No,toolbar=no,menubar=no,location=no");
								}
			function GotNameNo2(){
						var deptcode=(window.document.all("DrpDnApplyDeptCodeName").value).substring(0,2);
						var strUrl="SelectPerson.aspx?DeptCode=" + deptcode+"2";
						wins=window.open(strUrl,"��ѡ����Ա","width=550,height=420,top=180, left=320,resizable=No,status=No,toolbar=no,menubar=no,location=no");
								}				
			function GotMatId(){
						var strUrl="SelectMatId.aspx";
						wins=window.open(strUrl,"��ѡ������","width=550,height=420,top=180, left=320,resizable=No,status=No,toolbar=no,menubar=no,location=no");
								}
		</SCRIPT>
		<script language="vb" runat="server">
		Sub Page_load(Sender As Object,E as EventArgs)
		   If Not Page.IsPostBack Then
			TxtApplyDate.Text=Format(today(),"yyyy-MM-dd")
			Dim Myconnection As SqlConnection
	    	Dim Mycommand AS SqlCommand
	    	Dim ParaReturnValue As SqlParameter
	    	Dim SelectStr AS String
	    	Dim MyData As SqlDataReader
	    	Dim StrDeptCode As String
	    	Dim strUserId As String
	    	strUserId=Trim(Request.Cookies("Username").Value)
			'���´������ڻ�ȡ���Ŵ���
			Myconnection=New SqlConnection("Server=HDWEB;Uid=LaborUser;Pwd=UserLabor;DataBase=BaseFile")
			MyCommand = New SqlCommand("p_ReturnDeptCode", Myconnection)
            MyCommand.CommandType = CommandType.StoredProcedure

            MyCommand.Parameters.Add("@userid", strUserId)

            ParaReturnValue = MyCommand.Parameters.Add("@DeptCode", SqlDbType.Char)
            ParaReturnValue.Size = 2
            ParaReturnValue.Direction = ParameterDirection.Output


            Myconnection.Open()
            MyCommand.ExecuteNonQuery()
            If Not IsDBNull(MyCommand.Parameters("@DeptCode").Value) Then
                StrDeptCode = MyCommand.Parameters("@DeptCode").Value
            Else
                StrDeptCode = "δ֪"
            End If
            Myconnection.Close()   
				   
    		SelectStr="Select applyid+'   '+applyname As '����������' from tbLaborapply where CkType<>'�ѳ���'and CkType<>'�ѳ���' and CkType<>'δ��׼'and applydeptcode='" & StrDeptCode & "'"
    		Mycommand=New SqlCommand(SelectStr,Myconnection )
       		Myconnection.Open()
    		MyData=Mycommand.ExecuteReader()
    		
    		DrpDMasterId.DataSource=MyData
    		DrpDMasterId.DataTextField="����������"
	    	DrpDMasterId.DataBind()
	    		
	    	Myconnection.Close()
	    	MyData.Close()
	    	
	     '���´���������ʾ�յ�DATAGRID�ؼ�
	      DataGridRefresh()
	    	
	  		End If
	  		
		End Sub		
		Sub ModiMaster_Click(Sender As Object,E as EventArgs)
			If DrpDMasterId.SelectedIndex=-1 Then
				lbMastMessage.Text="��ѡ���ͱ���Ʒ���뵥��"
				lbMastMessage.Style("color") = "Red"
				Return
			Else
				lbMastMessage.Text=""
				lbMastMessage.Style("color") = "Blue"
			End If 
									
			Dim Myconnection As SqlConnection
			Dim SelectCommand As SqlCommand
			Dim paraReturnApplyNameNo AS SqlParameter
			Dim paraReturnApplyName  As SqlParameter
			Dim paraReturnApplyDeptCode As SqlParameter
			Dim paraReturnApplyDate As SqlParameter
			Dim paraReturnMemo As SqlParameter
				
			Myconnection= New SqlConnection("Server=HDWEB;UID=LaborUser;PWD=UserLabor;Database=BaseFile")
			SelectCommand=New SqlCommand("p_ReturnLaborApply",Myconnection)
			SelectCommand.CommandType=Commandtype.StoredProcedure
			
			SelectCommand.Parameters.Add("@mApplyid",Left(Trim(DrpDMasterId.SelectedItem.Value),12))
						
			ParaReturnApplyNameNo=SelectCommand.Parameters.Add("@mApplynameno",SqlDbType.char)
			ParaReturnApplyNameNo.Size=10
			ParaReturnApplyNameNo.Direction=ParameterDirection.Output
			
			ParaReturnApplyName=SelectCommand.Parameters.Add("@mApplyname",SqlDbType.char)
			ParaReturnApplyName.Size=16
			ParaReturnApplyName.Direction=ParameterDirection.Output
			
			ParaReturnApplyDeptCode=SelectCommand.Parameters.Add("@mApplyDeptCode",SqlDbType.char)
			ParaReturnApplyDeptCode.Size=2
			ParaReturnApplyDeptCode.Direction=ParameterDirection.Output
			
			ParaReturnApplyDate=SelectCommand.Parameters.Add("@mApplyDate",SqlDbType.char)
			ParaReturnApplyDate.Size=10
			ParaReturnApplyDate.Direction=ParameterDirection.Output
			
			ParaReturnMemo=SelectCommand.Parameters.Add("@mMemo",SqlDbType.char)
			ParaReturnMemo.Size=80
			ParaReturnMemo.Direction=ParameterDirection.Output			
			
			Myconnection.Open()
			SelectCommand.ExecuteNonQuery()
			Myconnection.Close()
			If Not IsDbNull (SelectCommand.Parameters("@mApplyid").Value) then
				txtApplyId.text=SelectCommand.Parameters("@mApplyid").Value
			Else
				lbMastMessage.Text="������ĳ�����벻����"
				lbMastMessage.Style("color") = "Red"
				Return
			End if	
			
					
			txtApplyName.text=SelectCommand.Parameters("@mApplyname").Value
			txtApplyNameno.text=SelectCommand.Parameters("@mApplynameno").Value
			DrpDnApplyDeptCodeName.Selectedindex=SelectCommand.Parameters("@mApplyDeptCode").Value
			TxtApplyDate.text=SelectCommand.Parameters("@mApplyDate").Value
			TxtMemo.text=SelectCommand.Parameters("@mMemo").Value
			
			
			DataGridRefresh()
							
			lbMastMessage.Text="�������ɹ�,���޸�"
			lbMastMessage.Style("color") = "Blue"	  
						
				
				' DrpDnApplyDeptCodeName.Enabled=True
				TxtApplyDate.Enabled=True
                BtnGotNameNo1.Disabled=False
                BtnGotNameNo2.Disabled=True
                BtnGotMatId.Disabled=True
                txtApplynumber.Enabled=False
                btnSaveMaster.Enabled=True                
                btnAddDetail.Enabled=False
                btnSaveDetail.Enabled=False
                btnDeleDetail.Enabled=False
                btnModiDetail.Enabled=False
                
        End Sub		
		Sub BtnSaveMaster_Click(Sender As Object,E as EventArgs)
				  If Trim(TxtApplyid.Text)="" Then
						lbMastMessage.Text="��ѡ��Ҫ�޸ĵĵ���"
						 lbMastMessage.Style("color") = "Red" 
						 Return
				  End If		 
				  If TxtApplyNameno.Text="��ѡ��" or TxtApplyNameno.Text="" Then
						 lbMastMessage.Text="��ѡ��������"
						 lbMastMessage.Style("color") = "Red" 
						 Return
				  End if	
				  If Trim(TxtApplyDate.Text)="" Then
						 lbMastMessage.Text="��������������"
						 lbMastMessage.Style("color") = "Red" 
						 Return
				  End If		 
				  If True Then
						lbDetailMessage.Text=""
						lbDetailMessage.Style("color") = "Blue" 
				  End If		
						
					lbDetailMessage.Text=""
					lbDetailMessage.Style("color")="Blue"
			    Dim strPageId As String
		        Dim Myconnection As SqlConnection
				Dim ParaReturnValue As SqlParameter
				Dim StrResult As String
				Dim UpdateStr As String
				Dim Mycommand As SqlCommand
				
				Myconnection = New SqlConnection("Server=HDWEB;UID=LaborUser;PWD=UserLabor;Database=BaseFile")	
				
			
				'���´������ڽ���������е����ݽ����޸�
    			 UpdateStr = "UpDate tbLaborApply Set applynameno=@mapplynameno,applyname=@mapplyname,applydate=@mapplydate,inputdate=@minputdate,Memo=@mMemo where applyid='" & trim(TxtApplyid.Text) & "'"
				 MyCommand = New SqlCommand(UpdateStr, Myconnection)

				MyCommand.Parameters.Add(New SqlParameter("@mapplyid", SqlDbType.NVarChar, 12))
				MyCommand.Parameters("@mapplyid").Value = Trim(txtApplyId.Text)
				MyCommand.Parameters.Add(New SqlParameter("@mapplynameno", SqlDbType.NVarChar, 10))
				MyCommand.Parameters("@mapplynameno").Value = Trim(TxtApplyNameno.Text)
				MyCommand.Parameters.Add(New SqlParameter("@mapplyname", SqlDbType.NVarChar, 14))
				MyCommand.Parameters("@mapplyname").Value = Trim(txtApplyName.Text)
				MyCommand.Parameters.Add(New SqlParameter("@mapplyDate", SqlDbType.NVarChar, 10))
				MyCommand.Parameters("@mapplyDate").Value = TxtApplyDate.Text
				MyCommand.Parameters.Add(New SqlParameter("@minputDate", SqlDbType.NVarChar, 10))
				MyCommand.Parameters("@minputDate").Value = Format(today(),"yyyy-MM-dd")
				MyCommand.Parameters.Add(New SqlParameter("@mMemo", SqlDbType.NVarChar, 80))
				MyCommand.Parameters("@mMemo").Value = Trim(TxtMemo.Text)
			    Myconnection.Open()
					 MyCommand.ExecuteNonQuery()
                Myconnection.Close()
                
           '���´��������ж��Ƿ��ύ����������Ӧ���޸�
            MyCommand=New SqlCommand("p_ReturnLaborStep",Myconnection)
			MyCommand.CommandType=Commandtype.StoredProcedure
			
			MyCommand.Parameters.Add("@mApplyid",TxtApplyId.Text)
			
			ParaReturnValue=MyCommand.Parameters.Add("@mCktype",SqlDbType.char)
			ParaReturnValue.Size=8
			ParaReturnValue.Direction=ParameterDirection.Output
			
			
			Myconnection.Open()
				MyCommand.ExecuteNonQuery()
			Myconnection.Close()
			If Trim(MyCommand.Parameters("@mCktype").Value)<>"δ����" Then
				'���´��뽫���ݵ�״̬���»ظ�Ϊδ�ʽ�
				MyCommand = New SqlCommand("UpDate tbLaborApply Set DeptApprove='',DeptApproveDate='',ZwApprove='',ZwApproveDate='',ZcApprove='',ZcApproveDate='',Cktype='δ����' where applyid='" & trim(TxtApplyid.Text) & "'", MyConnection)
				Myconnection.Open()
					MyCommand.ExecuteNonQuery()
				Myconnection.Close()
				lbMastMessage.Text="���ĵ������޸�,�������ύ����"
				lbMastMessage.Style("color") = "Blue"
			Else 	
                lbMastMessage.Text="���޸�������ϸ��"
				lbMastMessage.Style("color") = "Blue" 
			End If 	
                DrpDnApplyDeptCodeName.Enabled=False
                TxtApplyDate.Enabled=False
                BtnGotNameNo1.Disabled=True
                btnSaveMaster.Enabled=False
                btnAddDetail.Enabled=True
                				
			End Sub
				Sub BtnDetect_Click(Sender As Object,E as EventArgs)
				   If txtMatId.Text="��ѡ��" Or txtMatId.Text="" Then
						 lbDetailMessage.Text="��ѡ�����Ϻ�"
						 lbDetailMessage.Style("color") = "Red" 
						 Return
				   End if	
				   If TxtGotNameNo.Text="��ѡ��" Or TxtGotNameNo.Text="" Then
						 lbDetailMessage.Text="��ѡ��������"
						 lbDetailMessage.Style("color") = "Red"
						 Return
				   End If
				   DetectFunction()
			End Sub
			Sub DetectFunction()
				Dim Myconnection As SqlConnection
				Dim SelectCommand As SqlCommand
				Dim ParaReturnValue As SqlParameter
				'���´������ڼ���������Ƿ������������
				Myconnection = New SqlConnection("Server=HDWEB;UID=LaborUser;PWD=UserLabor;Database=BaseFile")
				SelectCommand = New SqlCommand("p_MeetRuleNew", Myconnection)
				SelectCommand.CommandType = CommandType.StoredProcedure

				SelectCommand.Parameters.Add("@mNameNo", Trim(txtGotNameNo.Text))
				SelectCommand.Parameters.Add("@mMatId", Trim(txtMatId.Text))
				SelectCommand.Parameters.Add("@mApplyNum",Cint(Trim(txtApplynumber.Text)))

				ParaReturnValue = SelectCommand.Parameters.Add("@mMeetRule", SqlDbType.Char)
				ParaReturnValue.Size = 1
				ParaReturnValue.Direction = ParameterDirection.Output
				
				ParaReturnValue = SelectCommand.Parameters.Add("@mMessage", SqlDbType.Char)
				ParaReturnValue.Size = 20
				ParaReturnValue.Direction = ParameterDirection.Output

				ParaReturnValue = SelectCommand.Parameters.Add("@mLastGotDate", SqlDbType.Char)
				ParaReturnValue.Size = 15
				ParaReturnValue.Direction = ParameterDirection.Output
				
				ParaReturnValue = SelectCommand.Parameters.Add("@mSynx", SqlDbType.Char)
				ParaReturnValue.Size = 2
				ParaReturnValue.Direction = ParameterDirection.Output
				Myconnection.Open()
				SelectCommand.ExecuteNonQuery()
					If SelectCommand.Parameters("@mMeetRule").Value="Y"
					  lbDetailMessage.Text=Trim(SelectCommand.Parameters("@mMessage").Value)
					  lbDetailMessage.Style("color") = "Blue"
					Else
					  lbDetailMessage.Text=Trim(SelectCommand.Parameters("@mMessage").Value)
					  lbDetailMessage.Style("color") = "Red"					
					End If  
					If Trim(SelectCommand.Parameters("@mLastGotDate").Value)="" then
						txtLastGotDate.Text=""
					Else	
						txtLastGotDate.Text=Format(CDate(Trim(SelectCommand.Parameters("@mLastGotDate").Value)),"yyyy-MM-dd")
					End If	
					txtSynx.Text=SelectCommand.Parameters("@mSynx").Value
					Myconnection.Close()
			End Sub
			Sub Save_Detail(Sender As Object,E as EventArgs)
				   If txtMatId.Text="��ѡ��" Or txtMatId.Text="" Then
						 lbDetailMessage.Text="��ѡ�����Ϻ�"
						 lbDetailMessage.Style("color") = "Red" 
						 Return
				   End if	
				   If TxtGotNameNo.Text="��ѡ��" Or TxtGotNameNo.Text="" Then
						 lbDetailMessage.Text="��ѡ��������"
						 lbDetailMessage.Style("color") = "Red"
						 Return
				   End If
				   If txtApplyNumber.Text=" " or txtApplyNumber.Text="  " or txtApplyNumber.Text="   " Then 
						 lbDetailMessage.Text="��������������"
						 lbDetailMessage.Style("color") = "Red"
						 Return
				   End If	
				   If txtApplyNumber.Text=""  Then 
						 lbDetailMessage.Text="��������������"
						 lbDetailMessage.Style("color") = "Red"
						 Return
				   End If	 
				   
				   If  txtApplyNumber.Text=0 Then
						 lbDetailMessage.Text="��������������"
						 lbDetailMessage.Style("color") = "Red"
						 Return
				   End If
				   If TxtApplyNameno.Text="��ѡ��" or TxtApplyNameno.Text="" Then
						 lbMastMessage.Text="��ѡ��������"
						 lbMastMessage.Style("color") = "Red" 
						 Return
				   End if	
				   
			DetectFunction()   
				   
			IF btnFunction.Text="Add" Then   '������������ܾ�ִ�����³���
			
				 If cint(txtApplyNumber.Text)>cint(txtMatAvailablenumber.Text) Then
						 lbDetailMessage.Text="���ÿ�治��"
						 lbDetailMessage.Style("color") = "Red"
						 Return
				 End If
				
				
				
			    Dim strDetailId As String
		        Dim Myconnection As SqlConnection
		        Dim MyTransaction As SqlTransaction
				Dim SelectCommand As SqlCommand
				Dim ParaReturnValue As SqlParameter
				Dim InsertCommand As SqlCommand
				Dim DeductCommand As SqlCommand
				Dim strInsert As String
				Dim strDeduct As String

			'���´�������������ϸ������ϸ����
				Myconnection = New SqlConnection("Server=HDWEB;UID=LaborUser;PWD=UserLabor;Database=BaseFile")
				SelectCommand = New SqlCommand("p_ReturnLBDetailId", Myconnection)
				SelectCommand.CommandType = CommandType.StoredProcedure

				SelectCommand.Parameters.Add("@LBid", Trim(txtApplyId.Text))

				ParaReturnValue = SelectCommand.Parameters.Add("@ReturnId", SqlDbType.Char)
				ParaReturnValue.Size = 3
				ParaReturnValue.Direction = ParameterDirection.Output
				Myconnection.Open()
				SelectCommand.ExecuteNonQuery()
				If  SelectCommand.Parameters("@ReturnId").Value="err" Then
				   lbDetailMessage.Text="��¼�Ѵﵽ�����"
				   lbDetailMessage.Style("color") = "Red"
				   Return
				Else
					TxtDetailId.Text= SelectCommand.Parameters("@ReturnId").Value
				End If
				Myconnection.Close()
				
				'���´������ڲ��������¼
				 StrInsert = "Insert into tbDrawDetail Values(@mapplyid,@mdetailid,@mgotnameno,@mgotname,@mmatid,@mapplynumber,@mgotdate,@mMeetRule,@mlastgotdate,@msynx)"
				 InsertCommand = New SqlCommand(StrInsert, Myconnection)

				InsertCommand.Parameters.Add(New SqlParameter("@mapplyid", SqlDbType.NVarChar, 12))
				InsertCommand.Parameters("@mapplyid").Value = Trim(txtApplyId.Text)
				InsertCommand.Parameters.Add(New SqlParameter("@mdetailid", SqlDbType.NVarChar, 3))
				InsertCommand.Parameters("@mdetailid").Value = Trim(TxtDetailId.Text)
				InsertCommand.Parameters.Add(New SqlParameter("@mgotnameno", SqlDbType.NVarChar, 10))
				InsertCommand.Parameters("@mgotnameno").Value = Trim(TxtGotnameNo.Text)
				InsertCommand.Parameters.Add(New SqlParameter("@mgotname", SqlDbType.NVarChar, 14))
				InsertCommand.Parameters("@mgotname").Value = Trim(TxtGotname.Text)
				InsertCommand.Parameters.Add(New SqlParameter("@mmatid", SqlDbType.NVarChar, 10))
				InsertCommand.Parameters("@mmatid").Value = Trim(Txtmatid.Text)
				InsertCommand.Parameters.Add(New SqlParameter("@mapplynumber", SqlDbType.int, 10))
				InsertCommand.Parameters("@mapplynumber").Value = TxtApplyNumber.Text
				InsertCommand.Parameters.Add(New SqlParameter("@mgotdate", SqlDbType.char, 10))
				InsertCommand.Parameters("@mgotdate").Value = ""
				InsertCommand.Parameters.Add(New SqlParameter("@mMeetRule", SqlDbType.char, 20))
				InsertCommand.Parameters("@mMeetRule").Value = Trim(lbDetailMessage.Text)
				InsertCommand.Parameters.Add(New SqlParameter("@mlastgotdate", SqlDbType.char, 15))
				InsertCommand.Parameters("@mlastgotdate").Value = Trim(TxtLastGotDate.Text)
				InsertCommand.Parameters.Add(New SqlParameter("@msynx", SqlDbType.char, 2))
				InsertCommand.Parameters("@mSynx").Value = Trim(TxtSynx.Text)
				
				'���´������ڼ�ȥ���ÿ��
				 StrDeduct = "Update tbStock Set availablenumber=availablenumber-" & Trim(TxtApplyNumber.Text) & " Where matId='" & Trim(TxtMatId.Text) & "'"
				 DeductCommand = New SqlCommand(StrDeduct, Myconnection)
			
				'���´�������ִ��ʵ�ʵ�SQL SERVER����	

			Try
		        Myconnection.Open()
					 MyTransaction=Myconnection.BeginTransaction
					 InsertCommand.Transaction=MyTransaction
					 DeductCommand.Transaction=MyTransaction
					 InsertCommand.ExecuteNonQuery()
            		 DeductCommand.ExecuteNonQuery()
            		 MyTransaction.Commit
				Myconnection.Close()

			Catch Ex As Exception	
				lbDetailMessage.Text=Ex.Message
				lbDetailMessage.Style("color") = "Red"
				Return
			End Try	
				'�ѿ��ÿ�����ڽ����ϼ�����
				txtMatAvailablenumber.Text=txtMatAvailablenumber.Text-txtApplyNumber.Text
				
				DataGridRefresh() '����DataGrid�е�����
					
				
				BtnAddDetail.Enabled=True
				BtnSaveDetail.Enabled=False
				BtnDeleDetail.Enabled=False
				BtnModiDetail.Enabled=False
								
				
				BtnGotNameNo2.Disabled=True
                BtnGotMatId.Disabled=True
                txtApplynumber.Enabled=False
				
				lbDetailMessage.Text="����ɹ�"
				lbDetailMessage.Style("color") = "Blue"
		     ELse   '������޸ĵĻ�ִ�����³���
		     
		     '�޸ĳ����У����ֻ���޸���������ִ�����µĳ���������޸������ϣ��������Լ򵥣�
		     'ֻ�ǽ�ԭ���ϵ�ԭ��������ȥ���������ϵ�����������������
		     
		     if Trim(TxtMatId.Text)=Trim(TxtMatIdB4Modi.Text) '���û���޸����ϣ�ֻ���޸�����
				'���³������޸Ĺ��ܣ����ȼ�����������������������Ǽ�������������
				'�����ݼӼ��������ݴӶ���֪�Ƿ��Ǽӿ��ÿ�滹�Ǽ����ÿ�棬�����
				'�ó����ÿ���Ƿ���
				 
				Dim StringAorD As String
					StringAorD=TxtNumB4Modi.Text-TxtApplyNumber.Text '����������Ǽ������������ӿ�棬����Ǹ��������������������				
				If Cint(StringAorD)<0 and (-Cint(StringAorD))>Cint(txtMatAvailablenumber.Text)    '�����������Ҫ�жϿ���Ƿ��㹻
					lbDetailMessage.Text="���ÿ�治��"
					lbDetailMessage.Style("color") = "Red"
					Return
				End If	
					
		        Dim strDetailId As String
		        Dim Myconnection As SqlConnection
		        Dim MyTransaction As SqlTransaction
				Dim SelectCommand As SqlCommand
				Dim ParaReturnValue As SqlParameter
				Dim ModiCommand As SqlCommand
				Dim DeductCommand As SqlCommand
				Dim strModi As String
				Dim strDeduct As String

				
				Myconnection = New SqlConnection("Server=HDWEB;UID=LaborUser;PWD=UserLabor;Database=BaseFile")
				'���´��������޸�������ϸ��¼
				 StrModi = "UpDate tbDrawDetail Set gotnameno=@mgotnameno,gotname=@mgotname,matid=@mmatid,applynumber=@mapplynumber,meetrule=@mmeetrule,lastgotdate=@mlastgotdate,synx=@msynx Where applyid='" & Trim(txtApplyId.Text) & "' and detailId='" & Trim(TxtDetailId.Text) & "'"
				 ModiCommand = New SqlCommand(StrModi, Myconnection)

				ModiCommand.Parameters.Add(New SqlParameter("@mapplyid", SqlDbType.NVarChar, 12))
				ModiCommand.Parameters("@mapplyid").Value = Trim(txtApplyId.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mdetailid", SqlDbType.NVarChar, 3))
				ModiCommand.Parameters("@mdetailid").Value = Trim(TxtDetailId.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mgotnameno", SqlDbType.NVarChar, 10))
				ModiCommand.Parameters("@mgotnameno").Value = Trim(TxtGotnameNo.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mgotname", SqlDbType.NVarChar, 14))
				ModiCommand.Parameters("@mgotname").Value = Trim(TxtGotname.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mmatid", SqlDbType.NVarChar, 10))
				ModiCommand.Parameters("@mmatid").Value = Trim(Txtmatid.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mapplynumber", SqlDbType.int, 10))
				ModiCommand.Parameters("@mapplynumber").Value = TxtApplyNumber.Text
				ModiCommand.Parameters.Add(New SqlParameter("@mMeetRule", SqlDbType.char, 20))
				ModiCommand.Parameters("@mMeetRule").Value = Trim(lbDetailMessage.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mlastgotdate", SqlDbType.char, 15))
				ModiCommand.Parameters("@mlastgotdate").Value = Trim(TxtLastGotDate.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@msynx", SqlDbType.char, 2))
				ModiCommand.Parameters("@mSynx").Value = Trim(TxtSynx.Text)
				
				'���´������ڼ�ȥ���ÿ��
				 StrDeduct = "Update tbStock Set availablenumber=availablenumber+" & StringAorD & " Where matId='" & Trim(TxtMatId.Text) & "'"
				 DeductCommand = New SqlCommand(StrDeduct, Myconnection)
			
				'���´�������ִ��ʵ�ʵ�SQL SERVER����	
		        Myconnection.Open()
					 MyTransaction=Myconnection.BeginTransaction
					 ModiCommand.Transaction=MyTransaction
					 DeductCommand.Transaction=MyTransaction
					 ModiCommand.ExecuteNonQuery()
            		 DeductCommand.ExecuteNonQuery()
            		 MyTransaction.Commit
				Myconnection.Close()
				
				'�ѿ��ÿ�����ڽ����ϼ�����
				txtMatAvailablenumber.Text=CStr(Cint(txtMatAvailablenumber.Text)+Cint(StringAorD))
				
				DataGridRefresh() '����DataGrid�е�����
					
			Else '������
				
				
			 If cint(txtApplyNumber.Text)>cint(txtMatAvailablenumber.Text) Then
						 lbDetailMessage.Text="���ÿ�治��"
						 lbDetailMessage.Style("color") = "Red"
						 Return
		     End If
		
			    Dim strDetailId As String
		        Dim Myconnection As SqlConnection
		        Dim MyTransaction As SqlTransaction
				Dim SelectCommand As SqlCommand
				Dim ParaReturnValue As SqlParameter
				Dim ModiCommand As SqlCommand
				Dim AddCommand As SqlCommand
				Dim DeductCommand As SqlCommand
				Dim strModi As String
				Dim StrAdd As String 
				Dim strDeduct As String

				
				Myconnection = New SqlConnection("Server=HDWEB;UID=LaborUser;PWD=UserLabor;Database=BaseFile")
				'���´��������޸�������ϸ��¼
				 StrModi = "UpDate tbDrawDetail Set gotnameno=@mgotnameno,gotname=@mgotname,matid=@mmatid,applynumber=@mapplynumber,meetrule=@mmeetrule,lastgotdate=@mlastgotdate,synx=@msynx Where applyid='" & Trim(txtApplyId.Text) & "' and detailId='" & Trim(TxtDetailId.Text) & "'"
				 ModiCommand = New SqlCommand(StrModi, Myconnection)

				ModiCommand.Parameters.Add(New SqlParameter("@mapplyid", SqlDbType.NVarChar, 12))
				ModiCommand.Parameters("@mapplyid").Value = Trim(txtApplyId.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mdetailid", SqlDbType.NVarChar, 3))
				ModiCommand.Parameters("@mdetailid").Value = Trim(TxtDetailId.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mgotnameno", SqlDbType.NVarChar, 10))
				ModiCommand.Parameters("@mgotnameno").Value = Trim(TxtGotnameNo.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mgotname", SqlDbType.NVarChar, 14))
				ModiCommand.Parameters("@mgotname").Value = Trim(TxtGotname.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mmatid", SqlDbType.NVarChar, 10))
				ModiCommand.Parameters("@mmatid").Value = Trim(Txtmatid.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mapplynumber", SqlDbType.int, 10))
				ModiCommand.Parameters("@mapplynumber").Value = TxtApplyNumber.Text
				ModiCommand.Parameters.Add(New SqlParameter("@mMeetRule", SqlDbType.char, 20))
				ModiCommand.Parameters("@mMeetRule").Value = Trim(lbDetailMessage.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@mlastgotdate", SqlDbType.char, 15))
				ModiCommand.Parameters("@mlastgotdate").Value = Trim(TxtLastGotDate.Text)
				ModiCommand.Parameters.Add(New SqlParameter("@msynx", SqlDbType.char, 2))
				ModiCommand.Parameters("@mSynx").Value = Trim(TxtSynx.Text)
				
				'���´������ڼ��Ͼ����ϵĿ��ÿ��
				 StrAdd = "Update tbStock Set availablenumber=availablenumber+" & Trim(TxtNumB4Modi.Text) & " Where matId='" & Trim(TxtMatIdB4Modi.Text) & "'"
				 AddCommand = New SqlCommand(StrAdd, Myconnection)
				 
				'���´������ڼ�ȥ�����ϵĿ��ÿ��
				 StrDeduct = "Update tbStock Set availablenumber=availablenumber-" & Trim(TxtApplyNumber.Text) & " Where matId='" & Trim(TxtMatId.Text) & "'"
				 DeductCommand = New SqlCommand(StrDeduct, Myconnection)
			
				'���´�������ִ��ʵ�ʵ�SQL SERVER����	
			Try
		        Myconnection.Open()
					 MyTransaction=Myconnection.BeginTransaction
					 ModiCommand.Transaction=MyTransaction
					 AddCommand.Transaction=MyTransaction
					 DeductCommand.Transaction=MyTransaction
					 ModiCommand.ExecuteNonQuery()
					 AddCommand.ExecuteNonQuery()
            		 DeductCommand.ExecuteNonQuery()
            		 MyTransaction.Commit
				Myconnection.Close()
				
			Catch Ex As Exception	
				lbDetailMessage.Text=Ex.Message
				lbDetailMessage.Style("color") = "Red"
				Return
			End Try	
				'�ѿ��ÿ�����ڽ����ϼ�����
				txtMatAvailablenumber.Text=CStr(Cint(txtMatAvailablenumber.Text)-Cint(txtApplyNumber.Text))
				
				DataGridRefresh() '����DataGrid�е�����
				
			End If '�����ϻ��Ǹ���������
				
				BtnAddDetail.Enabled=True
				BtnSaveDetail.Enabled=False
				BtnDeleDetail.Enabled=False
				BtnModiDetail.Enabled=False
				
				BtnGotNameNo2.Disabled=True
                BtnGotMatId.Disabled=True
                txtApplynumber.Enabled=False
                
				lbDetailMessage.Text="�޸ĳɹ�"
				lbDetailMessage.Style("color") = "Blue"
				
			 End If '�޸Ļ�����������
			End Sub
			Sub DataGridRefresh()
				
				'���´��������ڱ������ʾ���������ϸ
					Dim MyConnection As SqlConnection
					Dim MyAdapter As SqlDataAdapter
					Dim DS As DataSet
					Dim DtTable As DataTable
					Dim DView As DataView
					Dim CmdStr As String
					Myconnection = New SqlConnection("Server=HDWEB;UID=LaborUser;PWD=UserLabor;Database=BaseFile")
					MyConnection.Open()
		            CmdStr = "Select applyId as '���뵥��',DetailId As '��ϸ����',GotNameNo  As '�����˹���',GotName As '����������',tbDrawdetail.MatId As '���Ϻ�',ApplyNumber As '��������',MeetRule As '�������',LastGotDate As '�ϴ�����',Synx As 'ʹ������(��)',MatName As '������',MatSize As '��С',MatSex As '���',MatUnit As '��λ',AmountLeft As '�����',availablenumber As '��ʹ����',Price As '����' from tbDrawDetail,tbStock " & "Where tbDrawDetail.MatId=tbStock.MatId and Applyid='" & Trim(TxtApplyId.Text) & "' order by DetailId" 
		            MyAdapter = New SqlDataAdapter(CmdStr, MyConnection)
					DS = New DataSet
					MyAdapter.Fill(DS, "DetailList")
					DtTable = DS.Tables("DetailList")
					DView = DtTable.DefaultView
					MyDataGrid.DataSource = DView
					MyDataGrid.DataBind()
					MyConnection.Close()
			End Sub					
			Sub btnAddDetail_Click(Sender As Object,E as EventArgs)
				txtApplyNumber.Text=0
				txtGotNameNo.Text=""
				txtGotName.Text=""
				txtDetailId.Text="�Զ�����"
    			TxtMatId.Text=""
				TxtMatName.Text=""
				TxtMatSize.Text=""
				TxtMatSex.Text=""
				TxtMatUnit.Text=""
				TxtMatAmountLeft.Text=""
				TxtMatavailableNumber.Text=""		
				TxtPrice.Text=""	
				
				BtnSaveDetail.Enabled=True
				BtnAddDetail.Enabled=False
				txtApplyNumber.Text=0
				lbDetailMessage.Text="������"
				lbDetailMessage.Style("color") = "Blue"
				BtnGotNameNo2.Disabled=False
                BtnGotMatId.Disabled=False
                txtApplynumber.Enabled=True
                BtnAddDetail.Enabled=False
                BtnFunction.Text="Add"
                
			End Sub
			Sub btnDeleDetail_Click(Sender As Object,E as EventArgs)
				'���´�������ɾ��������ϸ�����ӿ��
				Dim strDetailId As String
		        Dim Myconnection As SqlConnection
		        Dim MyTransaction As SqlTransaction
				Dim SelectCommand As SqlCommand
				Dim ParaReturnValue As SqlParameter
				Dim DeleCommand As SqlCommand
				Dim AddCommand As SqlCommand
				Dim strDele As String
				Dim strAdd As String
				
				 Myconnection = New SqlConnection("Server=HDWEB;UID=LaborUser;PWD=UserLabor;Database=BaseFile")
				
				'���´�������ɾ�������¼
				 StrDele ="Delete from tbDrawDetail  Where applyid='" & Trim(txtApplyId.Text) & "' and detailId='" & Trim(TxtDetailId.Text) & "'"
				 DeleCommand = New SqlCommand(StrDele, Myconnection)
						
				
				'���´����������ӿ��ÿ��
				 StrAdd = "Update tbStock Set availablenumber=availablenumber+" & Trim(TxtApplyNumber.Text) & " Where matId='" & Trim(TxtMatId.Text) & "'"
				 AddCommand = New SqlCommand(StrAdd, Myconnection)
			
				'���´�������ִ��ʵ�ʵ�SQL SERVER����	
		        Myconnection.Open()
					 MyTransaction=Myconnection.BeginTransaction
					 DeleCommand.Transaction=MyTransaction
					 AddCommand.Transaction=MyTransaction
					 DeleCommand.ExecuteNonQuery()
            		 AddCommand.ExecuteNonQuery()
            		 MyTransaction.Commit
				Myconnection.Close()
				
				'�ѿ��ÿ�����ڽ����ϼ���ȥ
				txtMatAvailablenumber.Text=txtMatAvailablenumber.Text+txtApplyNumber.Text
				
				DataGridRefresh() '����DataGrid�е�����
				
				
	
				'���´���������е����ݣ�������ɵڶ���ɾ��			
				txtApplyNumber.Text=0
				txtGotNameNo.Text=""
				txtGotName.Text=""
				txtDetailId.Text=""
    			TxtMatId.Text=""
				TxtMatName.Text=""
				TxtMatSize.Text=""
				TxtMatSex.Text=""
				TxtMatUnit.Text=""
				TxtMatAmountLeft.Text=""
				TxtMatavailableNumber.Text=""			
				TxtPrice.Text=""
				
				BtnGotNameNo2.Disabled=True
                BtnGotMatId.Disabled=True
                txtApplynumber.Enabled=False
                BtnAddDetail.Enabled=True
                BtnDeleDetail.Enabled=False
                BtnModiDetail.Enabled=False
                BtnSaveDetail.Enabled=False
                
                lbDetailMessage.Text="ɾ���ɹ�"
				lbDetailMessage.Style("color") = "Blue"
			End Sub
			Sub btnModiDetail_Click(Sender As Object,E as EventArgs)
				BtnSaveDetail.Enabled=True
				BtnAddDetail.Enabled=False
				BtnDeleDetail.Enabled=False
				BtnModiDetail.Enabled=False
				
				lbDetailMessage.Text="���޸�"
				lbDetailMessage.Style("color") = "Blue"
				BtnGotNameNo2.Disabled=False
                BtnGotMatId.Disabled=False
                txtApplynumber.Enabled=True
                
                BtnFunction.Text="Dele"
			End Sub
			Sub DateGrid_OnSelect(S As Object,E As DataGridCommandEventArgs)
				If BtnSaveMaster.Enabled Then
					lbDetailMessage.Text="���ȱ���������޸�"
					lbDetailMessage.Style("color") = "Red"
					Return
				End If
				If e.CommandName="SelectItem" Then
					MyDataGrid.SelectedIndex=e.Item.ItemIndex
					txtGotNameNo.Text=e.Item.Cells(3).Text
					txtGotName.Text=e.Item.Cells(4).Text
					txtDetailId.Text=e.Item.Cells(2).Text
					txtMatId.Text=e.Item.Cells(5).Text
					txtMatIdB4Modi.Text=e.Item.Cells(5).Text '�����޸�ǰ��������ȷ���޸Ĳ���
					txtMatName.Text=e.Item.Cells(7).Text
					txtMatSize.Text=e.Item.Cells(8).Text
					txtMatSex.Text=e.Item.Cells(9).Text
					txtMatUnit.Text=e.Item.Cells(10).Text
					txtMatAmountleft.Text=e.Item.Cells(11).Text
					txtMatAvailableNumber.Text=e.Item.Cells(12).Text
					txtApplyNumber.Text=e.Item.Cells(6).Text
					TxtNumB4Modi.Text=e.Item.Cells(6).Text '�����޸�ǰ�������������޸Ŀ��ÿ��
					txtPrice.Text=e.Item.Cells(13).Text
				
					BtnGotNameNo2.Disabled=True
					BtnGotMatId.Disabled=True
					txtApplynumber.Enabled=False
					
					BtnModiDetail.Enabled=True
					BtnDeleDetail.Enabled=True
					BtnAddDetail.Enabled=False
					btnSaveDetail.Enabled=False
					
					lbDetailMessage.Text="��������޸�"
					lbDetailMessage.Style("color") = "Blue"
				End If
			End Sub
			Sub DataGrid_IndexChanged(S As Object,E As DataGridPageChangedEventArgs)
					MyDataGrid.CurrentPageIndex=e.NewPageIndex
					DataGridRefresh()
				
			End Sub
			Sub DrpDn_Click(Sender As Object,E as EventArgs)
				   TxtApplyName.Text="��ѡ��"
				   TxtApplyNameno.Text="��ѡ��"
			End Sub		
			Sub Exit_Click(Sender As Object,E as EventArgs)
				   Response.Redirect("lbNavigator.Aspx")
			End Sub		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="Form1" onkeydown="if(event.keyCode == 13) return false;" method="post" runat="server">
			<FONT id="FONT1" face="����">
				<asp:label id="Label2" style="Z-INDEX: 109; LEFT: 336px; POSITION: absolute; TOP: 8px" runat="server"
					Font-Bold="True" Height="8px" Width="196px">�ͱ���Ʒ�������뵥�޸�</asp:label><asp:label id="Label29" style="Z-INDEX: 176; LEFT: 160px; POSITION: absolute; TOP: 168px" runat="server"
					Height="8px" Width="46px" BackColor="#FF9966" Font-Size="10pt">��ע��</asp:label><asp:textbox id="TxtMemo" style="Z-INDEX: 177; LEFT: 200px; POSITION: absolute; TOP: 160px" runat="server"
					Height="24px" Width="550px" MaxLength="40"></asp:textbox><asp:label id="Label28" style="Z-INDEX: 175; LEFT: 0px; POSITION: absolute; TOP: 488px" runat="server"
					Height="8px" Width="48px" Font-Size="10pt" Visible="False">ԭ����:</asp:label><asp:label id="Label27" style="Z-INDEX: 174; LEFT: 0px; POSITION: absolute; TOP: 512px" runat="server"
					Height="8px" Width="48px" Font-Size="10pt" Visible="False">ԭ����:</asp:label><asp:textbox id="TxtMatIdB4Modi" style="Z-INDEX: 173; LEFT: 48px; POSITION: absolute; TOP: 480px"
					runat="server" Width="56px" Visible="False" Enabled="False"></asp:textbox><asp:label id="Label26" style="Z-INDEX: 172; LEFT: 8px; POSITION: absolute; TOP: 72px" runat="server"
					Height="8px" Width="80px" Font-Size="10pt" Visible="False">ʹ������(��)��</asp:label><asp:label id="Label25" style="Z-INDEX: 104; LEFT: -8px; POSITION: absolute; TOP: 104px" runat="server"
					Height="8px" Width="94px" Font-Size="10pt" Visible="False">�ϴ��������ڣ�</asp:label><asp:label id="Label24" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 24px" runat="server"
					Height="8px" Width="80px" Font-Size="10pt" Visible="False">���Ϲ���</asp:label><asp:textbox id="TxtMeetRule" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 16px"
					runat="server" Width="80px" Visible="False"></asp:textbox><asp:textbox id="txtLastGotDate" style="Z-INDEX: 101; LEFT: 88px; POSITION: absolute; TOP: 40px"
					runat="server" Width="80px" Visible="False"></asp:textbox><asp:textbox id="txtSynx" style="Z-INDEX: 100; LEFT: 88px; POSITION: absolute; TOP: 64px" runat="server"
					Width="80px" Visible="False"></asp:textbox><asp:button id="BtnDetect" style="Z-INDEX: 171; LEFT: 408px; POSITION: absolute; TOP: 568px"
					onclick="btnDetect_Click" runat="server" Height="24" Width="65" Text="���"></asp:button><asp:label id="Label23" style="Z-INDEX: 169; LEFT: 672px; POSITION: absolute; TOP: 504px" runat="server"
					Height="16px" Width="44px" Font-Size="10pt">���ۣ�</asp:label><asp:textbox id="TxtPrice" style="Z-INDEX: 170; LEFT: 712px; POSITION: absolute; TOP: 496px"
					runat="server" Width="46px" ReadOnly="True"></asp:textbox><asp:panel id="Panel4" style="Z-INDEX: 107; LEFT: 376px; POSITION: absolute; TOP: 528px" runat="server"
					Height="37px" Width="302px" BackColor="White" BorderWidth="1px" BorderStyle="Dotted" BorderColor="DarkGoldenrod"><FONT face="����"></FONT></asp:panel><asp:textbox id="TxtNumB4Modi" style="Z-INDEX: 167; LEFT: 48px; POSITION: absolute; TOP: 512px"
					runat="server" Width="56px" Visible="False" Enabled="False">0</asp:textbox><asp:label id="Label21" style="Z-INDEX: 166; LEFT: 144px; POSITION: absolute; TOP: 432px" runat="server"
					Height="16px" Width="78px" Font-Size="10pt" ForeColor="Blue">�޸���ҵ����</asp:label><asp:button id="BtnModiDetail" style="Z-INDEX: 165; LEFT: 552px; POSITION: absolute; TOP: 568px"
					onclick="btnModiDetail_Click" runat="server" Width="64px" Enabled="False" Text="�޸�"></asp:button><asp:button id="BtnDeleDetail" style="Z-INDEX: 164; LEFT: 696px; POSITION: absolute; TOP: 568px"
					onclick="btnDeleDetail_Click" runat="server" Width="64px" Enabled="False" Text="ɾ��"></asp:button><asp:label id="Label20" style="Z-INDEX: 163; LEFT: 144px; POSITION: absolute; TOP: 232px" runat="server"
					Height="16px" Width="96px" Font-Size="10pt" ForeColor="Blue">����ѡ������</asp:label><asp:button id="BtnModiMaster" style="Z-INDEX: 162; LEFT: 520px; POSITION: absolute; TOP: 32px"
					onclick="ModiMaster_Click" runat="server" Height="24px" Width="72px" Text="ȷ��"></asp:button><asp:dropdownlist id="DrpDMasterId" style="Z-INDEX: 161; LEFT: 352px; POSITION: absolute; TOP: 32px"
					runat="server" Height="24px" Width="160px" Font-Size="10pt"></asp:dropdownlist><asp:label id="Label19" style="Z-INDEX: 117; LEFT: 248px; POSITION: absolute; TOP: 40px" runat="server"
					Height="8px" Width="105px" Font-Size="10pt">��ѡ�񵥾ݺ��룺</asp:label><asp:textbox id="txtMatAvailablenumber" style="Z-INDEX: 158; LEFT: 592px; POSITION: absolute; TOP: 536px"
					runat="server" Width="80px" ReadOnly="True"></asp:textbox><asp:label id="Label14" style="Z-INDEX: 157; LEFT: 528px; POSITION: absolute; TOP: 544px" runat="server"
					Height="16px" Width="70px" Font-Size="10pt">��ʹ������</asp:label><asp:textbox id="txtMatAmountLeft" style="Z-INDEX: 155; LEFT: 432px; POSITION: absolute; TOP: 536px"
					runat="server" Width="80px" ReadOnly="True"></asp:textbox><asp:label id="Label3" style="Z-INDEX: 154; LEFT: 384px; POSITION: absolute; TOP: 544px" runat="server"
					Height="16px" Width="56px" Font-Size="10pt">�������</asp:label><asp:label id="Label18" style="Z-INDEX: 151; LEFT: 152px; POSITION: absolute; TOP: 576px" runat="server"
					Height="8px" Width="70px" Font-Size="10pt">������Ϣ��</asp:label><asp:label id="lbDetailMessage" style="Z-INDEX: 153; LEFT: 216px; POSITION: absolute; TOP: 576px"
					runat="server" Height="8px" Width="184px" BackColor="White" Font-Size="10pt" ForeColor="Red"></asp:label><asp:label id="lbMastMessage" style="Z-INDEX: 150; LEFT: 216px; POSITION: absolute; TOP: 208px"
					runat="server" Height="8px" Width="298px" BackColor="White" Font-Size="10pt" ForeColor="Red"></asp:label><asp:label id="Label22" style="Z-INDEX: 149; LEFT: 152px; POSITION: absolute; TOP: 208px" runat="server"
					Height="8px" Width="70px" Font-Size="10pt">������Ϣ��</asp:label><INPUT id="BtnGotNameNo2" style="Z-INDEX: 160; LEFT: 312px; WIDTH: 24px; POSITION: absolute; TOP: 456px; HEIGHT: 24px"
					disabled onclick="GotNameNo2();" type="button" value="..." name="BtnGotNameNo2" runat="server"><asp:textbox id="TxtApplyNameno" style="Z-INDEX: 146; LEFT: 456px; POSITION: absolute; TOP: 80px"
					runat="server" Width="80px" ReadOnly="True">��ѡ��</asp:textbox><asp:textbox id="TxtMatUnit" style="Z-INDEX: 145; LEFT: 720px; POSITION: absolute; TOP: 536px"
					runat="server" Width="28px" ReadOnly="True"></asp:textbox><asp:textbox id="TxtMatSex" style="Z-INDEX: 144; LEFT: 608px; POSITION: absolute; TOP: 496px"
					runat="server" Width="47px" ReadOnly="True"></asp:textbox><asp:textbox id="TxtMatSize" style="Z-INDEX: 143; LEFT: 528px; POSITION: absolute; TOP: 496px"
					runat="server" Width="38px" ReadOnly="True"></asp:textbox><asp:textbox id="TxtMatName" style="Z-INDEX: 152; LEFT: 392px; POSITION: absolute; TOP: 496px"
					runat="server" Width="96px" BackColor="White" ReadOnly="True"></asp:textbox><asp:textbox id="TxtMatId" style="Z-INDEX: 142; LEFT: 232px; POSITION: absolute; TOP: 496px"
					runat="server" Width="80px" ReadOnly="True">��ѡ��</asp:textbox><INPUT id="BtnGotNameNo1" style="Z-INDEX: 141; LEFT: 536px; WIDTH: 24px; POSITION: absolute; TOP: 80px; HEIGHT: 24px"
					disabled onclick="GotNameNo1();" type="button" value="..." name="BtnGotNameNo1" runat="server">
				<asp:label id="Label13" style="Z-INDEX: 139; LEFT: 144px; POSITION: absolute; TOP: -48px" runat="server"
					Height="16px" Width="104px" Font-Size="10pt" ForeColor="Blue">�������ϸ�б�</asp:label><asp:button id="BtnAddDetail" style="Z-INDEX: 138; LEFT: 624px; POSITION: absolute; TOP: 568px"
					onclick="btnAddDetail_Click" runat="server" Width="64px" Enabled="False" Text="����"></asp:button><asp:panel id="Panel3" style="Z-INDEX: 106; LEFT: 144px; POSITION: absolute; TOP: 448px" runat="server"
					Height="152px" Width="658px" BackColor="White" BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGoldenrod"><FONT face="����"></FONT></asp:panel><asp:textbox id="txtApplynumber" style="Z-INDEX: 136; LEFT: 232px; POSITION: absolute; TOP: 536px"
					runat="server" Width="56px" Enabled="False">0</asp:textbox><asp:label id="Label17" style="Z-INDEX: 135; LEFT: 152px; POSITION: absolute; TOP: 544px" runat="server"
					Height="16px" Width="72px" BackColor="#FF9966" Font-Size="10pt" ForeColor="#400040">����������</asp:label><asp:label id="Label12" style="Z-INDEX: 133; LEFT: 576px; POSITION: absolute; TOP: 504px" runat="server"
					Height="16px" Width="44px" Font-Size="10pt">���</asp:label><asp:label id="Label11" style="Z-INDEX: 132; LEFT: 496px; POSITION: absolute; TOP: 504px" runat="server"
					Height="16px" Width="44px" Font-Size="10pt">��С��</asp:label><asp:label id="Label10" style="Z-INDEX: 134; LEFT: 688px; POSITION: absolute; TOP: 544px" runat="server"
					Height="16px" Width="44px" Font-Size="10pt">��λ��</asp:label><asp:label id="Label9" style="Z-INDEX: 147; LEFT: 344px; POSITION: absolute; TOP: 504px" runat="server"
					Height="16px" Width="52px" Font-Size="10pt">��������</asp:label><asp:label id="Label8" style="Z-INDEX: 131; LEFT: 152px; POSITION: absolute; TOP: 504px" runat="server"
					Height="16px" Width="56px" BackColor="#FF9966" Font-Size="10pt" ForeColor="Navy">���Ϻţ�</asp:label><asp:label id="Label7" style="Z-INDEX: 130; LEFT: 400px; POSITION: absolute; TOP: 464px" runat="server"
					Height="16px" Width="78px" Font-Size="10pt">������������</asp:label><asp:label id="Label6" style="Z-INDEX: 129; LEFT: 152px; POSITION: absolute; TOP: 464px" runat="server"
					Height="16px" Width="78px" BackColor="#FF9966" Font-Size="10pt" ForeColor="#000040">�����˹��ţ�</asp:label><asp:label id="Label5" style="Z-INDEX: 127; LEFT: 632px; POSITION: absolute; TOP: 464px" runat="server"
					Height="16px" Width="56px" Font-Size="10pt">��ϸ�ţ�</asp:label><asp:label id="Label1" style="Z-INDEX: 124; LEFT: 160px; POSITION: absolute; TOP: 88px" runat="server"
					Height="8px" Width="136px" Font-Size="10pt">��ѡ���Ŵ������ƣ�</asp:label><asp:textbox id="txtApplyName" style="Z-INDEX: 123; LEFT: 664px; POSITION: absolute; TOP: 80px"
					runat="server" Width="80px" ReadOnly="True">��ѡ��</asp:textbox><asp:label id="Label33" style="Z-INDEX: 122; LEFT: 584px; POSITION: absolute; TOP: 88px" runat="server"
					Height="8px" Width="84px" Font-Size="10pt">������������</asp:label><asp:label id="Label31" style="Z-INDEX: 121; LEFT: 384px; POSITION: absolute; TOP: 88px" runat="server"
					Height="8px" Width="80px" BackColor="#FF9966" Font-Size="10pt">�����˹��ţ�</asp:label><asp:panel id="Panel2" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 72px" runat="server"
					Height="126px" Width="651px" BackColor="White" BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGoldenrod"><FONT face="����"></FONT></asp:panel><asp:panel id="Panel1" style="Z-INDEX: 105;  POSITION: absolute; TOP: 64px" runat="server"
					Height="546px" Width="100%" BackColor="White" BorderStyle="Solid" BorderColor="DarkGoldenrod"><FONT face="����"></FONT></asp:panel><asp:label id="Label16" style="Z-INDEX: 118; LEFT: 392px; POSITION: absolute; TOP: 128px" runat="server"
					Height="8px" Width="83px" Font-Size="10pt">���뵥���룺</asp:label><asp:textbox id="SysDate" style="Z-INDEX: 115; LEFT: 88px; POSITION: absolute; TOP: -8px" runat="server"
					Width="80px" Visible="False" Enabled="False"></asp:textbox><asp:label id="Label15" style="Z-INDEX: 114; LEFT: 8px; POSITION: absolute; TOP: 0px" runat="server"
					Height="8px" Width="80px" Font-Size="10pt" Visible="False">¼�����ڣ�</asp:label><asp:textbox id="TxtApplyDate" style="Z-INDEX: 120; LEFT: 232px; POSITION: absolute; TOP: 120px"
					runat="server" Width="80px" Enabled="False"></asp:textbox><asp:label id="Label4" style="Z-INDEX: 110; LEFT: 160px; POSITION: absolute; TOP: 128px" runat="server"
					Height="16px" Width="70px" BackColor="#FF9966" Font-Size="10pt">�������ڣ�</asp:label><asp:button id="BtnSaveMaster" style="Z-INDEX: 112; LEFT: 528px; POSITION: absolute; TOP: 200px"
					onclick="BtnSaveMaster_Click" runat="server" Height="24px" Width="100px" Enabled="False" Text="���漰�޸���ϸ"></asp:button></FONT><asp:button id="BtnExit" style="Z-INDEX: 113; LEFT: 664px; POSITION: absolute; TOP: 200px" onclick="exit_click"
				runat="server" Height="24px" Width="73px" Text="���ز˵�" CausesValidation="False"></asp:button><asp:rangevalidator id="ValiDate" style="Z-INDEX: 116; LEFT: 312px; POSITION: absolute; TOP: 128px"
				runat="server" Height="8px" Width="56px" Font-Size="10pt" Type="Date" MinimumValue="1980/01/01" MaximumValue="2099/12/31" ControlToValidate="TxtApplyDate" ErrorMessage="��Ч����"></asp:rangevalidator><asp:textbox id="txtApplyId" style="Z-INDEX: 119; LEFT: 464px; POSITION: absolute; TOP: 120px"
				runat="server" Height="24px" Width="124px" ReadOnly="True">�ύ���Զ�����</asp:textbox>
            <asp:datagrid id="MyDatagrid" style="Z-INDEX: 111; POSITION: absolute; TOP: 248px; left: 18px;"
				runat="server" Height="68px" Width="100%" BackColor="Gainsboro" Font-Size="10pt" 
                PageSize="8" OnItemCommand="DateGrid_OnSelect" 
                OnPageIndexChanged="DataGrid_IndexChanged" AutoGenerateColumns="False"
				AllowPaging="True">
				<SelectedItemStyle ForeColor="Red" BackColor="LightGreen"></SelectedItemStyle>
				<ItemStyle BackColor="Gainsboro"></ItemStyle>
				<Columns>
					<asp:ButtonColumn Text="ѡ��" HeaderText="ѡ��" CommandName="SelectItem"></asp:ButtonColumn>
					<asp:BoundColumn DataField="���뵥��" HeaderText="���뵥��"></asp:BoundColumn>
					<asp:BoundColumn DataField="��ϸ����" HeaderText="��ϸ����"></asp:BoundColumn>
					<asp:BoundColumn DataField="�����˹���" HeaderText="�����˹���"></asp:BoundColumn>
					<asp:BoundColumn DataField="����������" HeaderText="����������"></asp:BoundColumn>
					<asp:BoundColumn DataField="���Ϻ�" HeaderText="���Ϻ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="��������" HeaderText="��������"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="������" HeaderText="������"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="��С" HeaderText="��С"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="���" HeaderText="���"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="��λ" HeaderText="��λ"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="�����" HeaderText="�����"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="��ʹ����" HeaderText="��ʹ����"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="����" HeaderText="����"></asp:BoundColumn>
					<asp:BoundColumn DataField="�������" HeaderText="�������"></asp:BoundColumn>
					<asp:BoundColumn DataField="�ϴ�����" HeaderText="�ϴ�����"></asp:BoundColumn>
					<asp:BoundColumn DataField="ʹ������(��)" HeaderText="ʹ������(��)"></asp:BoundColumn>
				</Columns>
				<PagerStyle Position="Top" BackColor="#FF9966" PageButtonCount="30" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			
			<!--Gridview��������-->
			<div style="margin-top:10px; border :1px solid red; width:100%;">
			
			
			<asp:textbox id="TxtDetailId" style="Z-INDEX: 128; LEFT: 680px; POSITION: absolute; TOP: 456px"
				runat="server" Width="80px" ReadOnly="True">�Զ�����</asp:textbox><asp:textbox id="TxtGotNameNo" style="Z-INDEX: 159; LEFT: 232px; POSITION: absolute; TOP: 456px"
				runat="server" Width="80px" ReadOnly="True">��ѡ��</asp:textbox><asp:textbox id="TxtGotName" style="Z-INDEX: 125; LEFT: 480px; POSITION: absolute; TOP: 456px"
				runat="server" Width="84px" ReadOnly="True">��ѡ��</asp:textbox><asp:button id="BtnSaveDetail" style="Z-INDEX: 126; LEFT: 480px; POSITION: absolute; TOP: 568px"
				onclick="Save_Detail" runat="server" Width="64px" Enabled="False" Text="������ϸ"></asp:button><asp:rangevalidator id="ValidNumber" style="Z-INDEX: 137; LEFT: 296px; POSITION: absolute; TOP: 544px"
				runat="server" Height="16px" Width="70px" Font-Size="10pt" Type="Integer" MinimumValue="0" MaximumValue="9999999" ControlToValidate="txtApplynumber" ErrorMessage="����������"></asp:rangevalidator><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><input id="BtnGotMatId" style="Z-INDEX: 148; LEFT: 312px; WIDTH: 24px; POSITION: absolute; TOP: 496px; HEIGHT: 24px"
				disabled onclick="GotMatId();" type="button" value="..." name="BtnGotMatId" runat="server">
			<asp:dropdownlist id="DrpDnApplyDeptCodeName" style="Z-INDEX: 140; LEFT: 296px; POSITION: absolute; TOP: 80px"
				runat="server" Height="24px" Width="80px" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="DrpDn_Click">
				<asp:ListItem Value="00">��</asp:ListItem>
				<asp:ListItem Value="01">����</asp:ListItem>
				<asp:ListItem Value="02">����</asp:ListItem>
				<asp:ListItem Value="03">Ӫҵ</asp:ListItem>
				<asp:ListItem Value="05">����</asp:ListItem>
				<asp:ListItem Value="06">�ʱ�</asp:ListItem>
				<asp:ListItem Value="07">����ҵ��</asp:ListItem>
				<asp:ListItem Value="08">�豸����</asp:ListItem>
				<asp:ListItem Value="09">ͳ��</asp:ListItem>
				<asp:ListItem Value="10">BL��</asp:ListItem>
                                <asp:ListItem Value="11">CFL��</asp:ListItem>
			</asp:dropdownlist><asp:button id="BtnFunction" style="Z-INDEX: 168; LEFT: 176px; POSITION: absolute; TOP: 16px"
				runat="server" Height="24px" Width="56px" Visible="False" Text="Function"></asp:button>
				</div>
				
				
				</FORM>
	</body>
</HTML>
