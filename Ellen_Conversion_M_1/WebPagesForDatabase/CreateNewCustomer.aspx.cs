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
    public partial class CreateNewCustomer : System.Web.UI.Page
    {
        // Database Connection
        string connectionString = "Data Source=GORD-PC\\DEC2017GORDSQSER;Integrated Security=True;Initial Catalog = TestForWebCA_2";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string dbName = txtName.Text;
            string dbEmail = txtEmail.Text;

            // Insert basic customer info into database           
            // Create db connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand("uspInsertCustomer_No_1", conn))
                {
                    // Define command type
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter @Name for stored proceedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255));
                    sqlCommand.Parameters["@Name"].Value = dbName;

                    // Add input parameter @Email for stored procedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@CustomerEmail"].Value = dbEmail;


                    // Execute stored procedure with customer data
                    try
                    {
                        conn.Open();
                        // run command
                        sqlCommand.ExecuteNonQuery();
                        lblDisplayStatus.Text = string.Format("New account created:\nName: {0}\nEmail: {1}",
                            dbName, dbEmail);
                    }
                    catch
                    {
                        lblDisplayStatus.Text = "Error - no data saved - please try again";
                        
                    }
                    finally
                    {
                        conn.Close();
                    }
                } // end inner Using Statement                
            } // end outer Using Statement
        }// btnSubmit_Click

    }  // end class
}  // end Namespace