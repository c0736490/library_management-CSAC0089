using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectapplied
{
    public partial class WebForm2 : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
              {
                  if (IsPostBack)
                  {
                      SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                      conn.Open();
                      string checkemail = "select count(*) from data where email ='" + TextBox1.Text + "'";
                      SqlCommand cmd = new SqlCommand(checkemail, conn);
                      int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                      if (temp == 1)
                      {
                          Response.Write("User Already Exists");
                      }
                      conn.Close();
                  }


              }
          }

        protected void Button1_Click(object sender, EventArgs e)
        {


            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into data (email, password, firstname, lastname, dateofbirth)values (@email, @password, @firstname, @lastname, @dateofbirth)";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.Parameters.AddWithValue("@email", TextBox1.Text);
                com.Parameters.AddWithValue("@password", TextBox2.Text);
                com.Parameters.AddWithValue("@firstname", TextBox4.Text);
                com.Parameters.AddWithValue("@lastname", TextBox5.Text);
                com.Parameters.AddWithValue("@dateofbirth", TextBox6.Text);
                com.ExecuteNonQuery();


                Response.Write("Student registeration Successfully!!!thank you");


                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }




        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

        /*        {
                    Random ra = new Random();
                    int noc = ra.Next(5, 10);
                    string cap = "";
                    int tot = 0;
                    do
                    {
                        int ch = ra.Next(48, 123);
                        if ((ch >= 48 && ch <= 57) || (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122))
                        {
                            cap = cap + (char)ch;
                            tot++;
                            if (tot == noc)
                                break;
                        }
                    }
                    while (true);
                    Label9.Text = cap;
                }

            */

   







