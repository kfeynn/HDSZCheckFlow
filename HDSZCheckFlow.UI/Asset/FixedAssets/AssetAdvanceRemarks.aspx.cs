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

namespace HDSZCheckFlow.UI.FixedAssets
{
	/// <summary>
	/// AssetAdvanceRemarks 的摘要说明。
	/// </summary>
	public class AssetAdvanceRemarks : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
		protected System.Web.UI.WebControls.RadioButton rbtMark1;
		protected System.Web.UI.WebControls.RadioButton rbtMark2;
		protected System.Web.UI.WebControls.RadioButton rbtMark3;
		protected System.Web.UI.WebControls.TextBox txtProduct;
		protected System.Web.UI.WebControls.TextBox txtOrderNumber;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.CheckBox chbSelectAll;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.WebControls.TextBox Textbox4;
		protected System.Web.UI.WebControls.TextBox Textbox5;
		protected System.Web.UI.WebControls.TextBox Textbox6;

	
		/// <summary>
		/// 初始化 GRIDVIEW 绑定所有 项目具有预付款的二级科目的具体内容
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				 this.dgApply.DataSource = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectFinallyPriceOrBody();
				 this.txtProduct.Text = "???????????";
			}
			
			
		
		}


		private void InitializeComponent()
		{
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
		
			base.OnInit(e);
		}
		
	
		#endregion

		/// <summary>
		/// 根据单据号和项目名称来查询这个项目的二级科目具体内容
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.dgApply.DataSource = HDSZCheckFlow.Bussiness.AssetAdvanceRemarksBLL.SelectFinallyPriceOrBody();
			this.txtProduct.Text = "???????????";
		}


		//private static  Color color;
		/// <summary>
		/// GridVIEW的命令控制
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
//			try
//			{
//				if(e.CommandName.Equals("ReMark")) //点击审批按钮
//				{
//					for(int i=0;i<this.dgApply.Items.Count ;i++)
//					{
//						if(this.dgApply.Items[i].BackColor==Color.Yellow)
//						{
//							this.dgApply.Items[i].BackColor= color;
//						}
//					}
//					color=e.Item.BackColor;
//					e.Item.BackColor=Color.Yellow;
//
//					// ..initial Panel
//
//					this.Panel1.Visible=true;
//					HyperLink hl = (HyperLink)e.Item.Cells[3].Controls[0];   
//					this.Label5.Text= hl.Text;
//					this.Label2.Text= e.Item.Cells[7].Text;
//					this.Label3.Text= e.Item.Cells[8].Text;
//					Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(e.Item.Cells[0].Text));
//					if(applyBody!=null)
//					{
//						if(applyBody.IsOrder == 1)
//						{
//							
//							
//						}
//						else
//						{
//						
//						}
//						this.TextBox1.Text = applyBody.OrderNo;
//					}
//					applyBody =  null;
//
//					//this.lblHidden.Visible=false;
//					//this.lblHidden.Text = e.Item.Cells[0].Text;
//
//					//this.lblMessage.Text = "";
//				}
//			}
//			catch(Exception ex)
//			{
//				Common.Log.Logger.Log("OrderList",ex.ToString());
//			}
		}

		
		/// <summary>
		/// 全选的控制
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chbSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
//			//全选
//			if(this.chbSelectAll.Checked )
//			{
//				foreach(DataGridItem itm in this.dgApply.Items )
//				{
//					CheckBox chkCode=itm.FindControl("CheckBox1") as CheckBox;
//					chkCode.Checked=true;
//				}
//			}
//			else
//			{
//				foreach(DataGridItem itm in this.dgApply.Items )
//				{
//					CheckBox chkCode=itm.FindControl("CheckBox1") as CheckBox;
//					chkCode.Checked=false;
//
//					
//				}
//			}
		}


		/// <summary>
		/// 跟新数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button1_Click(object sender, System.EventArgs e)
		{
				
		}


		/// <summary>
		/// 预付款备注
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEnter_Click(object sender, System.EventArgs e)
		{
				
		}

		
		

		
	}
}
