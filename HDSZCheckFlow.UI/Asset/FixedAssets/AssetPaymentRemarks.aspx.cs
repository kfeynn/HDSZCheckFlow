using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using entiy=HDSZCheckFlow.Entiy;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace HDSZCheckFlow.UI.FixedAssets
{
	/// <summary>
	/// AssetPaymentRemarks 的摘要说明。
	/// </summary>
	public class AssetPaymentRemarks : System.Web.UI.Page
	{

		HDSZCheckFlow.Entiy.PageViewState pageF = null;
		 
		/// <summary>
		/// 要显示的表或多个表的连接 
		/// </summary>
	
		public string TblName
		{
			get { return ViewState["TblName"].ToString(); }
			set { ViewState["TblName"] = value; }
		}


		/// <summary>
		/// 要显示的字段列表
		/// </summary>
		
		public string FldName
		{
			get { return ViewState["FldName"].ToString(); }
			set { ViewState["FldName"] = value; }
		}

		
		/// <summary>
		/// 每页显示的记录个数 
		/// </summary>
		public int PageSize
		{
			get { return  Convert.ToInt32( ViewState["PageSize"]); }
			set { ViewState["PageSize"] = value; }
		}


		/// <summary>
		/// 要显示那一页的记录
		/// </summary>
	
		public int Pages
		{
			get { return Convert.ToInt32( ViewState["Pages"]); }
			set { ViewState["Pages"] = value; }
		}
	

		/// <summary>
		/// 排序字段列表或条件 
		/// </summary>
		public string FldSort
		{
			get { return ViewState["FldSort"].ToString(); }
			set { ViewState["FldSort"] = value; }
		}


		/// <summary>
		/// 排序方法，1为升序，0为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')  
		/// </summary>
		public int Sort
		{
			get { return Convert.ToInt32(ViewState["Sort"]); }
			set { ViewState["Sort"] = value; }
		}


		/// <summary>
		/// 查询条件,不需where  
		/// </summary>
		public string StrCondition
		{
			get { return ViewState["StrCondition"].ToString(); }
			set { ViewState["StrCondition"] = value; }
		}


		/// <summary>
		/// 主表的主键  
		/// </summary>
		public string id
		{
			get { return  ViewState["id"].ToString(); }
			set { ViewState["id"] = value; }
		}
		

		/// <summary>
		/// 是否添加查询字段的 DISTINCT 默认0不添加/1添加  
		/// </summary>
		
		public int Dist
		{
			get { return Convert.ToInt32(ViewState["Dist"]); }
			set { ViewState["Dist"] = value; }

		}


		/// <summary>
		/// 查询结果分页后的总页数 
		/// </summary>
		public int PageCount
		{
			get { return Convert.ToInt32( ViewState["PageCount"]); }
			set { ViewState["PageCount"] = value; }

		}

		
		/// <summary>
		/// 查询到的记录数  
		/// </summary>
		public int Counts
		{
			get { return Convert.ToInt32( ViewState["Counts"]); }
			set { ViewState["Counts"] = value; }

		}
		
		
		/// <summary>
		/// 保存主体的主键 
		/// </summary>
		public int Rownum
		{
			get { return Convert.ToInt32( ViewState["Rownum"]); }
			set { ViewState["Rownum"] = value; }

		}

		/// <summary>
		/// 保存裁决金额 
		/// </summary>
		public int SumMoney
		{
			get { return Convert.ToInt32( ViewState["SumMoney"]); }
			set { ViewState["SumMoney"] = value; }

		}

		#region
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
		protected System.Web.UI.WebControls.RadioButton rbtMark1;
		protected System.Web.UI.WebControls.RadioButton rbtMark2;
		protected System.Web.UI.WebControls.RadioButton rbtMark3;
		protected System.Web.UI.WebControls.TextBox txtProduct;
		protected System.Web.UI.WebControls.TextBox txtOrderNumber;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label lblPage;
		protected System.Web.UI.WebControls.Button btnFrist;
		protected System.Web.UI.WebControls.Button btnPageShi;
		protected System.Web.UI.WebControls.Button btnShang;
		protected System.Web.UI.WebControls.Button btnXia;
		protected System.Web.UI.WebControls.Button btnTuiShi;
		protected System.Web.UI.WebControls.Button btnMo;
		protected System.Web.UI.WebControls.Label lblTiao;
		protected System.Web.UI.WebControls.TextBox txtPage;
		protected System.Web.UI.WebControls.Button btnGo;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.CheckBox chbSelectAll;
		protected System.Web.UI.WebControls.Button btnUpdateShuju;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.CheckBox CheckBox3;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.CheckBox CheckBox2;
		protected System.Web.UI.WebControls.RadioButton rbtIsInStoreNo;
		protected System.Web.UI.WebControls.RadioButton rbtIsInStoreALL;
		protected System.Web.UI.WebControls.RadioButton rbtIsInStoreYes;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
	
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				this.getPageViewLoad(1,"",0,0);
				
			}
		}


		/// <summary>
		///	保存属性
		/// </summary>
		private void getPageViewstate(string tblName,string fldName,int pageSize,int page,string fldSort ,int sort,string strCondition,string iD,int dist,int pageCount,int counts)
		{
			pageF = new HDSZCheckFlow.Entiy.PageViewState();
			pageF.TblName = tblName;
			pageF.FldName = fldName;
			pageF.PageSize = pageSize;
			pageF.Page = page;
			pageF.FldSort = fldSort;
			pageF.Sort = sort;
			pageF.StrCondition = strCondition;
			pageF.ID = iD;
			pageF.Dist = dist;
			pageF.PageCount = pageCount;
			pageF.Counts = counts;
			this.saveState(tblName, fldName, pageSize, page, fldSort , sort, strCondition, iD, dist, pageCount, counts);
			
		}

		/// <summary>
		/// 保持属性
		/// </summary>
		private void saveState(string tblName,string fldName,int pageSize,int page,string fldSort ,int sort,string strCondition,string iD,int dist,int pageCount,int counts)
		{
			this.TblName =tblName;
			this.FldName = fldName;
			this.PageSize = pageSize;
			this.Pages = page;
			this.FldSort = fldSort;
			this.Sort = sort;
			this.StrCondition = strCondition;
			this.id = iD;
			this.Dist = dist;
			this.PageCount = pageCount;
			this.Counts = counts;
		}


		/// <summary>
		/// 
		/// 分页
		/// </summary>
		private void getPageViewLoadMain(int page1 ,string strCondition1,int pageCount1,int counts1)
		{
			//要显示的表或多个表的连接  
			string tblName ="[Asset_FinallyPriceCheck] as a inner JOIN [Asset_FinallyPriceCheck_Body] as b ON  a.[id]=b.[FinallyPriceCheck_Id] inner join [v_FinallyPriceCheckList] as c on a.[id] = c.[id] ";
			//显示字段
			string fldName = @"a.id as aid ,b.Id ,b.ReallyPayMoney,a.ItemName,a.[ApplySheetHead_Pk],a.[PriceCheckSheetNo],a.ApplyDeptClassCode,a.ApplyDeptCode,a.ApplyPersonCode,a.MakeDate,a.BargainNo,b.[FinallyPriceCheck_Id],b.SubjectName,b.[Asset_ApplySheet_Body_Id],b.Offer,b.Article,b.Remark,b.Number,b.originalcurrPrice,b.currTypeCode,b.FinallyPrice,b.IsPayFor,b.PayForSigner,b.PayForDatetime,b.PayForRemark";
			//页显示条数
			int pageSize = 5;
			//排序字段列表或条件  
			string FldSort  ="MakeDate";
			//排序方法，1为升序，0为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')  
			int Sort = 1;
			//主表的主键 //应该为表体的主键
			string ID = "ID";
			//是否添加查询字段的 DISTINCT 默认0不添加/1添加 
			int Dist = 0;
			//pageCount    int = 1 output,            ----查询结果分页后的总页数  out
			this.getPageViewstate(  tblName, fldName, pageSize, page1, FldSort , Sort, strCondition1, ID, Dist, pageCount1, counts1);
			//返回有预付费用的项目
			
			try
			{
				DataSet dsProc_DataPagination = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.GetPageDataPagination( pageF);
				this.dgApply.DataSource = dsProc_DataPagination.Tables[0];
				this.dgApply.DataBind();
				this.PageCount = pageF.PageCount;
				this.Counts = pageF.Counts;
				if(page1 > PageCount)
				{
					this.Pages = PageCount;
				}
				else if(page1 <= 0)
				{
					this.Pages = 1;
				}
				this.lblPage.Text = "第 "+this.Pages.ToString()+" 页 共 "+this.PageCount.ToString()+" 页  总记录数 "+this.Counts.ToString()+ "  条";
				
			}			
			catch(Exception ex)			
			{		
				
				Common.Log.Logger.Log("HDSZCheckFlow.UI.FixedAssets.AssetPaymentRemarks.aspx",ex.ToString());		
			}	
		}
			



		/// <summary>
		/// 初始化数据
		/// </summary>
		private void getPageViewLoad(int page,string strCondition,int pageCount,int counts)
		{
			try
			{
				this.Panel1.Visible=false;	
				this.getPageViewLoadMain(page , strCondition, pageCount, counts);
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("HDSZCheckFlow.UI.FixedAssets.AssetPaymentRemarks.aspx",ex.ToString());		
			}		
			 	

		}

	

		/// <summary>
		/// 组织查询条件
		/// </summary>
		/// <returns></returns>
		private string getStrCondition()
		{
			//txtApplyNo 表   单  号
			//txtProduct  项 目 名 称
			//txtOrderNumber  合   同  号
			//rbtMark1 是
			//rbtMark2 否
			//rbtMark3 全 默认为全 
			
			#region  整理查询条件
			
			StringBuilder filter=new StringBuilder();
			if(this.CheckBox2.Checked)
			{
				//表单号的查询条件
				if(!"".Equals(this.txtApplyNo.Text))
				{
					//				if(filter.Length>0)
					//				{
					//					filter.Append(" and ");
					//				}
					filter.Append(" and ");
					//整理 this.txtApplyNo.Text ,逗号分隔    前后添加上 单引号
					string querySheetNoStr = "";
					string []tempStr = this.txtApplyNo.Text.Split(new char[] {','});
					foreach(string aaStr in tempStr)
					{
						if(querySheetNoStr.Length > 0 )
						{
							querySheetNoStr = querySheetNoStr + "," + "'" + aaStr + "'" ;
						}
						else
						{
							querySheetNoStr =  "'" + aaStr + "'" ; 
						}
					}

					filter.Append(" PriceCheckSheetNo in  " +" (" + querySheetNoStr + ")" );
				}
				//项目名称查询条件 
				if(!"".Equals(this.txtProduct.Text))
				{
				
					filter.Append(" and ");
				

					//整理 this.txtProduct.Text ,逗号分隔    前后添加上 单引号
					string queryProductStr = "";
					string []testStr = this.txtProduct.Text.Split(new char[] {','});
					foreach(string aaaStr in testStr)
					{
						if(queryProductStr.Length > 0 )
						{
							queryProductStr = queryProductStr + "," + "'" + aaaStr + "'" ;
						}
						else
						{
							queryProductStr =  "'" + aaaStr + "'" ; 
						}
					}

					filter.Append(" ItemName in   " +"(" + queryProductStr + ")" );
				}
			
				if(!this.rbtIsInStoreALL.Checked)
				{
				
					filter.Append(" and ");
				
					if(this.rbtIsInStoreYes.Checked )
					{
						filter.Append("IsInStore  = 1 " );
					}
					else
					{
						filter.Append(" (IsInStore = 0 or IsInStore is null) " );
					}
				}
			
				//合同号 单个BargainNo
				if(!"".Equals(this.txtOrderNumber.Text))
				{
				
					filter.Append(" and ");
				

					//整理 this.txtOrderNumber.Text 
					string queryProductStr = this.txtOrderNumber.Text.Trim().ToString();

					filter.Append(" (BargainNo like  '%" + queryProductStr + "%')" );
				
				}
			}
			else
			{
				//表单号的查询条件
				if(!"".Equals(this.txtApplyNo.Text))
				{
					//				if(filter.Length>0)
					//				{
					//					filter.Append(" and ");
					//				}
					filter.Append(" and ");
					//整理 this.txtApplyNo.Text ,逗号分隔    前后添加上 单引号
					string querySheetNoStr = "";
					string []tempStr = this.txtApplyNo.Text.Split(new char[] {','});
					foreach(string aaStr in tempStr)
					{
						if(querySheetNoStr.Length > 0 )
						{
							querySheetNoStr = querySheetNoStr + "," + "'" + aaStr + "'" ;
						}
						else
						{
							querySheetNoStr =  "'" + aaStr + "'" ; 
						}
					}

					filter.Append(" PriceCheckSheetNo in  " +" (" + querySheetNoStr + ")" );
				}
				//项目名称查询条件 
				if(!"".Equals(this.txtProduct.Text))
				{
				
					filter.Append(" and ");
				

					//整理 this.txtProduct.Text ,逗号分隔    前后添加上 单引号
					string queryProductStr = "";
					string []testStr = this.txtProduct.Text.Split(new char[] {','});
					foreach(string aaaStr in testStr)
					{
						if(queryProductStr.Length > 0 )
						{
							queryProductStr = queryProductStr + "," + "'" + aaaStr + "'" ;
						}
						else
						{
							queryProductStr =  "'" + aaaStr + "'" ; 
						}
					}

					filter.Append(" ItemName in   " +"(" + queryProductStr + ")" );
				}
			
				//是否含有付款 IsPayFor
				if(!this.rbtMark3.Checked)
				{
				
					filter.Append(" and ");
				
					if(this.rbtMark1.Checked )
					{
						filter.Append(" IsPayFor = 1 " );
					}
					else
					{
						filter.Append(" (IsPayFor = 0 or IsPayFor is null) " );
					}
				}
			
				//合同号 单个BargainNo
				if(!"".Equals(this.txtOrderNumber.Text))
				{
				
					filter.Append(" and ");
				

					//整理 this.txtOrderNumber.Text 
					string queryProductStr = this.txtOrderNumber.Text.Trim().ToString();

					filter.Append(" (BargainNo like  '%" + queryProductStr + "%')" );
				
				}
			}
		
			string returnValue=filter.ToString();

			
			return returnValue;

			
			#endregion  
			
			
		}


		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnFrist.Click += new System.EventHandler(this.btnFrist_Click);
			this.btnPageShi.Click += new System.EventHandler(this.btnPageShi_Click);
			this.btnShang.Click += new System.EventHandler(this.btnShang_Click);
			this.btnXia.Click += new System.EventHandler(this.btnXia_Click);
			this.btnTuiShi.Click += new System.EventHandler(this.btnTuiShi_Click);
			this.btnMo.Click += new System.EventHandler(this.btnMo_Click);
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
			this.btnUpdateShuju.Click += new System.EventHandler(this.btnUpdateShuju_Click);
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.getPageViewLoad(1,getStrCondition(),0,0);
		}

		/// <summary>
		/// 标注预付款
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEnter_Click(object sender, System.EventArgs e)
		{
			//	是否付款(定金) Earnest
			//TextBox1  付款标注人员
			//付款时间 txtDateTo
			//txtBeark 付款备注
			this.lblMessage.Text = "";
			int UserCode = Convert.ToInt32( User.Identity.Name);
			string EarnestSigner = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.getUserName(UserCode);		
			string txtDateTo =DateTime.Now.ToString("yyyy-MM-dd");
			string PayForRemark = this.TextBox2.Text.Trim();
			int IsPayFor = this.CheckBox3.Checked == true ? 1 : 0;
			string[] j = this.TextBox1.Text.Trim().ToString().Split('.');
			 
			string  PayForpriceF  = j[0];
			decimal   PayForprice  = 0;
			//只能输入数字

			if(PayForpriceF != "")
			{
				if(Regex.Match(PayForpriceF, @"^[0-9]*[1-9][0-9]*$").Success ) 
				{
					 PayForprice  = Convert.ToDecimal(this.TextBox1.Text.Trim());
				}
				else
				{
					this.lblMessage.Text = "不满足只能输入数字条件";
					return;
				
				}
			}
			else
			{
				PayForprice = this.SumMoney;
			}
			

			if(PayForRemark.Length >100)
			{
				this.lblMessage.Text ="付款备注  太长！";
				return ;
			}
			else
			{
				//查询是否已经入库
				int IsInStore =  HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectIsPayForByOS(this.Rownum);
				if(IsInStore > 0)
				{

					int UpAssetAdvance = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.UadateAssetPaymentRemarks(IsPayFor,EarnestSigner,txtDateTo,PayForRemark, PayForprice,this.Rownum);
					if(UpAssetAdvance > 0)
					{
						this.lblMessage.Text = "成功！";
						this.Label4.Text = "修改成功！";
						this.getPageViewLoad(this.Pages,getStrCondition(),0,0);
					}
					else
					{
						this.lblMessage.Text = "付款失败！";
						this.Label4.Text = "付款备注失败!";
					}

				}
				else
				{
					this.lblMessage.Text = "标注信息未入库！";
					this.Label4.Text = "标注信息未入库！";
				}
				
				
			}
			
		}

		private static  Color color;

		/// <summary>
		/// 首页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFrist_Click(object sender, System.EventArgs e)
		{
			
			this.getPageViewLoad( 1, getStrCondition() , 0, 0); 
			
		}

		/// <summary>
		/// 后退十页数  在当前页数上加后退十 后还大于1 则显示后退十的页数  ，如果小于0 则显示第一页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPageShi_Click(object sender, System.EventArgs e)
		{

			if(Convert.ToInt32(this.Pages) - 10 >= 0)
			{
				int btnA = Convert.ToInt32(this.Pages) - 10;
				this.getPageViewLoad( btnA, getStrCondition() , 0, 0); 
			}
			else
			{
				this.getPageViewLoad( 1, getStrCondition() , 0, 0); 
			}
		}
		
		/// <summary>
		/// 退页数为一
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnShang_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32( this.Pages) - 1 >= 0)
			{
				int btnA =Convert.ToInt32( this.Pages) - 1;
				this.getPageViewLoad( btnA, getStrCondition() , 0, 0); 
			}
			else
			{
				this.getPageViewLoad( 1, getStrCondition() , 0, 0); 
			}
		}

		/// <summary>
		/// 下一页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnXia_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32(this.Pages) + 1 <= this.PageCount )
			{
				this.Pages = Convert.ToInt32(this.Pages) + 1;
				this.getPageViewLoad( Convert.ToInt32(this.Pages), getStrCondition() , 0, 0); 
			}
			else
			{
				this.getPageViewLoad(this.PageCount, getStrCondition() , 0, 0); 
			}
		}

		/// <summary>
		/// 前进十页  如果 十页后的页数大于总页数 ，则显示最后一页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTuiShi_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32(this.Pages) + 10 <= this.Counts)
			{
				int btnA = Convert.ToInt32(this.Pages) + 10;
				this.getPageViewLoad( btnA, getStrCondition() , 0, 0); 
			}
			else
			{
				this.getPageViewLoad( this.PageCount, getStrCondition() , 0, 0); 
			}
		}

		/// <summary>
		/// 末页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMo_Click(object sender, System.EventArgs e)
		{
			this.getPageViewLoad( this.PageCount, getStrCondition() , 0, 0); 
		}

		/// <summary>
		/// 跳转到指定页面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			
			string   str   =   this.txtPage.Text.Trim(); 
			//只能输入数字
			if(Regex.Match(str, @"^[0-9]*[1-9][0-9]*$").Success) 
			{ 
				//页数为空的话 页数保持不变
				if(this.txtPage.Text.Trim().ToString() !=null )
				{
					this.getPageViewLoad(Convert.ToInt32(str), getStrCondition() , 0, 0); 
				}
				else
				{
					this.getPageViewLoad(Convert.ToInt32( this.Pages ), getStrCondition() , 0, 0); 
				}
				this.Label4.Text ="";
							
			} 
			else 
			{ 

				this.Label4.Text = "不满足只能输入数字条件";
				this.txtPage.Text = "";
			} 

			
		}
		
		/// <summary>
		/// 选中的数据进行更新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdateShuju_Click(object sender, System.EventArgs e)
		{
			foreach(DataGridItem itm in this.dgApply.Items )
			{
				
				CheckBox chkCode=itm.FindControl("CheckBox1") as CheckBox;
				if( chkCode.Checked )
				{
					int Chi = (itm.FindControl("lblyfk") as Label).Text.Trim().ToString() == "否" ? 1 : 1;
					int UserCode = Convert.ToInt32( User.Identity.Name);
					string Code = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.getUserName(UserCode);
					string txtDateTo  = DateTime.Now.ToString("yyyy-MM-dd");

					int  ID=int.Parse(dgApply.DataKeys[itm.ItemIndex].ToString()); 
					string Beark = "";
					decimal PayForpriceJ =0;
					if(!"&nbsp;".Equals( itm.Cells[9].Text.Trim()) && itm.Cells[9].Text.Trim() != "")
					{
						Beark =itm.Cells[9].Text.Trim();
					}
					if(!"&nbsp;".Equals( itm.Cells[6].Text.Trim()) && itm.Cells[6].Text.Trim() != "")
					{
						 //int  itm.Cells[6].Text.Trim();tring []tempStr = this.txtApplyNo.Text.Split(new char[] {','});
						string[] j = itm.Cells[6].Text.Trim().Split('.');
						 PayForpriceJ = Convert.ToDecimal(j[0]);
					}
					//查询是否已经入库
					int IsInStore =  HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectIsPayForByOS(ID);
					if(IsInStore > 0 )
					{
						int UpAssetAdvance = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.UadateAssetPaymentRemarks(Chi,Code,txtDateTo,Beark,PayForpriceJ,ID);
						if(UpAssetAdvance < 1)
						{
							this.Label4.Text = "修改失败！";
							break;
						}
						else
						{
							this.Label4.Text ="";
						}
						
					}
					else
					{
						this.Label4.Text ="标注信息里包含未入库数据，请查看！";
					}
					
					
				}
			}
			
			this.getPageViewLoad( this.Pages, getStrCondition() , 0, 0); 
		}

		/// <summary>
		/// 全选实践 改变GRIDVIEW Checked 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chbSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			//全选
			if(this.chbSelectAll.Checked )
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox1") as CheckBox;
					chkCode.Checked=true;
				}
			}
			else
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox1") as CheckBox;
					chkCode.Checked=false;

					
				}
			}
		}

		
		/// <summary>
		/// GridVIEW的命令控制	
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{				
				if(e.CommandName.Equals("ReMark")) //点击审批按钮			
				{			
					for(int i=0;i<this.dgApply.Items.Count ;i++)		
					{		
						if(this.dgApply.Items[i].BackColor==Color.Yellow)	
						{	
							this.dgApply.Items[i].BackColor= color;
						}	
					}		
					color=e.Item.BackColor;		
					e.Item.BackColor=Color.Yellow;		
					
					// ..initial Panel		
					
					this.Panel1.Visible=true;		
				
					//价格裁决单据表体id
					this.Rownum = Convert.ToInt32(e.CommandArgument);

					this.CheckBox3.Checked = ((Label)e.Item.FindControl("lblyfk")).Text == "是" ? true : false  ; 
					
			
					//金额
					if(!"&nbsp;".Equals( e.Item.Cells[9].Text.Trim()) && e.Item.Cells[7].Text.Trim() != "")
					{
						this.TextBox1.Text = e.Item.Cells[9].Text.Trim();
					}
					else
					{
						this.TextBox1.Text ="";
					}
					
					//裁决金额
					if(!"&nbsp;".Equals( e.Item.Cells[6].Text.Trim()) && e.Item.Cells[6].Text.Trim() != "")
					{
						this.SumMoney =Convert.ToInt32( e.Item.Cells[6].Text.Trim());
					}
					else
					{
						this.SumMoney = 0;
					}

					//备注
					if(!"&nbsp;".Equals( e.Item.Cells[11].Text.Trim()))
					{
						this.TextBox2.Text = e.Item.Cells[11].Text.Trim();
					}
					else
					{
						this.TextBox2.Text ="";
					}
					

					
					
				
				
				   
				
				}		
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("HDSZCheckFlow.UI.FixedAssets.AssetPaymentRemarks.aspx",ex.ToString());		
			}			

		}

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{


			if(!"&nbsp;".Equals( e.Item.Cells[5].Text.Trim())&&(e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager))
			{
				string Asset_ApplySheet_Body_Id = e.Item.Cells[5].Text.Trim().ToString();
				string SubjectName = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectAsset_ApplySheet_Body_Id(Asset_ApplySheet_Body_Id);
				e.Item.Cells[5].Text = SubjectName;
			}

			if(!"&nbsp;".Equals( e.Item.Cells[6].Text.Trim())&&(e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager))
			{
				string Asset_ApplySheet_Body_Table = e.Item.Cells[6].Text.Trim().ToString();
				DataTable  SubjectTable = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectAsset_ApplySheet_Body_Table(Asset_ApplySheet_Body_Table);
				if(SubjectTable.Rows.Count > 0)
				{
					for(int i = 0 ;i<SubjectTable.Rows.Count;i++)
					{
						int Number =Convert.ToInt32( SubjectTable.Rows[i]["Number"]);
						int ExchangeRate =Convert.ToInt32( SubjectTable.Rows[i]["ExchangeRate"]);
						int FinallyPrice =Convert.ToInt32( SubjectTable.Rows[i]["FinallyPrice"]);
						e.Item.Cells[6].Text =Convert.ToString( Number * ExchangeRate * FinallyPrice );
					}
					
				}
				
			}


			//绑定给定按钮提示信息
			if (!"&nbsp;".Equals( e.Item.Cells[7].Text.Trim())&&(e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				if(!"&nbsp;".Equals( e.Item.Cells[7].Text.Trim()))
				{
					string ApplySheetHead_Pk =  e.Item.Cells[7].Text.Trim();
					string Name = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectNameByApplySheetHead_Pk(ApplySheetHead_Pk);
					e.Item.Cells[7].Text = Name;
				}
				
			}
		}

		

	}
}
