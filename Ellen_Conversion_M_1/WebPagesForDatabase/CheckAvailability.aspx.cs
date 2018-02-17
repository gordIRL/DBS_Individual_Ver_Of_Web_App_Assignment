using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;              //  this is needed  !!!

namespace Ellen_Conversion_M_1.WebPagesForDatabase
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        // Database Connection
        string connectionString = "Data Source=GORD-PC\\DEC2017GORDSQSER;Integrated Security=True;Initial Catalog = TestForWebCA_2";


        // Calender date List(s) instantiated
        public static List<DateTime> CalenderDates_1_ClickedOnList = new List<DateTime>();
        public static List<DateTime> CalenderDates_2_BrowserList = new List<DateTime>();        
        public static List<string> CalenderDates_3_DatabaseQueryList = new List<string>();
        
        public static bool proceedToBooking = false;
        public static bool proceedToAvailability = false;

        public static string dbEmail = string.Empty;
        public static string dbAuthenticationCode = "test123";
        public static int newestBookingID = 0;
        public static int noOfGuests = 0;




        protected void Page_Load(object sender, EventArgs e)
        {
            panelCheckDatesAreAvailable.Visible = false;
            panelNoOfGuests.Visible = false;

            panelRegisterNewCustomer.Visible = false;
            btnProceedToCreateBookingPanel.Visible = false;
            panelCreateBooking.Visible = false;
            panelCreateAvailabilityBooking.Visible = false;
            panelCreateAvailLast.Visible = false;
            panelSearchForBookingByEmail.Visible = false;
            dataGridViewBookingSearch.Visible = false;
        }  // end  PageLoad




        protected void btnRegisterNewCustomerEXIT_Click(object sender, EventArgs e)
        {
            panelRegisterNewCustomer.Visible = false;
        }// end btnRegisterNewCustomerEXIT_Click


        protected void btnRegisterNewCustomerCANCEL_Click(object sender, EventArgs e)
        {
            panelRegisterNewCustomer.Visible = false;
        }// end btnRegisterNewCustomerCANCEL_Click


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            panelRegisterNewCustomer.Visible = true;
            string dbName = txtName.Text;
            string dbEmail = txtEmail0.Text;
            

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
            btnRegisterNewCustomerCANCEL.Enabled = false;
            btnSubmit.Enabled = false;
            btnRegisterNewCustomerEXIT.Visible = true;
        }// end btnSubmit_Click



        protected void btnRegisterAsNewCustomer_Click(object sender, EventArgs e)
        {
            panelRegisterNewCustomer.Visible = true;
            btnSubmit.Enabled = true;
            lblDisplayStatus.Text = "Status: ";
            txtEmail0.Text = string.Empty;
            txtName.Text = string.Empty;
            btnRegisterNewCustomerEXIT.Visible = false;
        }// btnRegisterAsNewCustomer_Click


        protected void btnCheckDateAvailability_Click(object sender, EventArgs e)
        {
            panelCheckDatesAreAvailable.Visible = true;
            panelNoOfGuests.Visible = true;

            CalenderDates_1_ClickedOnList.Clear();
            Calendar1.SelectedDates.Clear();
            lstboxDisplayDates.Items.Clear();

            CalenderDates_2_BrowserList.Clear();
            CalenderDates_3_DatabaseQueryList.Clear();
            txtNoOfGuests.Text = "";


        }// end btnCheckDateAvailability_Click



        //  **************   Calender GUI  *************************************************************

        // Use DayRender event to change colour & display of selected dates
        public void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            panelCheckDatesAreAvailable.Visible = true;
            panelNoOfGuests.Visible = true;

            if (e.Day.IsSelected == true)
            {
                CalenderDates_1_ClickedOnList.Add(e.Day.Date);
                e.Cell.BackColor = System.Drawing.Color.Crimson;
                e.Cell.BorderColor = System.Drawing.Color.Pink;
                e.Cell.Font.Italic = true;
                e.Cell.Font.Size = FontUnit.Large;
            }
            Session["SelectedDates"] = CalenderDates_1_ClickedOnList;
        }




        List<DateTime> newListForSessionSelectionChanged;
        public void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            panelCheckDatesAreAvailable.Visible = true;
            panelNoOfGuests.Visible = true;

            if (Session["SelectedDates"] != null)
            {
                newListForSessionSelectionChanged = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newListForSessionSelectionChanged)
                {
                    Calendar1.SelectedDates.Add(dt);
                }
                CalenderDates_1_ClickedOnList.Clear();
            }  // end if
        }  // end  Calendar1_SelectionChanged




        // Get list of selected dates & output to listbox
        public void btnAddDate_Click(object sender, EventArgs e)
        {
            panelCheckDatesAreAvailable.Visible = true;
            panelNoOfGuests.Visible = true;

            if (Session["SelectedDates"] != null)
            {
                CalenderDates_2_BrowserList = (List<DateTime>)Session["SelectedDates"];
                lstboxDisplayDates.Items.Clear();
                lstboxDisplayDates.Items.Add("Selected Dates:");
                lstboxDisplayDates.Items.Add(string.Empty);

                foreach (DateTime dt in CalenderDates_2_BrowserList)
                {
                    CalenderDates_3_DatabaseQueryList.Add(dt.ToShortDateString());
                    lstboxDisplayDates.Items.Add(dt.ToShortDateString());
                }
            }  // end if
        }  // end  btnAddDate_Click


        // Clear calendar &  list
        public void btnReloadPage_Click(object sender, EventArgs e)
        {
            panelCheckDatesAreAvailable.Visible = true;
            panelNoOfGuests.Visible = true;

            CalenderDates_1_ClickedOnList.Clear();
            Calendar1.SelectedDates.Clear();
            lstboxDisplayDates.Items.Clear();

            CalenderDates_2_BrowserList.Clear();
            CalenderDates_3_DatabaseQueryList.Clear();
            txtNoOfGuests.Text = "";
        }  //  btnReloadPage_Click

        

        //****************************************************************************************






            protected void btnCheckAvailability_Click(object sender, EventArgs e)
            {
            panelCheckDatesAreAvailable.Visible = true;
            panelNoOfGuests.Visible = true;

            try
            {
                // Get user input                
                    int.TryParse(txtNoOfGuests.Text, out noOfGuests);
                    lblAvailabilityResult.Text = "Please select 1 to 4 guests";
                
                if (noOfGuests == 0)
                    lblAvailabilityResult.Text = "Please select 1 to 4 guests";
                else
                    lblAvailabilityResult.Text = string.Format("You have selected {0} guests.", noOfGuests);

                string date1 = CalenderDates_3_DatabaseQueryList[0];
                string date2 = CalenderDates_3_DatabaseQueryList[CalenderDates_3_DatabaseQueryList.Count - 1];

                if (CalenderDates_3_DatabaseQueryList != null && noOfGuests > 0)  // only access database if list is not null
                {
                    // Create db connection
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("uspCheckAvailability", conn))
                        {
                            // Define command type
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            // Add input parameter @RoomID for stored procedure & specify its value
                            sqlCommand.Parameters.Add(new SqlParameter("@RoomID", SqlDbType.Int));
                            sqlCommand.Parameters["@RoomID"].Value = noOfGuests;

                            // Add input parameter @Date1 for stored procedure & specify its value
                            //  seems to convert to the 'Month/Day/Year' that's acceptable for SQL Server
                            sqlCommand.Parameters.Add(new SqlParameter("@Date1", SqlDbType.Date));
                            sqlCommand.Parameters["@Date1"].Value = date1;

                            // Add input parameter @Date2 for stored procedure & specify its value
                            //  seems to convert to the 'Month/Day/Year' that's acceptable for SQL Server
                            sqlCommand.Parameters.Add(new SqlParameter("@Date2", SqlDbType.Date));
                            sqlCommand.Parameters["@Date2"].Value = date2;
                            
                            // Execute stored procedure with Availability data
                            try
                            {
                                conn.Open();
                                // run command
                                // sqlCommand.ExecuteNonQuery();
                                SqlDataReader reader = sqlCommand.ExecuteReader();


                                if (reader.HasRows)
                                {
                                    lblAvailabilityResult.Text = "Sorry that room is already booked.    (Result found - already in database)";
                                    proceedToBooking = false;
                                }
                                else
                                {
                                    lblAvailabilityResult.Text = ("Room is available.    (No rows found in database)");
                                    btnProceedToCreateBookingPanel.Visible = true;
                                    proceedToBooking = true;
                                }
                                reader.Close();
                                //}
                            }// end try
                            catch
                            {

                            }// end catch
                            finally
                            {
                                conn.Close();
                            }// end finally
                        } // end inner Using Statement                
                    } // end outer Using Statement             
                }  // end if null         
            } // end try
            catch
            {
                lblAvailabilityResult.Text = "Please select dates !";
            }
        } // end btnCheckAvailability_Click


        protected void btnCreateAvailabiltyBooking_Click(object sender, EventArgs e)
        {
            if (proceedToBooking)
            {               
                panelCreateBooking.Visible = true;
                btnProceedToAvailability.Visible = false;                
            }
        }//  end btnCreateAvailabiltyBooking_Click






        protected void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            panelCreateBooking.Visible = true;

            // Create / set up booking with valid email address --> to booking table

            lblBookingStatus.Text = "Status:";
            dbEmail = txtEmail.Text;
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
                        btnProceedToAvailability.Visible = true;
                    }
                    catch
                    {
                        lblBookingStatus.Text = "Status: FAILED - no database entry created - enter Valid Email.";
                    }
                    finally
                    {
                        conn.Close();
                    }
                } // end inner Using Statement                
            } // end outer Using Statement
        }// end btnSubmitEmail_Click

        protected void btnProceedToAvailability_Click(object sender, EventArgs e)
        {
            panelCreateBooking.Visible = false;
            panelCreateAvailabilityBooking.Visible = true;
        }//  end btnProceedToAvailability_Click

        


        protected void btnRetrieveBookingID_Click_Click(object sender, EventArgs e)
        {
            panelCreateAvailabilityBooking.Visible = true;

            // Retrieve newly created BookingId from database
            // Create db connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspGetNewestCustomerBookingID", conn))
                {
                    // Define command type
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter @RoomID for stored procedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@CustomerEmail"].Value = dbEmail;



                    // Execute stored procedure with Availability data
                    try
                    {
                        conn.Open();
                    // run command
                    sqlCommand.ExecuteNonQuery();
                    SqlDataReader reader = sqlCommand.ExecuteReader();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lblFinalAvailabilityDisplay.Text += string.Format("Column Name: {0}--", reader.GetName(0));
                            newestBookingID = int.Parse(reader["NewestBooking"].ToString());
                            lblFinalAvailabilityDisplay.Text += string.Format("--Booking ID is: {0}", newestBookingID.ToString());
                                //lblFinalAvailabilityDisplay.Text = reader.FieldCount.ToString();
                                btnRetrieveBookingID.Enabled = false;
                                btnProceedToAvailLast.Visible = true;
                                proceedToAvailability = true;

                        }// end (reader.Read())                      
                    }
                    else
                    {
                        lblFinalAvailabilityDisplay.Text = "Error - Can't find Booking ID.";
                    }// end (reader.HasRows)
                    reader.Close();                    
                    }// end try
                    catch
                    {
                    lblFinalAvailabilityDisplay.Text = "Error - caught by Try / Catch";
                    }// end catch
                    finally
                    {
                        conn.Close();
                    }// end finally
                } // end inner Using Statement                
            } // end outer Using Statement 
        }// end btnRetrieveBookingID_Click_Click



        protected void btnProceedToAvailLast_Click(object sender, EventArgs e)
        {
            if (proceedToAvailability)
            {
                panelCreateAvailabilityBooking.Visible = false;
                panelCreateAvailLast.Visible = true;
            }
        }// end btnProceedToAvailLast_Click




        protected void btnCreateAvailLAST_Click(object sender, EventArgs e)
        {
            panelCreateAvailLast.Visible = true;

            if (CalenderDates_3_DatabaseQueryList != null)
            {
                lblAvailabilityStatus.Text = "Passed 1st non null test";
                foreach (var dtNew in CalenderDates_3_DatabaseQueryList)
                {
                    // Create db connection
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("uspInsertAvailability", conn))
                        {
                            // Define command type
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            // Add input parameter "@BookingID for stored procedure & specify its value
                            sqlCommand.Parameters.Add(new SqlParameter("@BookingID", SqlDbType.Int));
                            sqlCommand.Parameters["@BookingID"].Value = newestBookingID;

                            // Add input parameter @RoomID for stored procedure & specify its value
                            sqlCommand.Parameters.Add(new SqlParameter("@RoomID", SqlDbType.Int));
                            sqlCommand.Parameters["@RoomID"].Value = noOfGuests;     // ie same as RoomID;

                            // Add input parameter @NoOfGuests for stored procedure & specify its value
                            sqlCommand.Parameters.Add(new SqlParameter("@NoOfGuests", SqlDbType.Int));
                            sqlCommand.Parameters["@NoOfGuests"].Value = noOfGuests; 

                            // Add input parameter @Date for stored procedure & specify its value
                            //  seems to convert to the 'Month/Day/Year' that's acceptable for SQL Server
                            sqlCommand.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date));
                            sqlCommand.Parameters["@Date"].Value = dtNew;

                            lblAvailabilityStatus.Text = "SQL commands setup";

                            // Execute stored procedure with Availability data
                            try 
                            {
                                conn.Open();
                            lblAvailabilityStatus.Text = "DB connection open";
                                // run command
                                sqlCommand.ExecuteNonQuery();
                            }
                            catch
                            {
                            }
                            finally
                            {
                                conn.Close();
                            btnCreateAvailLAST.Enabled = false;
                            btnBookingCompleteEXIT.Visible = true;
                            }// end finally
                        } // end inner Using Statement                
                    } // end outer Using Statement                    
                }// end forEach
            }
            else
                lblAvailabilityStatus.Text = "list is still null";
        }// end btnCreateAvailLAST_Click



        protected void btnBookingCompleteEXIT_Click(object sender, EventArgs e)
        {
            panelCreateAvailLast.Visible = false;
        }// btnBookingCompleteEXIT_Click



        //protected void btnSearchForBookingByEmail_Click(object sender, EventArgs e)
        //{
        //    panelSearchForBookingByEmail.Visible = true;
        //}// end btnSearchForBookingByEmail_Click



        protected void btnSearchForBookingByEmail__Click(object sender, EventArgs e)
        {
            panelSearchForBookingByEmail.Visible = true;
            txtEmailForBookingSearch.Text = string.Empty;
        }// END btnSearchForBookingByEmail__Click




        protected void btnSubmitEmailSearch_Click(object sender, EventArgs e)
        {
            panelSearchForBookingByEmail.Visible = true;                        
            string dbEmail = txtEmailForBookingSearch.Text;  

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspTestJoin", conn))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure; //CommandType.StoredProcedure;

                    // Add input parameter @CustomerEmail for stored procedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@CustomerEmail"].Value = dbEmail;

                    List<Availability> AvailabiltyList = new List<Availability>();
                    Availability availability;

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                availability = new Availability();

                                availability.CustomerID = int.Parse(reader["CustomerID"].ToString());
                                availability.CustomerEmail = reader["CustomerEmail"].ToString();
                                availability.CustomerName = reader["CustomerName"].ToString();

                                availability.BookingID = int.Parse(reader["BookingID"].ToString());
                                availability.CustomerEmail2 = reader["CustomerEmail"].ToString();

                                availability.Date = DateTime.Parse(reader["Date"].ToString());
                                availability.NoOfGuests = int.Parse(reader["NoOfGuests"].ToString());
                                availability.RoomID = int.Parse(reader["RoomID"].ToString());

                                availability.RoomName = reader["RoomName"].ToString();
                                availability.RoomCost = decimal.Parse(reader["Cost"].ToString());

                                AvailabiltyList.Add(availability);
                            }// end while reader.read
                        }// end reader(has rows)
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

                    dataGridViewBookingSearch.Visible = true;
                    dataGridViewBookingSearch.DataSource = AvailabiltyList;
                    dataGridViewBookingSearch.DataBind();

                } // end outer Using Statement
            } // end outer Using Statement
        }// end btnSubmitEmailSearch_Click

        protected void btnlSearchForBookingByEmailEXIT_Click(object sender, EventArgs e)
        {
            panelSearchForBookingByEmail.Visible = false;
            dataGridViewBookingSearch.Visible = false;
        }// end  btnlSearchForBookingByEmailEXIT_Click

       
    }  // end partial class WebForm1
}  // end Namespace