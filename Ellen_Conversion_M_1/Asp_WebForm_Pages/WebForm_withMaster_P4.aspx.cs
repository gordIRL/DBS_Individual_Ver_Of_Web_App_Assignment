using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;



namespace Ellen_Conversion_M_1
{
    public partial class WebForm_withMaster_P4 : System.Web.UI.Page
    {

        public List<DateTime> MultipleSelectedDates
        {
            get
            {
                if (ViewState["MultipleSelectedDates"] == null)

                    ViewState["MultipleSelectedDates"] = new List<DateTime>();
                return (List<DateTime>)ViewState["MultipleSelectedDates"];
            }
            set
            {
                ViewState["MultipleSelectedDates"] = value;
            }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectedDates.Clear();

            foreach (DateTime dt in MultipleSelectedDates)
            {
                Calendar1.SelectedDates.Add(dt);
            }
        }



        protected void Calendar1_PreRender(object sender, DayRenderEventArgs e)
        {
            //Calendar1.SelectedDates.Clear();

            //foreach (DateTime dt in MultipleSelectedDates)
            //{
            //    Calendar1.SelectedDates.Add(dt);
            //}
        }










        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (MultipleSelectedDates.Contains(Calendar1.SelectedDate))
            {
                MultipleSelectedDates.Remove(Calendar1.SelectedDate);
            }
            else
            {
                MultipleSelectedDates.Add(Calendar1.SelectedDate);
            }

            ViewState["MultipleSelectedDates"] = MultipleSelectedDates;

            //ListBox1.Items.Add("You changed the calender!!");

            //ListBox1.Items.Add(
            //    "The selected date is " + Calendar1.SelectedDate.ToShortDateString());

            //Label1.Text = "The selected date(s):" + "<br />";
            //for (int i = 0; i <= Calendar1.SelectedDates.Count - 1; i++)
            //{
            //    Label1.Text += Calendar1.SelectedDates[i].ToShortDateString() + "<br />";
            //}
            ////------------------------------
            //Label1.Text = Calendar1.SelectedDates.ToString();
            ////--------------------------------------------------
        }  // end Calendar1_SelectionChanged

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblDate.Text = "";
            foreach (DateTime dt in MultipleSelectedDates)
            {
                lblDate.Text = lblDate.Text + " <br/> " + dt.ToString("dd/MM/yyyy");
            }

        }  // end Button1_Click

        protected void BtnReloadPage_Click(object sender, EventArgs e)
        {
            //Response.Redirect(Request.RawUrl);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }  // end class WebForm
}  // end Namespace