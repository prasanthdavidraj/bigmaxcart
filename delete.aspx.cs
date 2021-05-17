using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace Bigmax
{
    public partial class delete : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAPTOP-R8NPA4B3\SQLEXPRESS;Initial Catalog=bigmax;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("DELETE shirtdb3 where brand='" + DropDownList1.Text + "'", con);


            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('cancelled')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAPTOP-R8NPA4B3\SQLEXPRESS;Initial Catalog=bigmax;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("UPDATE shirtdb3 set price='" +TextBox1.Text+"',brand='"+DropDownList2.Text+"' where brand='" + DropDownList2.Text + "'", con);
            cmd.Parameters.Add("@price", TextBox1.Text);
            cmd.Parameters.Add("@brand", DropDownList2.Text);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('updated')</script>");
        }
    }
}