using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Bigmax
{
    public partial class Homepage : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAPTOP-R8NPA4B3\SQLEXPRESS;Initial Catalog=bigmax;Integrated Security=True");
            con.Open();
            string checkuser = "select count(*) from REGISTERTABLE where username='" + username.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if (temp == 1)
            {
                con.Open();
                string checkpasswordQuery = "select password from REGISTERTABLE where username='" + username.Text + "'";
                SqlCommand passComm = new SqlCommand(checkpasswordQuery, con);
                string password = passComm.ExecuteScalar().ToString();
                if (password == pass.Text)
                {
                    Session["New"] = username.Text;
                    Response.Write("password is not correct");
                }
                else
                {
                    Response.Write("password is not correct");
                    Response.Redirect("productview1.aspx");
                }
            }
            else
            {
                Response.Write("username is not correct");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script>Signup details('Fill your Details'</script>");
            Response.Redirect("register.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAPTOP-R8NPA4B3\SQLEXPRESS;Initial Catalog=bigmax;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("select * from shirtdb3", con);

            cmd.ExecuteNonQuery();

            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();
         
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("delete.aspx");
        }

       

    }
}


        
