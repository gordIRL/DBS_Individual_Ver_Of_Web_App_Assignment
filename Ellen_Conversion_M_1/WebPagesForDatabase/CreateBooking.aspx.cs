using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

namespace Ellen_Conversion_M_1.WebPagesForDatabase
{
    public partial class CreateBooking : System.Web.UI.Page
    {
        // connection to database
        string connectionString = "Data Source=GORD-PC\\DEC2017GORDSQSER;Integrated Security=True;Initial Catalog = TestForWebCA_2";


        protected void Page_Load(object sender, EventArgs e)
        {

        }// end Page_Load

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblBookingStatus.Text = "Status:";
            string dbEmail = txtEmail.Text;
            string dbAuthenticationCode = "test123";

            // Create db connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspInsertBookingOnly", conn))
                {
                    // Define command type
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter @CustomerEmail for stored procedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@CustomerEmail"].Value = dbEmail;

                    // Add input parameter @AuthenticationCode for stored procedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthenticationCode", SqlDbType.VarChar, 10));
                    sqlCommand.Parameters["@AuthenticationCode"].Value = dbAuthenticationCode;


                    // Execute stored procedure with customer data
                    try
                    {
                        conn.Open();
                        // run command
                        sqlCommand.ExecuteNonQuery();
                        lblBookingStatus.Text = "Status: New booking created in database";
                    }
                    catch
                    {
                        lblBookingStatus.Text = "Status: FAILED - no database entry created.";
                    }
                    finally
                    {
                        conn.Close();
                    }
                } // end inner Using Statement                
            } // end outer Using Statement

        }// end btnSubmit_Click
    }// end class
}// end Namespace