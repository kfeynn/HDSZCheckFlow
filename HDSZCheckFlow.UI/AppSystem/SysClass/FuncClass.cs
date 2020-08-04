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
		// TODO: 在此处添加构造函数逻辑
		//	
	}

	public static string ConnectionString
	{
		get 
		{
			return ControlString;
		}
			
	}

	#region GetBmbhNext函数
	/// 返回在同一个一级部门下最大的部门编号
	public static string GetBmbhNext(string csbmbh) 
	{
		string ls_bmbhnext;
		if(csbmbh=="0000") //选择全部部门
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

	#region 设置在页面回车时触发事件的控件
	/// <summary> 
	/// 设置在页面回车时触发事件的控件 
	/// </summary> 
	/// <param name="Ctrl">将触发事件的控件对象</param> 
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

	#region 日期选择控件
	/// <summary>
	/// 日期选择控件
	/// </summary>
	/// <param name="begindate">开始日期</param>
	/// <param name="enddate">结束日期</param>
	public static void InitDate(TextBox begindate,TextBox enddate)
	{
		begindate.Text = DateTime.Now.ToString("yyyy-MM-01");
		enddate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			
		InitDate(new TextBox[]{begindate,enddate});
	}
	/// <summary>
	/// 日期选择控件
	/// </summary>
	/// <param name="date">输入日期的TextBox控件组</param>
	public static void InitDate(TextBox[] date)
	{
		InitDate(date,2);
	}
	/// <summary>
	/// 日期选择控件
	/// </summary>
	/// <param name="date">输入日期的TextBox控件组</param>
	public static void InitDate(TextBox date)
	{
		InitDate(new TextBox[]{date});
	}

	/// <summary>
	/// 日期选择控件
	/// </summary>
	/// <param name="date">输入日期的TextBox控件组</param>
	/// <param name="index">显示位置</param>
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

	#region 为下拉列表绑定数据
	// 编写者：夏荣全
	/// <summary>
	/// 为下拉列表绑定数据
	/// </summary>
	/// <param name="ddl">要绑定数据的DropDownList对象</param>
	/// <param name="table">数据表</param>
	/// <param name="textField">文本字段</param>
	/// <param name="valueField">值字段</param>
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
	/// 为下拉列表绑定数据
	/// </summary>
	/// <param name="ddl">要绑定数据的DropDownList对象</param>
	/// <param name="cmdText">查询文本</param>
	/// <param name="textField">文本字段</param>
	/// <param name="valueField">值字段</param>
	public static void DDLDataBind(Control ctrl,string cmdText,string textField,string valueField)
	{
		DataTable tbl_data = ExecuteCmdDataTable(cmdText,"tbl_data");
		DDLDataBind(ctrl,tbl_data,textField,valueField);
	}

	/// <summary>
	/// 为下拉列表绑定数据
	/// </summary>
	/// <param name="ddl">要绑定数据的DropDownList对象</param>
	/// <param name="cmd">SqlCommand实例</param>
	/// <param name="textField">文本字段</param>
	/// <param name="valueField">值字段</param>
	public static void DDLDataBind(Control ctrl,SqlCommand cmd,string textField,string valueField)
	{
		DataTable tbl_data = ExecuteCmdDataTable(cmd,"tbl_data");
		DDLDataBind(ctrl,tbl_data,textField,valueField);
	}

	/// <summary>
	/// 为下拉列表绑定数据
	/// </summary>
	/// <param name="ddl">要绑定数据的DropDownList对象</param>
	/// <param name="cmdText">查询文本</param>
	public static void DDLDataBind(Control ctrl,string cmdText)
	{
		DataTable tbl_data = ExecuteCmdDataTable(cmdText,"tbl_data");
		DDLDataBind(ctrl,tbl_data,tbl_data.Columns[0].ColumnName,tbl_data.Columns[1].ColumnName);
	}

	/// <summary>
	/// 为下拉列表绑定数据
	/// </summary>
	/// <param name="ddl">要绑定数据的DropDownList对象</param>
	/// <param name="cmd">SqlCommand实例</param>
	public static void DDLDataBind(Control ctrl,SqlCommand cmd)
	{
		DataTable tbl_data = ExecuteCmdDataTable(cmd,"tbl_data");
		DDLDataBind(ctrl,tbl_data,tbl_data.Columns[0].ColumnName,tbl_data.Columns[1].ColumnName);
	}
	#endregion

	#region 去除字符串两头的指定子字符串
	/// <summary>
	/// 从oldstring串头部去除substing子串的连续匹配。
	/// </summary>
	/// <param name="oldstring">原字符串</param>
	/// <param name="substring">要求去除的子串</param>
	/// <returns>返回去除子串的后的字符串</returns>
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
	/// 从oldstring串尾部去除substing子串的连续匹配。
	/// </summary>
	/// <param name="oldstring">原字符串</param>
	/// <param name="substring">要求去除的子串</param>
	/// <returns>返回去除子串的后的字符串</returns>
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
	/// 从oldstring串头尾去除substing子串的连续匹配。
	/// </summary>
	/// <param name="oldstring">原字符串</param>
	/// <param name="substring">要求去除的子串</param>
	/// <returns>返回去除子串的后的字符串</returns>
	public static string Trim(string oldstring,string substring)
	{
		if (substring=="") return oldstring;
		oldstring=LTrim(oldstring, substring);
		oldstring=RTrim(oldstring,substring);
		return oldstring;
	}

	#endregion

	#region 页面初始化函数
	public static void InitPage(Control ctrl)
	{
		InitPage(ctrl.Page);
		SetEnterControl(ctrl);
	}
	/*
		 * 编写:曹磊
		*/
	/// <summary>
	/// 页面初始化函数，判断登陆是否超时，用户是否有权限访问页面
	/// </summary>
	/// <param name="pg_InitPage"></param>
	public static void InitPage(System.Web.UI.Page pg_InitPage) 
	{            
  

		//			string str_classname,str_CmdText;
		//			int int_start,int_end,int_count;
		//			
		//			//判断是否超时
		//			if (pg_InitPage.Session .Count >0)	
		//			{					
		//				if (!pg_InitPage.IsPostBack )
		//				{
		//					str_classname=pg_InitPage.ToString ();
		//					int_start=str_classname.LastIndexOf ("ASP.")+4;
		//					int_end=str_classname.LastIndexOf ("_aspx");
		//					str_classname=str_classname.Substring (int_start,int_end-int_start);
		//					//先判断是否是受控页面。
		//					str_CmdText="Select Count(classname) From SYS_RIGHT_CLASS Where classname='"+str_classname+"'";
		//					int_count=System.Convert .ToInt32 (ExecuteCmdScalar(str_CmdText));
		//					if (int_count>0)
		//					{
		//						//是受控页面，查看当前用户是否有权限访问。
		//						UserClass User=(UserClass)pg_InitPage.Session ["SYSUSER"];
		//						str_CmdText=@"Select Count(classname) From SYS_RIGHT_GROUPRIGHT Join SYS_RIGHT_CLASS 
		//								On SYS_RIGHT_GROUPRIGHT.menuno=SYS_RIGHT_CLASS.menuno 
		//								and SYS_RIGHT_GROUPRIGHT.groupnumber=";
		//						str_CmdText+=User.UserGroup .ToString ()+"And SYS_RIGHT_CLASS.classname='"+str_classname+"'";
		//						int_count=System.Convert .ToInt32 (ExecuteCmdScalar(str_CmdText));
		//						if (int_count==0)
		//						{
		//							//pg_InitPage.Response .Write ("没有权限");
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
		//				//pg_InitPage.Response .Write ("登陆超时");
		//				//pg_InitPage.Response.End ();
		//				
		//			}
		//            string str_CmdText;
		//            int int_count;
		//			
		//            //判断是否超时
		//			if (pg_InitPage.Session .Count >0)	
		//			{					
		//				if (!pg_InitPage.IsPostBack )
		//				{
		////					str_classname=pg_InitPage.ToString ();
		////					int_start=str_classname.LastIndexOf ("ASP.")+4;
		////					int_end=str_classname.LastIndexOf ("_aspx");
		////					str_classname=str_classname.Substring (int_start,int_end-int_start);
		////					//先判断是否是受控页面。
		////					str_CmdText="Select Count(classname) From SYS_RIGHT_CLASS Where classname='"+str_classname+"'";
		////					int_count=System.Convert .ToInt32 (ExecuteCmdScalar(str_CmdText));
		////					if (int_count>0)
		////					{
		////						//是受控页面，查看当前用户是否有权限访问。
		////						UserClass User=(UserClass)pg_InitPage.Session ["SYSUSER"];
		////						str_CmdText=@"Select Count(classname) From SYS_RIGHT_GROUPRIGHT Join SYS_RIGHT_CLASS 
		////								On SYS_RIGHT_GROUPRIGHT.menuno=SYS_RIGHT_CLASS.menuno 
		////								and SYS_RIGHT_GROUPRIGHT.groupnumber=";
		////						str_CmdText+=User.UserGroup .ToString ();
		////						int_count=System.Convert .ToInt32 (ExecuteCmdScalar(str_CmdText));
		////						if (int_count==0)
		////						{
		////							//pg_InitPage.Response .Write ("没有权限");
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
		//				//pg_InitPage.Response .Write ("登陆超时");
		//				//pg_InitPage.Response.End ();
		//				
		//			}
			
	}

	#endregion

	#region 建用户部门树

	/// <summary>
	/// 将用户拥有管理权限的部门构建树型结构
	/// </summary>
	/// <param name="tree">要建的部门树</param>
	/// <param name="department">用户拥有管理权限的部门列表，以","分开bmid字段</param>
	/// <param name="behavior">父部门是否做为自己的第一个子部门重新，当为true时重建，并且父部门结点的NodeData为空,false时不重建</param>
	/// <param name="parentcheckbox" >父部门是否有CheckBox框</param>

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
	/// <param name="department">用户拥有管理权限的部门列表，以","分开bmid字段</param>
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
	/// <param name="field">设定树的nodevalue为何值</param>
	public static void BindDepart(Microsoft.Web .UI .WebControls.TreeView tree,string department,bool behavior,bool parentcheckbox,string field)
	{		
		string str_CmdText="Select  bmgx+convert(varchar(7),bmid)+'_' bmgx,"+field+",bmmc+'('+bmbh+')' ,'F' From KQ_CS_BM Where bmid In ("+department+") Order By bmgx,bmbh";
		DataTable dtbl_Depart=ExecuteCmdDataTable (str_CmdText,"depart");
		FuncClass.BuildTree(tree,dtbl_Depart,behavior,parentcheckbox);
	}

	#endregion
        
	#region BindData函数
	/// <summary>
	/// 将查询出的数据绑定到webc_InControl控件，并返回记录条数
	/// </summary>
	/// <param name="webc_InControl">要绑定数据的控件</param>
	/// <param name="str_CmdText">查询数据的Sql语句</param>
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
	/// 将查询出的数据绑定到webc_InControl控件，并返回记录条数
	/// </summary>
	/// <param name="webc_InControl">要绑定数据的控件</param>
	/// <param name="cmd_InCmd">查询数据SqlCommand对象</param>
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

	#region ExecuteCmdNonQuery函数
	/// <summary>
	/// 执行Sql语句，返回受影响的行。对ExecuteNonQuery的封装
	/// </summary>
	/// <param name="str_CmdText">Sql语句</param>
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
	/// 执行Sql语句，返回受影响的行。对ExecuteNonQuery的封装
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand对象</param>
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

	#region ExecuteCmdScalar函数
	/// <summary>
	/// 执行Sql语句，返回结果集第一行第一列。对ExecuteScalar的封装
	/// </summary>
	/// <param name="str_CmdText">Sql语句</param>
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
	/// 执行Sql语句，返回结果集第一行第一列。对ExecuteScalar的封装
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand对象</param>
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

	#region ExecuteCmdDataSet函数
	/// <summary>
	/// 执行Sql语句，并返回包括结果集的DataSet对象
	/// </summary>
	/// <param name="str_CmdText">Sql语句</param>
	/// <param name="tb_table">结果集的表名</param>
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
	/// 执行Sql语句，并返回包括结果集的DataSet对象
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand对象</param>
	/// <param name="tb_table">结果集的表名</param>
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

	#region ExecuteCmdDataTableb函数
	/// <summary>
	/// 执行Sql语句，并返回包括结果集的DataTable对象
	/// </summary>
	/// <param name="str_CmdText">Sql语句</param>
	/// <param name="tb_table">结果集的表名</param>
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
	/// 执行Sql语句，并返回包括结果集的DataTable对象
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand对象</param>
	/// <param name="tb_table">结果集的表名</param>
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

	#region ExecuteCmdDataRow函数
	/// <summary>
	/// 执行Sql语句，并返回包括结果集的第一行结果，如果结果集为空，返回null
	/// </summary>
	/// <param name="str_CmdText">Sql语句</param>
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
	/// 执行Sql语句，并返回包括结果集的第一行结果，如果结果集为空，返回null
	/// </summary>
	/// <param name="cmd_InCmd">SqlCommand对象</param>
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

	#region 创建树
	/*
		 * 编写：曹磊
		 * 由符合一定结构的表创建树结构
		 */
	/// <summary>
	/// 由一行记录产生Node结点;
	/// 记录行的第二列必须存在，对应NodeData属性；
	/// 记录行的第三列必须存在，对应Text属性；
	/// 第四列如果存在，则值为T时结点有CheckBox,并选中，值为F时有CheckBox,但没有选中，其它值，没有CheckBox;
	/// 第五列如果存在，则值为Node的NavigateUrl属性
	/// </summary>
	/// <param name="row">包括结点各属性的记录行</param>
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
	/// 由DataTable中数据产生Node集合。
	/// 表第一列必须存在，由它产生Node的级别关系
	/// 表第二列必须存在，对应NodeData属性；
	/// 表第三列必须存在，对应Text属性；
	/// 表第四列如果存在，则值为T时结点有CheckBox,并选中，值为F时有CheckBox,但没有选中，其它值，没有CheckBox;
	/// 表第五列如果存在，则值为Node的NavigateUrl属性
	/// </summary>
	/// <param name="nodes">须扩展的TreeNodeCollection对象</param>
	/// <param name="table">包括数据的DataTable</param>
	/// <param name="index">DataTable中开始构建Note结点的记录索引</param>
	/// <param name="parent">做为TreeNodeCollection中所有Node结点的级别关键字</param>
	/// <param name="behavior">父结点是否做为自己的第一个子结点重建，为true时重建，并且父结点的NodeData将为空。false时不重建，父结点保留它的NodeData数据</param>
	/// <param name="parentcheckbox" >父结点是否有CheckBox框</param>
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
					if(!parentcheckbox) //罗显华加，使部门不能选择
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
	/// 由DataTable数据集产生树型结点
	/// 表第一列必须存在，由它产生Node的级别关系
	/// 表第二列必须存在，对应NodeData属性；
	/// 表第三列必须存在，对应Text属性；
	/// 表第四列如果存在，则值为T时结点有CheckBox,并选中，值为F时有CheckBox,但没有选中，其它值，没有CheckBox;
	/// 表第五列如果存在，则值为Node的NavigateUrl属性
	/// </summary>
	/// <param name="tree">须产生的树</param>
	/// <param name="table">包括结果集的DataTable对象</param>
	/// <param name="behavior" >父结点是否做为自己的第一个子结点重建，为true时重建，并且父结点的NodeData将为空。false时不重建，父结点保留它的NodeData数据</param>
	/// <returns></returns>
	public static int BuildTree(Microsoft.Web .UI .WebControls.TreeView tree,DataTable table,bool behavior) 
	{
        //错误	7	“TreeNode”是“System.Web.UI.WebControls.TreeNode”和“Microsoft.Web.UI.WebControls.TreeNode”之间的不明确的引用	C:\Data\E盘\Finance2008\HDSZCheckFlow\HDSZCheckFlow.UI\AppSystem\SysClass\FuncClass.cs	804	57	HDSZCheckFlow.UI

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
	/// 由DataTable数据集产生树型结点
	/// 表第一列必须存在，由它产生Node的级别关系
	/// 表第二列必须存在，对应NodeData属性；
	/// 表第三列必须存在，对应Text属性；
	/// 表第四列如果存在，则值为T时结点有CheckBox,并选中，值为F时有CheckBox,但没有选中，其它值，没有CheckBox;
	/// 表第五列如果存在，则值为Node的NavigateUrl属性
	/// </summary>
	/// <param name="tree">须产生的树</param>
	/// <param name="table">包括结果集的DataTable对象</param>
	/// <param name="behavior" >父结点是否做为自己的第一个子结点重建，为true时重建，并且父结点的NodeData将为空。false时不重建，父结点保留它的NodeData数据</param>
	/// <param name="parentcheckbox" >父结点是否有CheckBox框,在表数据第四列允许结点有CheckBox框时才考虑此行为，</param>
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

	#region 为DataGrid添加分页按钮及相应功能
	/// <summary>
	/// 为DataGrid的 自定义命令按钮加载处理事件
	/// 在DataGrid的 ItemCommand 事件中调用 NetSys.FuncClass.DataGrid_ItemCommand 方法
	/// </summary>
	/// <param name="source">DataGrid对象</param>
	/// <param name="e">DataGridCommandEventArgs</param>
	/// <param name="function">处理事件</param>
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
	/// 为DataGrid添加分页按钮
	/// 编写者：夏荣全
	/// 
	/// 使用方法：(DataGrid1为要添加分页按钮的DataGrid对象)           
	/// 在DataGrid的 ItemCreated 事件中调用 NetSys.FuncClass.DataGrid_ItemCreated 方法;
	/// </summary>
	/// <param name="sender">DataGrid对象</param>
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
				ctrl.AddAt(0,LinkButton("首页","FirstPage","",true));
				ctrl.AddAt(1,Blank(2));
				ctrl.AddAt(2,LinkButton("上页","PrevPage","",true));
			}
			else
			{
				ctrl.AddAt(0,LinkButton("首页","FirstPage","",false));
				ctrl.AddAt(1,Blank(2));
				ctrl.AddAt(2,LinkButton("上页","PrevPage","",false));
			}
			ctrl.AddAt(3,Blank(2));
			ctrl.Add(Blank(2));
			if(page<count-1)
			{
				ctrl.Add(LinkButton("下页","NextPage","",true));
				ctrl.Add(Blank(2));
				ctrl.Add(LinkButton("末页","LastPage","",true));
			}
			else
			{
				ctrl.Add(LinkButton("下页","NextPage","",false));
				ctrl.Add(Blank(2));
				ctrl.Add(LinkButton("末页","LastPage","",false));
			}
			ctrl.Add(Blank(4));
			ctrl.Add(new  LiteralControl("共"+DataGrid.PageCount+"页"));
			ctrl.Add(Blank(2));
			ctrl.Add(new LiteralControl("第"));
    
			// 输入页码
			TextBox txtPage = new TextBox();
			txtPage.ID = "txtPage";
			txtPage.Text = Convert.ToString(DataGrid.CurrentPageIndex+1);
			txtPage.Attributes.Add("style","width: 40px;");
			txtPage.CssClass = "inputbox";
			ctrl.Add(txtPage);

			ctrl.Add(new LiteralControl("页"));
			System.Web.UI.WebControls.Button btn;
			if(count>1)
			{
				btn = Button("转到","GoToPage","sbutton",true);
				btn.CausesValidation = false;
				ctrl.Add(btn);
			}
			else
			{
				btn = Button("转到","GoToPage","sbutton",false);
				btn.CausesValidation = false;
				ctrl.Add(btn);
			}
		}
	}

	/// <summary>
	/// 一个新的Button对象
	/// </summary>
	/// <param name="text">文本</param>
	/// <param name="cmd">相应命令</param>
	/// <param name="css">Css风格</param>
	/// <param name="enabled">可用</param>
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
	/// 一个新的Button对象
	/// </summary>
	/// <param name="text">文本</param>
	/// <param name="cmd">相应命令</param>
	/// <param name="css">Css风格</param>
	/// <param name="enabled">可用</param>
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
	/// 空白控件
	/// </summary>
	/// <param name="count">多少个空白</param>
	/// <returns>LiteralControl</returns>
	public static LiteralControl Blank(int count)
	{
		string text = "";
		for(int i=0;i<count;i++) text += "&nbsp;";
		LiteralControl lc = new LiteralControl(text);
		return lc;
	}
		
	/// <summary>
	/// 增加单击自定义分页时执行的过程
	/// 请参照 /Setup/mjkzqcs.aspx 内的使用方法
	/// </summary>
	/// <param name="DataGrid">DataGrid对象</param>
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
	
