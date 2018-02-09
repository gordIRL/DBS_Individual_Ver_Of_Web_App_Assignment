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
        public static List<DateTime> list = new List<DateTime>();
        public static List<DateTime> finalCalenderDateList = new List<DateTime>();        
        public static List<string> outerCalenderDateList = new List<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            panelCreateAvailability.Visible = false;

        }  // end  PageLoad

        

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
                finalCalenderDateList = (List<DateTime>)Session["SelectedDates"];
                lstboxDisplayDates.Items.Clear();
                lstboxDisplayDates.Items.Add("Selected Dates:");
                lstboxDisplayDates.Items.Add(string.Empty);

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

            finalCalenderDateList.Clear();
            outerCalenderDateList.Clear();
            txtNoOfGuests.Text = "";

            //Response.Redirect(Request.RawUrl);
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }  //  btnReloadPage_Click

        

        //****************************************************************************************






            protected void btnCheckAvailability_Click(object sender, EventArgs e)
            {
            try
            {



                // Get user input
                
                    int.TryParse(txtNoOfGuests.Text, out int noOfGuests);
                    lblAvailabilityResult.Text = "Please select 1 to 4 guests";
                
                if (noOfGuests == 0)
                    lblAvailabilityResult.Text = "Please select 1 to 4 guests";
                else
                    lblAvailabilityResult.Text = string.Format("You have selected {0} guests.", noOfGuests);

                string date1 = outerCalenderDateList[0];
                string date2 = outerCalenderDateList[outerCalenderDateList.Count - 1];




                if (outerCalenderDateList != null && noOfGuests > 0)  // only access database if list is not null
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
                                    lblAvailabilityResult.Text = "Result was found - room is already booked";
                                }
                                else
                                {
                                    lblAvailabilityResult.Text = ("No rows found - room is available.");
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
            panelCreateAvailability.Visible = true;




        }//  end btnCreateAvailabiltyBooking_Click





    }  // end partial class WebForm1
}  // end Namespace