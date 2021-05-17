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
    public partial class shirts2 : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        string image = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string brand = "", size = "", shirtavailable = "", image = "", price = "";
            brand = DropDownList1.Text;
            size = DropDownList2.Text;
            shirtavailable = DropDownList3.Text;
            price = TextBox1.Text;





            con = new SqlConnection(@"Data Source=LAPTOP-R8NPA4B3\SQLEXPRESS;Initial Catalog=bigmax;Integrated Security=True");
            if (FileUpload1.HasFile)
            {
                string images = FileUpload1.FileName.ToString();
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/") + images);
                con.Open();


                cmd = new SqlCommand("INSERT INTO shirtdb3(brand,size,shirtavailable,image,price)VALUES(@brand,@size,@shirtavailable,@images,@price)", con);
                cmd.Parameters.Add("@brand", brand);
                cmd.Parameters.Add("@size", size);
                cmd.Parameters.Add("@shirtavailable", shirtavailable);
                cmd.Parameters.Add("@images", images);
                cmd.Parameters.Add("@price", price);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('SUCCESSFULLYADDED')</script>");
                Response.Redirect("Homepage.aspx");
            }
        }
    }
}

       