using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPet4._0
{
    public partial class frmPermisosyVac : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarFin.Visible = false;
            calendarInic.Visible = false;
        }
        protected void CalendarInic_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaInic.Text = calendarInic.SelectedDate.ToString();
        }
        protected void CalendarFin_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaFin.Text = CalendarFin.SelectedDate.ToString();
        }
        protected void btnCalendarInic_Click(object sender, ImageClickEventArgs e)
        {
            calendarInic.Visible = !calendarInic.Visible;
        }
        protected void btnCalendarFin_Click(object sender, ImageClickEventArgs e)
        {
            CalendarFin.Visible = !CalendarFin.Visible;
        }
    }
}