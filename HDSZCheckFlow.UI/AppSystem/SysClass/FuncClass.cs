using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Web.UI.WebControls;


public delegate void Function_DataBind();
public delegate string Function_BindData();
	
public  sealed class FuncClass 
{
	static string ControlString=System.Configuration .ConfigurationSettings .AppSettings ["ConnectionString"];
	
	public FuncClass() 
	{
		//
		// TODO: �ڴ˴���ӹ��캯���߼�
		//	
	}

	public static string ConnectionString
	{
		get 
		{
			return ControlString;
		}
			
	}

	#region GetBmbhNext����
	/// ������ͬһ��һ�����������Ĳ��ű��
	public static string GetBmbhNext(string csbmbh) 
	{
		string ls_bmbhnext;
		if(csbmbh=="0000") //ѡ��ȫ������
		{
			ls_bmbhnext=FuncClass.ExecuteCmdScalar("select max(bmbh) from KQ_CS_BM	Where bmbh<'Z'").ToString();
		}
		else if(csbmbh.Substring(3,3)=="000")
		{
			ls_bmbhnext=FuncClass.ExecuteCmdScalar("select max(bmbh) from KQ_CS_BM 	where bmbh>='"+csbmbh+"' and substring(bmbh,1,3)=substring('"+csbmbh+"',1,3) and bmbh<'Z'").ToString(); 
		}
		else if(csbmbh.Substring(4,2)=="00")
		{
			ls_bmbhnext=FuncClass.ExecuteCmdScalar("select max(bmbh) from KQ_CS_BM 	where bmbh>='"+csbmbh+"' and substring(bmbh,1,4)=substring('"+csbmbh+"',1,4) and bmbh<'Z'").ToString(); 
		}
		else 
		{
			ls_bmbhnext=csbmbh;
		}
			
				
			

		if(ls_bmbhnext.Length<4)
		{ls_bmbhnext=csbmbh;}
		return ls_bmbhnext;
							
	}
	
	#endregion

	#region ������ҳ��س�ʱ�����¼��Ŀؼ�
	/// <summary> 
	/// ������ҳ��س�ʱ�����¼��Ŀؼ� 
	/// </summary> 
	/// <param name="Ctrl">�������¼��Ŀؼ�����</param> 
	public static void SetEnterControl(System.Web.UI.Control Ctrl) 
	{ 
		Page mPage = Ctrl.Page; 
		string mScript; 
		mScript = @"<script language=""javascript""> 
				function document.onkeydown() 
				{ 
				var e = event.srcElement; 
				var k = event.keyCode; 
				if (k == 13 && e.type != ""textarea"") 
				{ 
				document.all." + Ctrl.ClientID + @".click(); 
				event.cancelBubble = true; 
				event.returnValue = false; 
				} 
				} 
				</script>"; 
		if(!mPage.IsClientScriptBlockRegistered("SetEnterControl")) 
			mPage.RegisterClientScriptBlock("SetEnterControl",mScript); 
	}
	#endregion

	#region ����ѡ��ؼ�
	/// <summary>
	/// ����ѡ��ؼ�
	/// </summary>
	/// <param name="begindate">��ʼ����</param>
	/// <param name="enddate">��������</param>
	public static void InitDate(TextBox begindate,TextBox enddate)
	{
		begindate.Text = DateTime.Now.ToString("yyyy-MM-01");
		enddate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			
		InitDate(new TextBox[]{begindate,enddate});
	}
	/// <summary>
	/// ����ѡ��ؼ�
	/// </summary>
	/// <param name="date">�������ڵ�TextBox�ؼ���</param>
	public static void InitDate(TextBox[] date)
	{
		InitDate(date,2);
	}
	/// <summary>
	/// ����ѡ��ؼ�
	/// </summary>
	/// <param name="date">�������ڵ�TextBox�ؼ���</param>
	public static void InitDate(TextBox date)
	{
		InitDate(new TextBox[]{date});
	}

	/// <summary>
	/// ����ѡ��ؼ�
	/// </summary>
	/// <param name="date">�������ڵ�TextBox�ؼ���</param>
	/// <param name="index">��ʾλ��</param>
	public static void InitDate(TextBox[] date,int index)
	{
		foreach(TextBox box in date)
		{
			Image image = new Image();
			image.ID = "img"+box.ClientID;
			image.ImageUrl = "../Img/button.gif";
			image.ImageAlign = ImageAlign.AbsMiddle;
			image.Width = 27;
			image.Height = 20;
			image.Attributes["style"] = "cursor:pointer;";
			image.Attributes["onclick"] = "javascript:showCalendar('img"+box.ClientID+"',true,'"+box.ClientID+"',null);";
			box.Parent.Controls.AddAt(index,image);
		}
	}
	#endregion

	#region Ϊ�����б������
	// ��д�ߣ�����ȫ
	/// <summary>
	/// Ϊ�����б������
	/// </summary>
	/// <param name="ddl">Ҫ�����ݵ�DropDownList����</param>
	/// <param name="table">���ݱ�</param>
	/// <param name="textField">�ı��ֶ�</param>
	/// <param name="valueField">ֵ�ֶ�</param>
	private static void DDLDataBind(Control ctrl,DataTable table,string textField,string valueField)
	{
		switch(ctrl.GetType().Name)
		{
			case "DropDownList":
				DropDownList ddl = (DropDownList)ctrl;
				ddl.DataSource = table.DefaultView;
				ddl.DataTextField = textField;
				ddl.DataValueField = valueField;
				break;
			case "CheckBoxList":
				CheckBoxList cbl = (CheckBoxList)ctrl;
				cbl.DataSource = table.DefaultView;
				cbl.DataTextField = textField;
				cbl.DataValueField = valueField;
				break;
			case "RadioButtonList":
				RadioButtonList rbl = (RadioButtonList)ctrl;
				rbl.DataSource = table.DefaultView;
				rbl.DataTextField = textField;
				rbl.DataValueField = valueField;
				break;
			default:break;
		}
		ctrl.DataBind();
	}
	/// <summary>
	/// Ϊ�����б������
	/// </summary>
	/// <param name="ddl">Ҫ�����ݵ�DropDownList����</param>
	/// <param name="cmdText">��ѯ�ı�</param>
	/// <param name="textField">�ı��ֶ�</param>
	/// <param name="valueField">ֵ�ֶ�</param>
	public static void DDLDataBind(Control ctrl,string cmdText,string textField,string valueField)
	{
		DataTable tbl_data = ExecuteCmdDataTable(cmdText,"tbl_data");
		DDLDataBind(ctrl,tbl_data,textField,valueField);
	}

