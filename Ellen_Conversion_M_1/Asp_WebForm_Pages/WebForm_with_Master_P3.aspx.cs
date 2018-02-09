using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;






namespace Ellen_Conversion_M_1.Asp_WebForm_Pages
{ 
    

    public partial class WebForm_with_Master_P3 : System.Web.UI.Page
    {
        string connectionString = "Data Source=GORD-PC\\DEC2017GORDSQSER;Integrated Security=True;Initial Catalog = RentMyWrox";


        protected void Page_Load(object sender, EventArgs e)
        {

            //display_1.InnerHtml = Server.HtmlEncode("i hope this works");

            //SqlConnection conn = new SqlConnection("Data Source=GORD-PC\\DEC2017GORDSQSER;Integrated Security=True;Initial Catalog = RentMyWrox");

            //display_1.InnerHtml = Server.HtmlEncode("Connected");
            //display_3.InnerHtml = Server.HtmlEncode();



            //SqlCommand cmd1 = new SqlCommand("CREATE TABLE Customer(CustomerID INT IDENTITY(1,1) PRIMARY KEY,Name VARCHAR(40),Address VARCHAR(255)); ", conn);
            //SqlCommand cmd2 = new SqlCommand("CREATE TABLE Product(ProductID INT PRIMARY KEY,Price INT,Description VARCHAR(255));", conn);
            //SqlCommand cmd3 = new SqlCommand("CREATE TABLE Orders(OrderID INT PRIMARY KEY,CustomerID INT,OrderDate DATE,FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID));", conn);
            //SqlCommand cmd4 = new SqlCommand("CREATE TABLE OrderLine(ProductID INT,OrderID INT,Quantity INT,PRIMARY KEY(ProductID,OrderID),FOREIGN KEY(ProductID) REFERENCES Product(ProductID),FOREIGN KEY(OrderID) REFERENCES Orders(OrderID));", conn);


            //SqlCommand cmd1 = new SqlCommand("DROP TABLE OrderLine)", conn);
            //SqlCommand cmd2 = new SqlCommand("DROP TABLE Orders)", conn);
            //SqlCommand cmd3 = new SqlCommand("DROP TABLE Product)", conn);
            //SqlCommand cmd4 = new SqlCommand("DROP TABLE Customer)", conn);

            //SqlCommand cmd5 = 
            //    new SqlCommand
            //    ("INSERT INTO Customer	(Name, Address) VALUES('John', 'address 11111'), ('David' , 'address 2222')", conn ) ;

            //------------------------------------------------




            //SqlCommand cmd6 = new SqlCommand("SELECT Name, Address FROM Customer;",   conn);
            ////WHERE CustomerID = 59

            //conn.Open();
            //SqlDataReader reader = cmd6.ExecuteReader();


            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        ListBox1.Items.Add(new ListItem(string.Format("{0}:  {1}",
            //            reader.GetString(0), reader.GetString(1))));

            //        display_3.InnerHtml = string.Format("{0}:  {1}", reader.GetString(0), reader.GetString(1));
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No rows found.");
            //}
            //reader.Close();
            //conn.Close();





            //try
            //{
            //    conn.Open();

            //    //cmd1.ExecuteNonQuery();
            //    //cmd2.ExecuteNonQuery();
            //    //cmd3.ExecuteNonQuery();
            //    //cmd4.ExecuteNonQuery();


            //    for (int i = 0; i < 5; i++)
            //    {
            //        cmd5.ExecuteNonQuery();
            //    }

            //    cmd5.ExecuteReader();



            //    //    MessageBox.Show("Tables Created");


            //    display_3.InnerHtml = Server.HtmlEncode("cmd S executed");
            //}
            //finally
            //{
            //    conn.Close();
            //    display_2.InnerHtml = Server.HtmlEncode("Disconnected");
            //    //MessageBox.Show("Disconnected");
            //}

        }





        //// INSERT - Working Version
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    string name = txtName.Text;
        //    string address = txtAddress.Text;
        //    ListBox1.Items.Add(new ListItem (string.Format("{0}:  {1}", name, address)  )  );

        //    string myProc = string.Format("INSERT INTO Customer	(Name, Address) VALUES('{0}', '{1}')",
        //         name, address);
        //    //string myProc = string.Format("INSERT INTO Customer	(Name, Address) VALUES('Daisy', 'Duke')");


        //    // Create db connection
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        //("INSERT INTO Customer	(Name, Address) VALUES('Joe', 'address 11111'), ('Satriani' , 'address 2222')", conn ))
        //        //using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Customer	(Name, Address) VALUES('John', 'Williams')", conn))
        //        using (SqlCommand sqlCommand = new SqlCommand(myProc, conn))
        //        {
        //            //cmd5.CommandType = CommandType.
        //            try
        //            {
        //                conn.Open();
        //                // run command
        //                sqlCommand.ExecuteNonQuery();
        //            }
        //            catch
        //            {

        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        } // end inner Using Statement                
        //    } // end outer Using Statement
        //} // en btnSubmit_Click




        // INSERT - Test Version
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            ListBox1.Items.Add(new ListItem(string.Format("{0}:  {1}", name, address)));

            string myProc = string.Format("INSERT INTO Customer	(Name, Address) VALUES('{0}', '{1}')",
                 name, address);
            //string myProc = string.Format("INSERT INTO Customer	(Name, Address) VALUES('Daisy', 'Duke')");


            // Create db connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //("INSERT INTO Customer	(Name, Address) VALUES('Joe', 'address 11111'), ('Satriani' , 'address 2222')", conn ))
                //using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Customer	(Name, Address) VALUES('John', 'Williams')", conn))
                using (SqlCommand sqlCommand = new SqlCommand("upsInsert_No_1", conn))
                {
                    // Define command type
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter @Name for stored procedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 40));
                    sqlCommand.Parameters["@Name"].Value = name;

                    // Add input parameter @Address for stored proceedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 255));
                    sqlCommand.Parameters["@Address"].Value = address;


                    try
                    {
                        conn.Open();
                        // run command
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                } // end inner Using Statement                
            } // end outer Using Statement
        } // en btnSubmit_Click








