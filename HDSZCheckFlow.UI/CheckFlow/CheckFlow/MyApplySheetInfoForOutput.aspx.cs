using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
    public partial class MyApplySheetInfoForOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitPageForAdd();
            }

        }
        private void InitPageForAdd()
		{
			try
			{
                //为下拉控件附值
                //string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
                //DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyTypeButAsset(deptClassCode);
                //if(dtType!=null && dtType.Rows.Count>0)
                //{
                //    this.ddlType.DataSource =dtType;
                //    ddlType.DataValueField=dtType.Columns[0].ToString();
                //    ddlType.DataTextField=dtType.Columns [1].ToString();

                //    ddlType.DataBind();
                //    ddlType.Items.Insert(0,"");
                //    dtType=null;
                //}

                DataTable dtDeptClass = Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(User.Identity.Name));      // 0 查询所有部门
                if (dtDeptClass != null && dtDeptClass.Rows.Count > 0)
                {
                    this.ddlDeptClass.DataSource = dtDeptClass;
                    ddlDeptClass.DataValueField = dtDeptClass.Columns[0].ToString();
                    ddlDeptClass.DataTextField = dtDeptClass.Columns[1].ToString();
                    ddlDeptClass.DataBind();
                    //ddlDeptClass.Items.Insert(0, "");
                }
            }

            catch(Exception Ex)
            {
                this.lblMessage.Text = Ex.Message;
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string typeCode = "0";

            typeCode = this.ddlType.SelectedValue;

            string cmdStr = "";

            //直接用登陆ID所在的部门信息,不考虑页面的部门下拉框
            string deptClassCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);

            string StDate = this.txtDateFrom.Text;
            string EdDate = this.txtDateTo.Text;

            if (StDate.Equals("") || EdDate.Equals(""))
            {
                this.lblMessage.Text = "请选择查询期间";
                return;
            }

            switch (typeCode)
            {
                case "0":
                    {
                        this.lblMessage.Text = "请选择查询类型";
                        break;
                    }
                case "1":
                    {
                        cmdStr = "p_SelectApplyInfoForPurchase";
                        break;
                    }
                case "2":
                    {
                        cmdStr = "p_SelectApplyInfoForPay";
                        break;
                    }
                case "3":
                    {
                        cmdStr = "p_SelectApplyInfoForEvection";
                        break;
                    }
            }
            if (cmdStr == "")
            {
                this.lblMessage.Text = "请选择查询类型";
                return;
            }
            else
            {
                cmdStr = "exec " + cmdStr + " '" + deptClassCode + "','"  + StDate + "','" + EdDate + "'";
            }

            DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);

            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }

        protected void btnOutPut_Click(object sender, EventArgs e)
        {
            //导出
            Common.Util.ExcelHelper excelHeaper = new Common.Util.ExcelHelper();

            excelHeaper.GoToExcel2("filename.xls", this.GridView1);

        }
    }
}
