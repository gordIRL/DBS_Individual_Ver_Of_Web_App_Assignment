using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;


namespace Ellen_Conversion_M_1.Asp_WebForm_Pages
{
    public partial class WebForm_with_Master_P5 : System.Web.UI.Page
    {
        
        // connection to database
        string connectionString = "Data Source=GORD-PC\\DEC2017GORDSQSER;Integrated Security=True;Initial Catalog = TestForWebCA_2";
        
        // instantiate list for calender dates
        public static List<DateTime> list = new List<DateTime>();

        // instantiate this outside of 'btnAddDate_Click' to allow for other scope
        public static List<DateTime> finalCalenderDateList = new List<DateTime>();

        // instantiate this outside of 'btnAddDate_Click' to allow for other scope
        //List<DateTime> outerCalenderDateList = new List<DateTime>();
        public static List<string> outerCalenderDateList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            pan1_Create_Customer.Visible = false;
            pan2_CreateBooking.Visible = false;
            ListBox1.Visible = false;

        }  // end Page_Load



        // Get customer data & display it
        protected void btnNewCustomer_Click(object sender, EventArgs e)
        {
            string dbName = txtName.Text;
            string dbEmail = txtEmail.Text;
            int dbNoOfGuests;
            int.TryParse(txtNoOfGuests.Text, out dbNoOfGuests);
            lblDisplay1.Text = dbName + " " + dbEmail + " " + dbNoOfGuests;


            // Insert basic customer info into database           

            // Create db connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                using (SqlCommand sqlCommand = new SqlCommand("uspInsertCustomer_No_1", conn))
                {
                    // Define command type
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter @Name for stored procedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@CustomerEmail"].Value = dbEmail;

                    // Add input parameter @Address for stored proceedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255));
                    sqlCommand.Parameters["@Name"].Value = dbName;


                    // Execute stored procedure with customer data
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
        }  // end btnNewCustomer_Click



        // Create / set up booking with valid email address --> to booking table
        protected void btnCreateBooking_Click(object sender, EventArgs e)
        {
            lblBookingStatus.Text = "Status:";
            string dbEmail = txtEmailCreateBooking.Text;
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
        }  // end btnCreateBooking_Click



        protected void btnClearBooking_Click(object sender, EventArgs e)
        {
            txtEmailCreateBooking.Text = "";
            lblBookingStatus.Text = "Status:";
        }  // end btnClearBooking_Click




        protected void btnRetrieveAll_Click1(object sender, EventArgs e)
        {
            ListBox1.Items.Add(new ListItem("Output loop started"));
            string dbEmail = txtRetrieveAvailability.Text;

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
                        ListBox1.Items.Clear();
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
                    for (int i = 0; i < AvailabiltyList.Count; i++)        // could also use a ForEach loop here
                    {
                        ListBox1.Items.Add(new ListItem(string.Format("CustomerEmail: {0}" , AvailabiltyList[i].CustomerEmail)));
                        ListBox1.Items.Add(new ListItem(string.Format("CustomerName: {0}"  , AvailabiltyList[i].CustomerName)));
                        ListBox1.Items.Add(new ListItem(string.Format("CustomerID: {0}"    , AvailabiltyList[i].CustomerID)));

                        ListBox1.Items.Add(new ListItem(string.Format("Date: {0}", AvailabiltyList[i].Date)));
                        ListBox1.Items.Add(new ListItem(string.Format("NoOfGuests: {0}", AvailabiltyList[i].NoOfGuests)));

                        ListBox1.Items.Add(new ListItem(string.Format("RoomID: {0}", AvailabiltyList[i].RoomID)));
                        ListBox1.Items.Add(new ListItem(string.Format("RoomName: {0}", AvailabiltyList[i].RoomName)));
                        ListBox1.Items.Add(new ListItem(string.Format("RoomCost: {0}", AvailabiltyList[i].RoomCost)));
                    }

                    dataGridView_Page_5.DataSource = AvailabiltyList;
                    dataGridView_Page_5.DataBind();

                } // end outer Using Statement
            } // end outer Using Statement
        }  // end btnRetrieveAll_Click1



        
        protected void btnRetrieveAll_Click(object sender, EventArgs e)
        {        }  // end btnRetrieveAll_Click

        
        

        protected void btnBookAvailability_Click(object sender, EventArgs e)
        {
            // Get user input             
            int.TryParse(txtAvail_BookingID.Text,   out int dbBookingID);            
            int.TryParse(txtAvail_RoomID.Text,      out int dbRoomID);            
            int.TryParse(txtAvail_NoOfGuests.Text,  out int dbNoOfGuests);
            
            if (outerCalenderDateList != null)
            {
                lblAvailabilityStatus.Text = "Passed 1st non null test";
                foreach (var dtNew in outerCalenderDateList)
                {
                    // output to screen
                    lblAvailabilityStatus.Text += dtNew;
                    lstBoxAvailability.Items.Add(dtNew);


                    // Create db connection
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("uspInsertAvailability", conn))
                        {
                            // Define command type
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            // Add input parameter "@BookingID for stored procedure & specify its value
                            sqlCommand.Parameters.Add(new SqlParameter("@BookingID", SqlDbType.Int));
                            sqlCommand.Parameters["@BookingID"].Value = dbBookingID;

                            // Add input parameter @RoomID for stored procedure & specify its value
                            sqlCommand.Parameters.Add(new SqlParameter("@RoomID", SqlDbType.Int));
                            sqlCommand.Parameters["@RoomID"].Value = dbRoomID;

                            // Add input parameter @NoOfGuests for stored procedure & specify its value
                            sqlCommand.Parameters.Add(new SqlParameter("@NoOfGuests", SqlDbType.Int));
                            sqlCommand.Parameters["@NoOfGuests"].Value = dbNoOfGuests;

                            // Add input parameter @Date for stored procedure & specify its value
                             //  seems to convert to the 'Month/Day/Year' that's acceptable for SQL Server
                            sqlCommand.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date)); 
                            sqlCommand.Parameters["@Date"].Value = dtNew;


                            // Execute stored procedure with Availability data
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
                }// end forEach
            }
             else
                lbAvailabilityStatus.Text = "list is still null";
            
        }  // end  btnBookAvailability_Click


        protected void btnRandomness_Click(object sender, EventArgs e)
        {
            outerCalenderDateList.Add("Testing One 1111");
            outerCalenderDateList.Add("Testing Two 2222");
            outerCalenderDateList.Add("Testing Three 3333");
            outerCalenderDateList.Add("Testing Four 4444");
        }  // end btnRandomness_Click








        //  **************   Calender GUI  *************************************************************

        // Use DayRender event to change colour & display of selected dates
        public void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                list.Add(e.Day.Date);
                e.Cell.BackColor = System.Drawing.Color.Crimson;
                e.Cell.BorderColor = System.Drawing.Color.Pink;
                e.Cell.Font.Italic = true;
                e.Cell.Font.Size = FontUnit.Large;
            }
            Session["SelectedDates"] = list;
        }




        List<DateTime> newList;
        public void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                //List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];  // working version !!
                newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    Calendar1.SelectedDates.Add(dt);
                }
                list.Clear();
            }  // end if
        }  // end  Calendar1_SelectionChanged


       

        // Get list of selected dates & output to listbox
        public void btnAddDate_Click(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                //List<DateTime> finalCalenderDateList = (List<DateTime>)Session["SelectedDates"];  // working version !!
                finalCalenderDateList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in finalCalenderDateList)
                {
                    outerCalenderDateList.Add(dt.ToShortDateString());
                    lstboxDisplayDates.Items.Add(dt.ToShortDateString());                  
                }
            }  // end if
        }  // end  btnAddDate_Click




        // Clear calendar &  list
        public void btnReloadPage_Click(object sender, EventArgs e)
        {
            list.Clear();
            Calendar1.SelectedDates.Clear();
            lstboxDisplayDates.Items.Clear();
            //Response.Redirect(Request.RawUrl);
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }  //  btnReloadPage_Click

        protected void btnClearListBoxAvailability_Click(object sender, EventArgs e)
        {
            outerCalenderDateList.Clear();
            lstBoxAvailability.Items.Clear();
        }


    //****************************************************************************************


        protected void btnPanelCreateCustomer_Click(object sender, EventArgs e)
        {
            pan1_Create_Customer.Visible = !pan1_Create_Customer.Visible;                       
        }

       
        protected void btnCreateBooking_Show_Click(object sender, EventArgs e)
        {
            pan2_CreateBooking.Visible = !pan2_CreateBooking.Visible;
            ListBox1.Visible = !ListBox1.Visible;
        }


        

        protected void btnPan3_RetrieveAvail_Show_Click(object sender, EventArgs e)
        {
            pan3_RetrieveAvailability.Visible = !pan3_RetrieveAvailability.Visible;
        }

        //protected void btnPan3_RetrieveAvail_Hide_Click(object sender, EventArgs e)
        //{
        //    pan3_RetrieveAvailability.Visible = !pan3_RetrieveAvailability.Visible  ;
        //}
    } // end WebForm
}  // end Namespace