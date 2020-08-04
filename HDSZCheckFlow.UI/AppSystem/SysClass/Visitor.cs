using  System;
using  System.Web;
using  System.Xml;
using  System.Web.UI;

	public class Visitor 
	{ 
		private string filename; 
		public Visitor() 
		{ 
			filename = GetWebSitePhyPath + "Web.Config" ;
		} 

		public string GetWebSitePhyPath
		{ 
			get
			{
				HttpContext context;
				context = HttpContext.Current; 
				string WebSiteRootPath; 
				WebSiteRootPath = context.Request.ServerVariables["APPL_PHYSICAL_PATH"]; 
				return WebSiteRootPath;
			}
			
		} 

		public string GetWebSiteRootPath
		{ 
			get
			{
				HttpContext  context;
				context = HttpContext.Current ;
				string WebSitePagePath;
				WebSitePagePath=context.Request.ServerVariables["PATH_INFO"];
				int intHgPosition=WebSitePagePath.IndexOf("/",1,WebSitePagePath.Length-1);
				if(intHgPosition<0)
				{
					return "";
				}
				else
				{
					return WebSitePagePath.Substring(0,intHgPosition+1);
				}
			}
		} 

		public string GetWebSiteFullPath
		{
			get
			{
				HttpContext  context;
				context = HttpContext.Current ;
				string WebSitePageFullPath;
				WebSitePageFullPath="http://" + context.Request.ServerVariables["Server_Name"] + context.Request.ServerVariables["PATH_INFO"] ;
				return WebSitePageFullPath;
			}
		}

		public void UpDateLastOpationTime(string UserName) 
		{ 
			DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
			string SelectString; 
			SelectString = "UpDate xpGrid_User Set LastOprtnDateTime='" + DateTime.Now.ToString()  + "' Where Upper(UserName)='" + UserName.ToUpper() + "'"; 
			dbHand.ExecuteNonQuery(SelectString); 
			dbHand.Close(); 
		} 

		public bool GetSystemEnable
		{ 
			get
			{
				DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler();
				string SelectString ;
				SelectString="Select SystemEnable From xpGrid_SystemParameter Where ParaRecId=1";
				bool Result;
				Result=(System.Convert.ToInt32(dbHand.ExecuteScalar(SelectString))==1);
				dbHand.Close();
				if (Result)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		} 

		public void SetSystemEnable()
		{ 
			DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler();
			string SelectString;
			if (this.GetSystemEnable)
			{
				SelectString="UpDate xpGrid_SystemParameter Set SystemEnable=0 Where ParaRecId=1";
			}
			else
			{
				SelectString="UpDate xpGrid_SystemParameter Set SystemEnable=1 Where ParaRecId=1";
			}
			dbHand.ExecuteNonQuery(SelectString);
			dbHand.Close();
		} 

		public int GetOnlineVisitorNum 
		{ 
			get 
			{ 
				DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
				string TempCommand = "Select Count(*) From xpGrid_User Where Online=1"; 
				int Result=0;
				Result=(int)dbHand.ExecuteScalar(TempCommand);
				dbHand.Close();
				return Result;
			} 
		} 

		public void SetMaxOnlineVisitorNum(int MaxNum) 
		{ 
			DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler ();
			string SelectString;
			SelectString="UpDate xpGrid_SystemParameter Set MaxOnlineVisitor="+MaxNum.ToString()+" Where ParaRecId=1";
			dbHand.ExecuteNonQuery(SelectString);
			SelectString="UpDate xpGrid_SystemParameter Set MaxOnlineDateTime='"+System.DateTime.Now+"' Where ParaRecId=1";
			dbHand.ExecuteNonQuery(SelectString);
			dbHand.Close();
		}

		public int GetMaxOnlineVisitorNum 
		{ 
			get 
			{ 
				DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler();
				string SelectString;
				SelectString="Select MaxOnlineVisitor From xpGrid_SystemParameter Where ParaRecId=1";
				int Result;
				Result=System.Convert.ToInt32(dbHand.ExecuteScalar(SelectString));
				dbHand.Close();
				return Result;
			}
		} 

		public string GetMaxOnlineDateTime 
		{ 
			get 
			{ 
				DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler();
				string SelectString;
				SelectString="Select MaxOnlineDateTime From xpGrid_SystemParameter Where ParaRecId=1";
				string Result;
				Result=System.Convert.ToString(dbHand.ExecuteScalar(SelectString));
				dbHand.Close();
				return Result;
			} 
		} 

		public bool VisitorOnLine(string UserName)
		{ 
			DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
			bool Result=false;
			string TempCommand = "Select Online From xpGrid_User Where Upper(UserName)='" + UserName.ToUpper() + "'"; 
			int intOnline=(int)dbHand.ExecuteScalar(TempCommand);
			if (intOnline == 1) 
			{ 
				TempCommand = "Select DateDiff(mi,CurrentLoginDateTime,GetDate()) As 'EclipseTime' From xpGrid_User Where Upper(UserName)='" + UserName.ToUpper() + "'"; 
				if (dbHand.ExecuteScalar(TempCommand)==null) 
				{ 
					Result= true; 
				} 
				if ((int)dbHand.ExecuteScalar(TempCommand) > 10) 
				{ 
					Result= false; 
				} 
				else 
				{ 
					Result= true; 
				} 
			} 
			else 
			{ 
				Result= false; 
			} 
			dbHand.Close();
			return Result;
		} 

		public void SetVisitorState(string UserName, string State) 
		{ 
			DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
			string TempCommand; 
			if (State.Trim() == "On") 
			{ 
				TempCommand = "UpDate xpGrid_User Set Online=1,LoginTimes=LoginTimes+1,CurrentLoginDateTime='" + System.DateTime.Now.ToString() + "' Where Upper(UserName)='" + UserName.ToUpper() + "'"; 
				dbHand.ExecuteNonQuery(TempCommand); 
				UpDateLastOpationTime(UserName);
				AddVisitor(); 
				int OnlineVisitor = GetOnlineVisitorNum; 
				int MaxOnlineVisitor = GetMaxOnlineVisitorNum; 
				if (OnlineVisitor > MaxOnlineVisitor) 
				{ 
					SetMaxOnlineVisitorNum(OnlineVisitor); 
				} 
			} 
			else 
			{ 
				TempCommand = "UpDate xpGrid_User Set Online=0,LastOnlineTime=DateDiff(mi,CurrentLoginDateTime,GetDate()),AllOnlineTime=IsNull(AllOnlineTime,0)+DateDiff(mi,CurrentLoginDateTime,GetDate()) Where Upper(UserName)='" + UserName.ToUpper()+ "'"; 
				dbHand.ExecuteNonQuery(TempCommand); 
			} 
			dbHand.Close(); 
		} 

		public void AddVisitor() 
		{ 
			DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler ();
			string SelectString;
			SelectString="UpDate xpGrid_SystemParameter Set AllVisitor=AllVisitor+1 Where ParaRecId=1";
			dbHand.ExecuteNonQuery(SelectString);
			dbHand.Close();
		} 

		public int GetAllVisitNum 
		{ 
			get 
			{ 
				DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler();
				string SelectString;
				SelectString="Select AllVisitor From xpGrid_SystemParameter Where ParaRecId=1";
				int Result;
				Result=System.Convert.ToInt32(dbHand.ExecuteScalar(SelectString));
				dbHand.Close();
				return Result;
			} 
		} 

		public string GetUserId 
		{ 
			get 
			{ 
				DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
				Page CurrentPage = new Page(); 
				string TempId = CurrentPage.User.Identity.Name.Trim(); 
				string TempCommand = "Select UserName From xpGrid_User Where UserId=" + TempId; 
				string Result = (string)dbHand.ExecuteScalar(TempCommand); 
				dbHand.Close(); 
				return Result; 
			} 
		} 

		public string GetUserName 
		{ 
			get 
			{ 
				DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
				string TempCommand = "Select Name From Bl_Personnel_All Where Upper(NameNo)='" + GetUserId.ToUpper() + "'"; 
				string Result = (string)dbHand.ExecuteScalar(TempCommand); 
				dbHand.Close(); 
				if (Result != null) 
				{ 
					return Result; 
				} 
				else 
				{ 
					return GetUserId; 
				} 
			} 
		} 

		public string GetUserRole 
		{ 
			get 
			{ 
				try
				{
					Page CurrentPage = new Page(); 
					string TempId = CurrentPage.User.Identity.Name.Trim(); 
					string TempCommand = "Select RoleId From xpGrid_UsersInRoles Where UserId='" + TempId + "'"; 
					DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
					int TempRoleId = (int)dbHand.ExecuteScalar(TempCommand); 
					TempCommand = "Select RoleName From xpGrid_Role Where RoleId=" + TempRoleId.ToString() ; 
					string Result = (string)dbHand.ExecuteScalar(TempCommand); 
					dbHand.Close(); 
					return Result; 
				}
				catch
				{
					return "ÎÞÈ¨ÏÞ";
				}
			} 
		} 

		public int GetUserPageSize
		{
			get
			{
				string strSelect;
				strSelect="Select isnull(pagesize,10) From SYS_RIGHT_USER Where userlogin='"+GetUserId+"'";
				int Result;
				Result=Convert.ToInt32(FuncClass.ExecuteCmdScalar(strSelect));
				if (Result<=0)
				{
					return 10;
				}
				else
				{
					return Result;
				}
			}
		}
		public string GetUserDeptRight
		{
			get
			{
				string strSelect;
				strSelect="Select isnull(depart,'0') From SYS_RIGHT_USER Where userlogin='"+GetUserId+"'";
				string Result;
				Result=Convert.ToString(FuncClass.ExecuteCmdScalar(strSelect));
				if (Result=="")
				{
					return "'0'";
				}
				else
				{
					return Result;
				}
			}
		}
		public string GetUserDeptRightCode
		{
			get
			{
				string strSelect;
				System.Data.DataTable DeptList=new System.Data.DataTable();
				string Result="";
				strSelect="Select Distinct Substring(Bmbh,2,5) As Bmbh From KQ_CS_GZB Where bmid In ("+this.GetUserDeptRight+") Order By Bmbh";
				DeptList=FuncClass.ExecuteCmdDataTable(strSelect,"DeptList");
				if(DeptList.Rows.Count>0)
				{
					for(int i=0;i<DeptList.Rows.Count;i++)
					{
						Result=Result+","+Convert.ToString(DeptList.Rows[i]["Bmbh"]);
					}
				}
				return Result.Substring(1,Result.Length-1);
			}
		}

		public string GetUserGroup
		{
			get
			{
				string strSelect;
				strSelect="Select UserGroup From SYS_RIGHT_USER Where userlogin='"+GetUserId+"'";
				return Convert.ToString(FuncClass.ExecuteCmdScalar(strSelect));
			}
		}

		public string GetAppName 
		{ 
			get 
			{ 
				DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler();
				string SelectString;
				SelectString="Select AppName From xpGrid_SystemParameter Where ParaRecId=1";
				string Result;
				Result=System.Convert.ToString(dbHand.ExecuteScalar(SelectString));
				dbHand.Close();
				return Result;

			} 
		} 
	}