	/// <summary>
	/// Ϊ�����б������
	/// </summary>
	/// <param name="ddl">Ҫ�����ݵ�DropDownList����</param>
	/// <param name="cmd">SqlCommandʵ��</param>
	/// <param name="textField">�ı��ֶ�</param>
	/// <param name="valueField">ֵ�ֶ�</param>
	public static void DDLDataBind(Control ctrl,SqlCommand cmd,string textField,string valueField)
	{
		DataTable tbl_data = ExecuteCmdDataTable(cmd,"tbl_data");
		DDLDataBind(ctrl,tbl_data,textField,valueField);
	}

	/// <summary>
	/// Ϊ�����б������
	/// </summary>
	/// <param name="ddl">Ҫ�����ݵ�DropDownList����</param>
	/// <param name="cmdText">��ѯ�ı�</param>
	public static void DDLDataBind(Control ctrl,string cmdText)
	{
		DataTable tbl_data = ExecuteCmdDataTable(cmdText,"tbl_data");
		DDLDataBind(ctrl,tbl_data,tbl_data.Columns[0].ColumnName,tbl_data.Columns[1].ColumnName);
	}

	/// <summary>
	/// Ϊ�����б������
	/// </summary>
	/// <param name="ddl">Ҫ�����ݵ�DropDownList����</param>
	/// <param name="cmd">SqlCommandʵ��</param>
	public static void DDLDataBind(Control ctrl,SqlCommand cmd)
	{
		DataTable tbl_data = ExecuteCmdDataTable(cmd,"tbl_data");
		DDLDataBind(ctrl,tbl_data,tbl_data.Columns[0].ColumnName,tbl_data.Columns[1].ColumnName);
	}
	#endregion

	#region ȥ���ַ�����ͷ��ָ�����ַ���
	/// <summary>
	/// ��oldstring��ͷ��ȥ��substing�Ӵ�������ƥ�䡣
	/// </summary>
	/// <param name="oldstring">ԭ�ַ���</param>
	/// <param name="substring">Ҫ��ȥ�����Ӵ�</param>
	/// <returns>����ȥ���Ӵ��ĺ���ַ���</returns>
	public static string LTrim(string oldstring,string substring)
	{
		if (substring=="") return oldstring;
		while (oldstring.StartsWith (substring))
		{
			oldstring=oldstring.Substring (substring.Length );
		}
		return oldstring;

	}
	/// <summary>
	/// ��oldstring��β��ȥ��substing�Ӵ�������ƥ�䡣
	/// </summary>
	/// <param name="oldstring">ԭ�ַ���</param>
	/// <param name="substring">Ҫ��ȥ�����Ӵ�</param>
	/// <returns>����ȥ���Ӵ��ĺ���ַ���</returns>
	public static string RTrim(string oldstring,string substring)
	{
		if (substring=="") return oldstring;
		while(oldstring.EndsWith(substring))
		{
			oldstring=oldstring.Substring (0,oldstring.Length -substring.Length );
		}
		return oldstring;

	}
	/// <summary>
	/// ��oldstring��ͷβȥ��substing�Ӵ�������ƥ�䡣
	/// </summary>
	/// <param name="oldstring">ԭ�ַ���</param>
	/// <param name="substring">Ҫ��ȥ�����Ӵ�</param>
	/// <returns>����ȥ���Ӵ��ĺ���ַ���</returns>
	public static string Trim(string oldstring,string substring)
	{
		if (substring=="") return oldstring;
		oldstring=LTrim(oldstring, substring);
		oldstring=RTrim(oldstring,substring);
		return oldstring;
	}

	#endregion

