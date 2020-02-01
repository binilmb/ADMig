using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using System.Data;

namespace ADMig
{
    public partial class FirstPage : System.Web.UI.Page
    {
        string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ADMig.mdf");
        SqlConnection sCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            sCon.Open();
            GetUser();
            if(CheckUserExists())
                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        private bool CheckUserExists()
        {
            string checkAD = "select * from ADInfo where ADUser = '" + lblUser.Text + "'";
            SqlCommand sCmd = new SqlCommand(checkAD, sCon);
            SqlDataAdapter sDA = new SqlDataAdapter(sCmd);
            DataTable dt = new DataTable();
            sDA.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void GetUser()
        {
            string username = WindowsIdentity.GetCurrent().Name;
            lblUser.Text = username;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckUserExists())
                Response.Write("Data already captures");
            string insertAD = "insert into ADInfo (ADUser, SelDateTime) values ('";
            insertAD += lblUser.Text + "','";
            insertAD += txtDtPicker.Value + "')";
            Response.Write(insertAD);
            SqlCommand sCmd = new SqlCommand(insertAD,sCon);
            sCmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "alert('Data Saved');window.close();", true);
        }
    }
}