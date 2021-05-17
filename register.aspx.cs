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
    public partial class register : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"Data Source=LAPTOP-R8NPA4B3\SQLEXPRESS;Initial Catalog=bigmax;Integrated Security=True");
                con.Open();
                string insertquery = "insert into REGISTERTABLE(USERNAME,EMAIL,PASSWORD)values(@uname,@email,@password)";
                SqlCommand com = new SqlCommand(insertquery, con);
                com.Parameters.AddWithValue("@uname", UN.Text);
                com.Parameters.AddWithValue("@email", EMAIL.Text);
                com.Parameters.AddWithValue("@password", PASSWORD.Text);
                com.ExecuteNonQuery();
                Response.Redirect("productview1.aspx");
                Response.Write("registration is successfull");
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}


    