	#region ҳ���ʼ������
	public static void InitPage(Control ctrl)
	{
		InitPage(ctrl.Page);
		SetEnterControl(ctrl);
	}
	/*
		 * ��д:����
		*/
	/// <summary>
	/// ҳ���ʼ���������жϵ�½�Ƿ�ʱ���û��Ƿ���Ȩ�޷���ҳ��
	/// </summary>
	/// <param name="pg_InitPage"></param>
	public static void InitPage(System.Web.UI.Page pg_InitPage) 
	{            
  

		//			string str_classname,str_CmdText;
		//			int int_start,int_end,int_count;
		//			
		//			//�ж��Ƿ�ʱ
		//			if (pg_InitPage.Session .Count >0)	
		//			{					
		//				if (!pg_InitPage.IsPostBack )
		//				{
		//					str_classname=pg_InitPage.ToString ();
		//					int_start=str_classname.LastIndexOf ("ASP.")+4;
		//					int_end=str_classname.LastIndexOf ("_aspx");
		//					str_classname=str_classname.Substring (int_start,int_end-int_start);
		//					//���ж��Ƿ����ܿ�ҳ�档
		//					str_CmdText="Select Count(classname) From SYS_RIGHT_CLASS Where classname='"+str_classname+"'";
		//					int_count=System.Convert .ToInt32 (ExecuteCmdScalar(str_CmdText));
		//					if (int_count>0)
		//					{
		//						//���ܿ�ҳ�棬�鿴��ǰ�û��Ƿ���Ȩ�޷��ʡ�
		//						UserClass User=(UserClass)pg_InitPage.Session ["SYSUSER"];
		//						str_CmdText=@"Select Count(classname) From SYS_RIGHT_GROUPRIGHT Join SYS_RIGHT_CLASS 
		//								On SYS_RIGHT_GROUPRIGHT.menuno=SYS_RIGHT_CLASS.menuno 
		//								and SYS_RIGHT_GROUPRIGHT.groupnumber=";
		//						str_CmdText+=User.UserGroup .ToString ()+"And SYS_RIGHT_CLASS.classname='"+str_classname+"'";
		//						int_count=System.Convert .ToInt32 (ExecuteCmdScalar(str_CmdText));
		//						if (int_count==0)
		//						{
		//							//pg_InitPage.Response .Write ("û��Ȩ��");
		//							
		//							//pg_InitPage.Response .Redirect (pg_InitPage.Request.ApplicationPath+"/NoRight.aspx?classname="+str_classname);
		//						}
		//					}					
		//				}			
		//			} 
		//			else
		//			{
		//				//pg_InitPage.Response .Redirect (pg_InitPage.Request.ApplicationPath+"/Login.aspx?loadpage="+pg_InitPage.Request.FilePath);
		//				//pg_InitPage.Response .Write(pg_InitPage.Request .FilePath) ;
		//				//pg_InitPage.Response .Write ("��½��ʱ");
		//				//pg_InitPage.Response.End ();
		//				
		//			}
		//            string str_CmdText;
		//            int int_count;
		//			
		//            //�ж��Ƿ�ʱ
		//			if (pg_InitPage.Session .Count >0)	
		//			{					
		//				if (!pg_InitPage.IsPostBack )
		//				{
		////					str_classname=pg_InitPage.ToString ();
		////					int_start=str_classname.LastIndexOf ("ASP.")+4;
		////					int_end=str_classname.LastIndexOf ("_aspx");
		////					str_classname=str_classname.Substring (int_start,int_end-int_start);
		////					//���ж��Ƿ����ܿ�ҳ�档
		////					str_CmdText="Select Count(classname) From SYS_RIGHT_CLASS Where classname='"+str_classname+"'";
		////					int_count=System.Convert .ToInt32 (ExecuteCmdScalar(str_CmdText));
		////					if (int_count>0)
		////					{
		////						//���ܿ�ҳ�棬�鿴��ǰ�û��Ƿ���Ȩ�޷��ʡ�
		////						UserClass User=(UserClass)pg_InitPage.Session ["SYSUSER"];
		////						str_CmdText=@"Select Count(classname) From SYS_RIGHT_GROUPRIGHT Join SYS_RIGHT_CLASS 
		////								On SYS_RIGHT_GROUPRIGHT.menuno=SYS_RIGHT_CLASS.menuno 
		////								and SYS_RIGHT_GROUPRIGHT.groupnumber=";
		////						str_CmdText+=User.UserGroup .ToString ();
		////						int_count=System.Convert .ToInt32 (ExecuteCmdScalar(str_CmdText));
		////						if (int_count==0)
		////						{
		////							//pg_InitPage.Response .Write ("û��Ȩ��");
		////							
		////							pg_InitPage.Response .Redirect (pg_InitPage.Request.ApplicationPath+"/NoRight.aspx?classname="+str_classname);
		////						}
		////					}					
		//				}			
		//			} 
		//			else
		//			{
		//				pg_InitPage.Response .Redirect (pg_InitPage.Request.ApplicationPath+"/Login.aspx?loadpage="+pg_InitPage.Request.FilePath);
		//				//pg_InitPage.Response .Write(pg_InitPage.Request .FilePath) ;
		//				//pg_InitPage.Response .Write ("��½��ʱ");
		//				//pg_InitPage.Response.End ();
		//				
		//			}
			
	}

	#endregion

	#region ���û�������

	/// <summary>
	/// ���û�ӵ�й���Ȩ�޵Ĳ��Ź������ͽṹ
	/// </summary>
	/// <param name="tree">Ҫ���Ĳ�����</param>
	/// <param name="department">�û�ӵ�й���Ȩ�޵Ĳ����б���","�ֿ�bmid�ֶ�</param>
	/// <param name="behavior">�������Ƿ���Ϊ�Լ��ĵ�һ���Ӳ������£���Ϊtrueʱ�ؽ������Ҹ����Ž���NodeDataΪ��,falseʱ���ؽ�</param>
	/// <param name="parentcheckbox" >�������Ƿ���CheckBox��</param>