        // New working version - using Stored Procedure
        protected void btnRetrieveAll_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspGetAll", conn))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure; //CommandType.StoredProcedure;
                    List<Test> TestList = new List<Test>();
                    Test test;

                    try
                    {
                        ListBox1.Items.Clear();
                        conn.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();


                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                test = new Test();
                                //test.ID = int.Parse(reader["ID"].ToString());
                                test.Name    = reader["Name"].ToString();
                                test.Address = reader["Address"].ToString();
                                TestList.Add(test);

                                // Used below in loop
                                //ListBox1.Items.Add(new ListItem(string.Format("{0}:  {1}", test.Name, test.Address)));
                                
                                // Original - non-stored procefure version
                                //ListBox1.Items.Add(new ListItem(string.Format("{0}:  {1}", reader.GetString(0), reader.GetString(1))));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        reader.Close();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }

                    // Output TestList of Test object to ListBox
                    for (int i = 0; i < TestList.Count; i++)        // could also use a ForEach loop here
                    {
                        ListBox1.Items.Add(new ListItem(string.Format("{0}:  {1}",
                            TestList[i].Name, TestList[i].Address  ) ));
                    }
                      gvGrid.DataSource = TestList;
                      gvGrid.DataBind();


                   

                } // end outer Using Statement
            } // end outer Using Statement
        }  // end btnRetrieveAll_Click



        protected void btnClearDisplay_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            ListBox1.Items.Clear();
        }  // end btnClearDisplay_Click




        protected void Button1_Click(object sender, EventArgs e)
        {
            // Label1.Text = TextBox1.Text;


            Page.Validate();

            if (Page.IsValid)           //  Page.Validate()
            {
                Label1.Text = TextBox1.Text;
                TextBox1.Text = "";
            }
            else
            {
                Label1.Text = "Error!!!!!!";
                TextBox1.Text = "";
            }

        } // end  Button1_Click



    } // end class
}  // end namespace