	public static void BindDepart(Microsoft.Web .UI .WebControls.TreeView tree,string department,bool behavior,bool parentcheckbox)
	{		
		string str_CmdText;
		if (department.ToUpper()=="ALL" )
		{
			str_CmdText="Select  bmgx+convert(varchar(7),bmid)+'_' bmgx,bmid,bmmc+'('+bmbh+')' ,'F' From KQ_CS_BM  Order By bmbh";
		}
		else
		{
			str_CmdText="Select  bmgx+convert(varchar(7),bmid)+'_' bmgx,bmid,bmmc+'('+bmbh+')' ,'F' From KQ_CS_BM Where bmid In ("+department+") Order By bmbh";
		}
		DataTable dtbl_Depart=ExecuteCmdDataTable (str_CmdText,"depart");
		//tree.Page .Response .Write (str_CmdTextt);
		FuncClass.BuildTree(tree,dtbl_Depart,behavior,parentcheckbox);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="ddl"></param>
	/// <param name="department">�û�ӵ�й���Ȩ�޵Ĳ����б���","�ֿ�bmid�ֶ�</param>
	public static void BindDepart(DropDownList ddl,string department)
	{
		string cmdText = "select bmid,bmbh,bmmc+'('+bmbh+')',bmgx+convert(varchar(7),bmid)+'_' bmgx from KQ_CS_BM Where bmid In ("+department+") order by bmbh";
		DataTable tbl_depart = ExecuteCmdDataTable(cmdText,"depart");
		DataRow oRow;ListItem li;			
		char[] separator={'_'};
		string[] str_split_return;
		string text;int i=0,j=0;
		int int_count;
		ddl.Items .Clear ();
		for(i=0;i<tbl_depart.Rows.Count;i++)
		{
			text = "";
			oRow = tbl_depart.Rows[i];
			str_split_return=oRow["bmgx"].ToString ().Split (separator);
			int_count=str_split_return==null?0:str_split_return.Length ;
			for(j=1;j<int_count;j++)text+="&nbsp;";
			//for(j=2;j<oRow["bmgx"].ToString().Length;j+=2)text+="&nbsp;&nbsp;&nbsp;&nbsp;";
			li = new ListItem(System.Web.HttpUtility.HtmlDecode(text+oRow[2]),oRow[0].ToString());
			ddl.Items.Add(li);
		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="tree"></param>
	/// <param name="department"></param>
	/// <param name="behavior"></param>
	/// <param name="parentcheckbox"></param>
	/// <param name="field">�趨����nodevalueΪ��ֵ</param>
	public static void BindDepart(Microsoft.Web .UI .WebControls.TreeView tree,string department,bool behavior,bool parentcheckbox,string field)
	{		
		string str_CmdText="Select  bmgx+convert(varchar(7),bmid)+'_' bmgx,"+field+",bmmc+'('+bmbh+')' ,'F' From KQ_CS_BM Where bmid In ("+department+") Order By bmgx,bmbh";
		DataTable dtbl_Depart=ExecuteCmdDataTable (str_CmdText,"depart");
		FuncClass.BuildTree(tree,dtbl_Depart,behavior,parentcheckbox);
	}

	#endregion
        
	#region BindData����
	/// <summary>
	/// ����ѯ�������ݰ󶨵�webc_InControl�ؼ��������ؼ�¼����
	/// </summary>
	/// <param name="webc_InControl">Ҫ�����ݵĿؼ�</param>
	/// <param name="str_CmdText">��ѯ���ݵ�Sql���</param>
	/// <returns></returns>
		
	public static int BindData(WebControl webc_InControl,string str_CmdText) 
	{
		SqlConnection con_InitCon;
		SqlCommand cmd_InitCmd;
		SqlDataAdapter dad_InitDad;
		DataSet dst_InitDst;

		con_InitCon=new SqlConnection ();
		con_InitCon.ConnectionString =ControlString;
		cmd_InitCmd=new SqlCommand ();
		cmd_InitCmd.Connection =con_InitCon;
		dad_InitDad=new SqlDataAdapter ();
		dad_InitDad.SelectCommand =cmd_InitCmd;	
		cmd_InitCmd.CommandText =str_CmdText;
		dst_InitDst=new System.Data.DataSet ();
		
		dad_InitDad.Fill(dst_InitDst);
			
		webc_InControl.GetType ().GetProperty ("DataSource").SetValue (webc_InControl,dst_InitDst, null);
		webc_InControl.DataBind ();			
		return dst_InitDst.Tables[0].Rows.Count;
	}
	/// <summary>
	/// ����ѯ�������ݰ󶨵�webc_InControl�ؼ��������ؼ�¼����
	/// </summary>
	/// <param name="webc_InControl">Ҫ�����ݵĿؼ�</param>
	/// <param name="cmd_InCmd">��ѯ����SqlCommand����</param>
	/// <returns></returns>
	public static int BindData(WebControl webc_InControl,SqlCommand cmd_InCmd) 
	{
		SqlConnection con_InitCon;			
		SqlDataAdapter dad_InitDad;
		DataSet dst_InitDst;

		con_InitCon=new SqlConnection ();
		con_InitCon.ConnectionString =ControlString;
		cmd_InCmd.Connection =con_InitCon;
		dad_InitDad=new SqlDataAdapter ();
		dad_InitDad.SelectCommand =cmd_InCmd;			
		dst_InitDst=new DataSet ();

		dad_InitDad.Fill(dst_InitDst);
		webc_InControl.GetType ().GetProperty ("DataSource").SetValue (webc_InControl,dst_InitDst, null);
		webc_InControl.DataBind ();
		return dst_InitDst.Tables[0].Rows.Count;
	}		
	#endregion

	#region ExecuteCmdNonQuery����
	/// <summary>
	/// ִ��Sql��䣬������Ӱ����С���ExecuteNonQuery�ķ�װ
	/// </summary>
	/// <param name="str_CmdText">Sql���</param>
	/// <returns></returns>
	public static int ExecuteCmdNonQuery(string str_CmdText) 
	{
		int int_RowCount;
		SqlConnection con_InitCon;
		SqlCommand cmd_InitCmd;
			
		con_InitCon=new SqlConnection ();
		con_InitCon.ConnectionString =ControlString;
		cmd_InitCmd=new SqlCommand ();
		cmd_InitCmd.Connection =con_InitCon;			
		cmd_InitCmd.CommandText =str_CmdText;	
		con_InitCon.Open ();
		int_RowCount=0;
		int_RowCount=cmd_InitCmd.ExecuteNonQuery ();
		con_InitCon.Close ();	
		return int_RowCount;
							
	}
	/// <summary>
	/// ִ��Sql��䣬������Ӱ����С���ExecuteNonQuery�ķ�װ
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand����</param>
	/// <returns></returns>
		
	public static int ExecuteCmdNonQuery(SqlCommand cmd_InCmd) 
	{
		int int_RowCount;
		SqlConnection con_InitCon;
						
		con_InitCon=new SqlConnection ();
		con_InitCon.ConnectionString =ControlString;
		cmd_InCmd.Connection =con_InitCon;
		con_InitCon.Open ();
		int_RowCount=0;
		int_RowCount=cmd_InCmd.ExecuteNonQuery ();
		con_InitCon.Close ();	
		return int_RowCount;
							
	}
	#endregion

	#region ExecuteCmdScalar����
	/// <summary>
	/// ִ��Sql��䣬���ؽ������һ�е�һ�С���ExecuteScalar�ķ�װ
	/// </summary>
	/// <param name="str_CmdText">Sql���</param>
	/// <returns></returns>
	public static object ExecuteCmdScalar(string str_CmdText) 
	{
		object obj_ReturnObj;			
		SqlConnection con_InitCon;
		SqlCommand cmd_InitCmd;
			
		con_InitCon=new SqlConnection ();
		con_InitCon.ConnectionString =ControlString;
		cmd_InitCmd=new SqlCommand ();
		cmd_InitCmd.Connection =con_InitCon;			
		cmd_InitCmd.CommandText =str_CmdText;	
		con_InitCon.Open ();			
		obj_ReturnObj=cmd_InitCmd.ExecuteScalar ();
		con_InitCon.Close ();			
		return obj_ReturnObj;
							
	}
	/// <summary>
	/// ִ��Sql��䣬���ؽ������һ�е�һ�С���ExecuteScalar�ķ�װ
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand����</param>
	/// <returns></returns>
	
	public static object ExecuteCmdScalar(SqlCommand cmd_InCmd) 
	{
		object obj_ReturnObj;
		SqlConnection con_InitCon;
						
		con_InitCon=new SqlConnection ();
		con_InitCon.ConnectionString =ControlString;
		cmd_InCmd.Connection =con_InitCon;
		con_InitCon.Open ();			
		obj_ReturnObj=cmd_InCmd.ExecuteScalar ();
		con_InitCon.Close ();	
		return obj_ReturnObj;
							
	}
	#endregion

	#region ExecuteCmdDataSet����
	/// <summary>
	/// ִ��Sql��䣬�����ذ����������DataSet����
	/// </summary>
	/// <param name="str_CmdText">Sql���</param>
	/// <param name="tb_table">������ı���</param>
	/// <returns></returns>
	public static DataSet ExecuteCmdDataSet(string str_CmdText,string tb_table) 
	{
		DataSet ds_Ds;
		SqlConnection con_InitCon;
		SqlDataAdapter cmd_InitAda;
            
		ds_Ds=new DataSet();
		con_InitCon = new SqlConnection();
		con_InitCon.ConnectionString = ControlString;            
		cmd_InitAda = new SqlDataAdapter(str_CmdText,con_InitCon);
		cmd_InitAda.Fill(ds_Ds,tb_table);          
		    		
		return ds_Ds;
	}
	/// <summary>
	/// ִ��Sql��䣬�����ذ����������DataSet����
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand����</param>
	/// <param name="tb_table">������ı���</param>
	/// <returns></returns>
	public static DataSet ExecuteCmdDataSet(SqlCommand cmd_InCmd,string tb_table) 
	{
		DataSet ds_Ds;
		SqlConnection con_InitCon;
		SqlDataAdapter cmd_InitAda;
            
		ds_Ds=new DataSet();
		con_InitCon = new SqlConnection();
		con_InitCon.ConnectionString = ControlString;
		cmd_InCmd.Connection =con_InitCon;
		cmd_InitAda = new SqlDataAdapter(cmd_InCmd);
		cmd_InitAda.Fill(ds_Ds,tb_table);		    		
		return ds_Ds;

	}
	#endregion

	#region ExecuteCmdDataTableb����
	/// <summary>
	/// ִ��Sql��䣬�����ذ����������DataTable����
	/// </summary>
	/// <param name="str_CmdText">Sql���</param>
	/// <param name="tb_table">������ı���</param>
	/// <returns></returns>
	public static DataTable ExecuteCmdDataTable(string str_CmdText,string tb_table) 
	{
		DataSet ds_Ds;
		//            SqlConnection con_InitCon;
		//            SqlDataAdapter cmd_InitAda;
		//            
		//            ds_Ds=new DataSet();
		//            con_InitCon = new SqlConnection();
		//            con_InitCon.ConnectionString = ControlString;            
		//            cmd_InitAda = new SqlDataAdapter(str_CmdText,con_InitCon);
		//            cmd_InitAda.Fill(ds_Ds,tb_table); 
		ds_Ds=ExecuteCmdDataSet(str_CmdText,tb_table);
		    		
		return ds_Ds.Tables[tb_table];

	}
	/// <summary>
	/// ִ��Sql��䣬�����ذ����������DataTable����
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand����</param>
	/// <param name="tb_table">������ı���</param>
	/// <returns></returns>
	public static DataTable ExecuteCmdDataTable(SqlCommand cmd_InCmd,string tb_table) 
	{
		DataSet ds_Ds;
		//			SqlConnection con_InitCon;
		//			SqlDataAdapter cmd_InitAda;
		//            
		//			ds_Ds=new DataSet();
		//			con_InitCon = new SqlConnection();
		//			con_InitCon.ConnectionString = ControlString;
		//            cmd_InCmd.Connection =con_InitCon;
		//			cmd_InitAda = new SqlDataAdapter(cmd_InCmd);
		//			cmd_InitAda.Fill(ds_Ds,tb_table);    
		ds_Ds=	ExecuteCmdDataSet(cmd_InCmd,tb_table);
		return ds_Ds.Tables[tb_table];

	}
	public static DataTable ExecuteCmdDataTable(string str_CmdText,string tb_table,DataColumn col) 
	{
		DataTable ds_Ds=new DataTable(tb_table);
		ds_Ds.Columns.Add(col);
		SqlConnection con_InitCon;
		SqlDataAdapter cmd_InitAda;
			            
			            
		con_InitCon = new SqlConnection();
		con_InitCon.ConnectionString = ControlString;            
		cmd_InitAda = new SqlDataAdapter(str_CmdText,con_InitCon);
		cmd_InitAda.Fill(ds_Ds); 
			           
		return ds_Ds;

	}
	#endregion

	#region ExecuteCmdDataRow����
	/// <summary>
	/// ִ��Sql��䣬�����ذ���������ĵ�һ�н������������Ϊ�գ�����null
	/// </summary>
	/// <param name="str_CmdText">Sql���</param>
	/// <returns></returns>
	public static DataRow ExecuteCmdDataRow(string str_CmdText)
	{
		DataTable tbl_MyTable;
		tbl_MyTable=ExecuteCmdDataTable(str_CmdText,"tbl_private");
		if (tbl_MyTable.Rows .Count >0)
		{
			return tbl_MyTable.Rows [0];
		}
		else
		{
			return null;
		}
	}
	/// <summary>
	/// ִ��Sql��䣬�����ذ���������ĵ�һ�н������������Ϊ�գ�����null
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand����</param>
	/// <returns></returns>
	public static DataRow ExecuteCmdDataRow(SqlCommand cmd_InCmd)
	{
		DataTable tbl_MyTable;
		tbl_MyTable=ExecuteCmdDataTable(cmd_InCmd,"tbl_private");
		if (tbl_MyTable.Rows .Count >0)
		{
			return tbl_MyTable.Rows [0];
		}
		else
		{
			return null;
		}
	}
	#endregion

	#region ������
	/*
		 * ��д������
		 * �ɷ���һ���ṹ�ı������ṹ
		 */
	/// <summary>
	/// ��һ�м�¼����Node���;
	/// ��¼�еĵڶ��б�����ڣ���ӦNodeData���ԣ�
	/// ��¼�еĵ����б�����ڣ���ӦText���ԣ�
	/// ������������ڣ���ֵΪTʱ�����CheckBox,��ѡ�У�ֵΪFʱ��CheckBox,��û��ѡ�У�����ֵ��û��CheckBox;
	/// ������������ڣ���ֵΪNode��NavigateUrl����
	/// </summary>
	/// <param name="row">�����������Եļ�¼��</param>
	/// <returns></returns>
    private static Microsoft.Web.UI.WebControls.TreeNode BuildNode(System.Data.DataRow row) 
	{
		object[] _rowvalue=row.ItemArray ;
		Microsoft.Web .UI .WebControls .TreeNode _node=new Microsoft.Web.UI.WebControls.TreeNode ();
		_node.NodeData=_rowvalue[1].ToString ();
		_node.Text =_rowvalue[2].ToString ();
		if (_rowvalue.Length>3) 
		{
			if (_rowvalue[3].ToString ()=="T" ) 
			{
				_node.CheckBox =true;
				_node.Checked =true;
			}
			else if (_rowvalue[3].ToString ()=="F" ) 
			{
				_node.CheckBox =true;
				_node.Checked =false;
			}
		}
		if (_rowvalue.Length >4) 
		{				
			_node.NavigateUrl =_rowvalue[4].ToString ();
		}
		return _node;
	}
	/// <summary>
	/// ��DataTable�����ݲ���Node���ϡ�
	/// ���һ�б�����ڣ���������Node�ļ����ϵ
	/// ��ڶ��б�����ڣ���ӦNodeData���ԣ�
	/// ������б�����ڣ���ӦText���ԣ�
	/// �������������ڣ���ֵΪTʱ�����CheckBox,��ѡ�У�ֵΪFʱ��CheckBox,��û��ѡ�У�����ֵ��û��CheckBox;
	/// �������������ڣ���ֵΪNode��NavigateUrl����
	/// </summary>
	/// <param name="nodes">����չ��TreeNodeCollection����</param>
	/// <param name="table">�������ݵ�DataTable</param>
	/// <param name="index">DataTable�п�ʼ����Note���ļ�¼����</param>
	/// <param name="parent">��ΪTreeNodeCollection������Node���ļ���ؼ���</param>
	/// <param name="behavior">������Ƿ���Ϊ�Լ��ĵ�һ���ӽ���ؽ���Ϊtrueʱ�ؽ������Ҹ�����NodeData��Ϊ�ա�falseʱ���ؽ�������㱣������NodeData����</param>
	/// <param name="parentcheckbox" >������Ƿ���CheckBox��</param>
	/// <returns></returns>
	/// 
    private static int BuildNodeCollection(Microsoft.Web.UI.WebControls.TreeNodeCollection nodes, DataTable table, int index, string parent, bool behavior, bool parentcheckbox) 
	{
		string str_lastid,str_currid;
		int i;
        Microsoft.Web.UI.WebControls.TreeNode currnode = new Microsoft.Web.UI.WebControls.TreeNode();
		DataRow row;
		str_currid=parent;
		str_lastid=parent;
		while (str_currid.IndexOf (parent)==0&&index<table.Rows .Count ) 
		{
			row=table.Rows [index];				
			str_currid=row[0].ToString ();
			if (str_currid.IndexOf (parent)==0) 
			{
				if (str_currid.IndexOf (str_lastid)==0&&str_lastid!=str_currid&&str_lastid!=parent) 
				{
					Microsoft.Web .UI .WebControls .TreeNodeCollection chilenodes=new Microsoft.Web.UI.WebControls.TreeNodeCollection();
											
					index=BuildNodeCollection(chilenodes,table,index,str_lastid,behavior,parentcheckbox);
					if (behavior)
					{
                        Microsoft.Web.UI.WebControls.TreeNode selfnode = new Microsoft.Web.UI.WebControls.TreeNode();
                        selfnode = (Microsoft.Web.UI.WebControls.TreeNode)currnode.Clone();
						currnode.NodeData ="";							
						currnode.Nodes .Add (selfnode);
					}
					if (!parentcheckbox)
					{
						currnode.CheckBox =false;
					}
					for (i=0;i<chilenodes.Count ;i++) 
					{
						currnode.Nodes .Add (chilenodes[i]);
					}
											
				}
				else 
				{
					currnode=BuildNode(row);
					if(!parentcheckbox) //���Ի��ӣ�ʹ���Ų���ѡ��
					{
						currnode.CheckBox=false;
					}
					nodes.Add (currnode);
					str_lastid=str_currid;
					index++;
				}
			}
		}
		return index;
			
	}
	/// <summary>
	/// ��DataTable���ݼ��������ͽ��
	/// ���һ�б�����ڣ���������Node�ļ����ϵ
	/// ��ڶ��б�����ڣ���ӦNodeData���ԣ�
	/// ������б�����ڣ���ӦText���ԣ�
	/// �������������ڣ���ֵΪTʱ�����CheckBox,��ѡ�У�ֵΪFʱ��CheckBox,��û��ѡ�У�����ֵ��û��CheckBox;
	/// �������������ڣ���ֵΪNode��NavigateUrl����
	/// </summary>
	/// <param name="tree">���������</param>
	/// <param name="table">�����������DataTable����</param>
	/// <param name="behavior" >������Ƿ���Ϊ�Լ��ĵ�һ���ӽ���ؽ���Ϊtrueʱ�ؽ������Ҹ�����NodeData��Ϊ�ա�falseʱ���ؽ�������㱣������NodeData����</param>
	/// <returns></returns>
	public static int BuildTree(Microsoft.Web .UI .WebControls.TreeView tree,DataTable table,bool behavior) 
	{
        //����	7	��TreeNode���ǡ�System.Web.UI.WebControls.TreeNode���͡�Microsoft.Web.UI.WebControls.TreeNode��֮��Ĳ���ȷ������	C:\Data\E��\Finance2008\HDSZCheckFlow\HDSZCheckFlow.UI\AppSystem\SysClass\FuncClass.cs	804	57	HDSZCheckFlow.UI

		int i;
        Microsoft.Web.UI.WebControls.TreeNodeCollection nodes = new Microsoft.Web.UI.WebControls.TreeNodeCollection();
		BuildNodeCollection(nodes,table,0,"",behavior,true);
		for (i=0;i<nodes.Count ;i++) 
		{
			//tree.Nodes[0].Nodes.Add(nodes[i]);
			tree.Nodes .Add(nodes[i]);
		}
		return nodes.Count;
			
	}
	/// <summary>
	/// ��DataTable���ݼ��������ͽ��
	/// ���һ�б�����ڣ���������Node�ļ����ϵ
	/// ��ڶ��б�����ڣ���ӦNodeData���ԣ�
	/// ������б�����ڣ���ӦText���ԣ�
	/// �������������ڣ���ֵΪTʱ�����CheckBox,��ѡ�У�ֵΪFʱ��CheckBox,��û��ѡ�У�����ֵ��û��CheckBox;
	/// �������������ڣ���ֵΪNode��NavigateUrl����
	/// </summary>
	/// <param name="tree">���������</param>
	/// <param name="table">�����������DataTable����</param>
	/// <param name="behavior" >������Ƿ���Ϊ�Լ��ĵ�һ���ӽ���ؽ���Ϊtrueʱ�ؽ������Ҹ�����NodeData��Ϊ�ա�falseʱ���ؽ�������㱣������NodeData����</param>
	/// <param name="parentcheckbox" >������Ƿ���CheckBox��,�ڱ����ݵ�������������CheckBox��ʱ�ſ��Ǵ���Ϊ��</param>
	/// <returns></returns>
	public static int BuildTree(Microsoft.Web .UI .WebControls.TreeView tree,DataTable table,bool behavior,bool parentcheckbox) 
	{
		int i;
        Microsoft.Web.UI.WebControls.TreeNodeCollection nodes = new Microsoft.Web.UI.WebControls.TreeNodeCollection();
		BuildNodeCollection(nodes,table,0,"",behavior,parentcheckbox);
		for (i=0;i<nodes.Count ;i++) 
		{
			//tree.Nodes[0].Nodes.Add(nodes[i]);
			tree.Nodes .Add(nodes[i]);
		}
		return nodes.Count;
			
	}
	#endregion

	#region ΪDataGrid��ӷ�ҳ��ť����Ӧ����
	/// <summary>
	/// ΪDataGrid�� �Զ������ť���ش����¼�
	/// ��DataGrid�� ItemCommand �¼��е��� NetSys.FuncClass.DataGrid_ItemCommand ����
	/// </summary>
	/// <param name="source">DataGrid����</param>
	/// <param name="e">DataGridCommandEventArgs</param>
	/// <param name="function">�����¼�</param>
	public static void DataGrid_ItemCommand(object source,DataGridCommandEventArgs e,Function_DataBind function)
	{
		if(e.Item.ItemType==ListItemType.Pager)
		{
			DataGrid dgrd_DataGrid=(DataGrid)source;
			AddPageClick(dgrd_DataGrid,e);
			string cmd = e.CommandName;
			if(cmd=="FirstPage"||cmd=="PrevPage"||cmd=="NextPage"||cmd=="LastPage"||cmd=="GoToPage") function();
		}
	}
	public static void DataGrid_ItemCommand(object source,DataGridCommandEventArgs e,Function_BindData function)
	{
		if(e.Item.ItemType==ListItemType.Pager)
		{
			DataGrid dgrd_DataGrid=(DataGrid)source;
			AddPageClick(dgrd_DataGrid,e);
			string cmd = e.CommandName;
			if(cmd=="FirstPage"||cmd=="PrevPage"||cmd=="NextPage"||cmd=="LastPage"||cmd=="GoToPage") function();
		}
	}

	/// <summary>
	/// ΪDataGrid��ӷ�ҳ��ť
	/// ��д�ߣ�����ȫ
	/// 
	/// ʹ�÷�����(DataGrid1ΪҪ��ӷ�ҳ��ť��DataGrid����)           
	/// ��DataGrid�� ItemCreated �¼��е��� NetSys.FuncClass.DataGrid_ItemCreated ����;
	/// </summary>
	/// <param name="sender">DataGrid����</param>
	/// <param name="e">DataGridItemEventArgs</param>      
		

	public static void DataGrid_ItemCreated(object sender,DataGridItemEventArgs e)
	{
		if(e.Item.ItemType==ListItemType.Pager)
		{
			System.Web.UI.WebControls.DataGrid DataGrid = (System.Web.UI.WebControls.DataGrid)sender;
			ControlCollection ctrl = e.Item.Cells[0].Controls;
			int page = DataGrid.CurrentPageIndex;
			int count = DataGrid.PageCount;

			if(page>0)
			{
				ctrl.AddAt(0,LinkButton("��ҳ","FirstPage","",true));
				ctrl.AddAt(1,Blank(2));
				ctrl.AddAt(2,LinkButton("��ҳ","PrevPage","",true));
			}
			else
			{
				ctrl.AddAt(0,LinkButton("��ҳ","FirstPage","",false));
				ctrl.AddAt(1,Blank(2));
				ctrl.AddAt(2,LinkButton("��ҳ","PrevPage","",false));
			}
			ctrl.AddAt(3,Blank(2));
			ctrl.Add(Blank(2));
			if(page<count-1)
			{
				ctrl.Add(LinkButton("��ҳ","NextPage","",true));
				ctrl.Add(Blank(2));
				ctrl.Add(LinkButton("ĩҳ","LastPage","",true));
			}
			else
			{
				ctrl.Add(LinkButton("��ҳ","NextPage","",false));
				ctrl.Add(Blank(2));
				ctrl.Add(LinkButton("ĩҳ","LastPage","",false));
			}
			ctrl.Add(Blank(4));
			ctrl.Add(new  LiteralControl("��"+DataGrid.PageCount+"ҳ"));
			ctrl.Add(Blank(2));
			ctrl.Add(new LiteralControl("��"));
    
			// ����ҳ��
			TextBox txtPage = new TextBox();
			txtPage.ID = "txtPage";
			txtPage.Text = Convert.ToString(DataGrid.CurrentPageIndex+1);
			txtPage.Attributes.Add("style","width: 40px;");
			txtPage.CssClass = "inputbox";
			ctrl.Add(txtPage);

			ctrl.Add(new LiteralControl("ҳ"));
			System.Web.UI.WebControls.Button btn;
			if(count>1)
			{
				btn = Button("ת��","GoToPage","sbutton",true);
				btn.CausesValidation = false;
				ctrl.Add(btn);
			}
			else
			{
				btn = Button("ת��","GoToPage","sbutton",false);
				btn.CausesValidation = false;
				ctrl.Add(btn);
			}
		}
	}

	/// <summary>
	/// һ���µ�Button����
	/// </summary>
	/// <param name="text">�ı�</param>
	/// <param name="cmd">��Ӧ����</param>
	/// <param name="css">Css���</param>
	/// <param name="enabled">����</param>
	/// <returns>Button</returns>
	public static Button Button(string text,string cmd,string css,bool enabled)
	{
		Button button = new Button();
		button.Text = text;
		button.CommandName = cmd;
		button.CssClass = css;
		button.Enabled = enabled;
		return button;
	}

	/// <summary>
	/// һ���µ�Button����
	/// </summary>
	/// <param name="text">�ı�</param>
	/// <param name="cmd">��Ӧ����</param>
	/// <param name="css">Css���</param>
	/// <param name="enabled">����</param>
	/// <returns>LinkButton</returns>
	public static LinkButton LinkButton(string text,string cmd,string css,bool enabled)
	{
		LinkButton button = new LinkButton();
		button.Text = text;
		button.CommandName = cmd;
		button.CssClass = css;
		button.Enabled = enabled;
		button.CausesValidation = false;
		return button;
	}

	/// <summary>
	/// �հ׿ؼ�
	/// </summary>
	/// <param name="count">���ٸ��հ�</param>
	/// <returns>LiteralControl</returns>
	public static LiteralControl Blank(int count)
	{
		string text = "";
		for(int i=0;i<count;i++) text += "&nbsp;";
		LiteralControl lc = new LiteralControl(text);
		return lc;
	}
		
	/// <summary>
	/// ���ӵ����Զ����ҳʱִ�еĹ���
	/// ����� /Setup/mjkzqcs.aspx �ڵ�ʹ�÷���
	/// </summary>
	/// <param name="DataGrid">DataGrid����</param>
	/// <param name="e">DataGridCommandEventArgs</param>
	public static void AddPageClick(System.Web.UI.WebControls.DataGrid DataGrid,DataGridCommandEventArgs e)
	{
		switch(e.CommandName)
		{
			case "FirstPage":
				DataGrid.CurrentPageIndex = 0;
				break;
			case "PrevPage":
				if(DataGrid.CurrentPageIndex>0)
				{
					DataGrid.CurrentPageIndex -= 1;
				}
				break;
			case "NextPage":
				if(DataGrid.CurrentPageIndex<DataGrid.PageCount-1)
				{
					DataGrid.CurrentPageIndex += 1;
				}
				break;
			case "LastPage":
				DataGrid.CurrentPageIndex = DataGrid.PageCount-1;
				break;
			case "GoToPage":
				TextBox tb = (TextBox)e.Item.Cells[0].FindControl("txtPage");
				int page = 0;
				try
				{
					page = int.Parse(tb.Text);
				}
				catch
				{
				}
				if(page<=0)
				{
					page=0; 
				}
				else
				{
					if(page<DataGrid.PageCount)
						page -= 1;
					else
						page = DataGrid.PageCount - 1;
				}
				DataGrid.CurrentPageIndex = page;
				break;
			default:break;
		}
		if(DataGrid.CurrentPageIndex>DataGrid.PageCount-1)
			DataGrid.CurrentPageIndex = DataGrid.PageCount - 1;
	}
	#endregion
}
	
