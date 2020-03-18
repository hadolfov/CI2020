using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPet4._0.Ventas
{
    public partial class frm_Citas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPrueba();
                calFechaCitas.Visible = false;
                btnAtenderCita.Visible = false;
                btnEditarCita.Visible = false;
                btnEliminarCita.Visible = false;
                gvCitas.SelectedIndex = -1;
            }
            
        }

        private void CargarPrueba()
        {
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Cita");
            DataColumn dc1 = new DataColumn("Hora Inicio");
            DataColumn dc5 = new DataColumn("Hora Fin");
            DataColumn dc2 = new DataColumn("Cliente");
            DataColumn dc3 = new DataColumn("Mascota");
            DataColumn dc4 = new DataColumn("Estado");

            dt.Columns.Add(dc0); 
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);

            DataRow dr = dt.NewRow();
            dr["Cita"] = "1";
            dr["Hora Inicio"] = "8:00 am";
            dr["Hora Fin"] = "8:50 am";
            dr["Cliente"] = "Pedro Pérez";
            dr["Mascota"] = "Capitán";
            dr["Estado"] = "Confirmada";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Cita"] = "2";
            dr["Hora Inicio"] = "9:00 am";
            dr["Hora Fin"] = "9:50 am";
            dr["Cliente"] = "Juan Vazquez";
            dr["Mascota"] = "Toto";
            dr["Estado"] = "Confirmada";
            dt.Rows.Add(dr);


            dr = dt.NewRow();
            dr["Cita"] = "3";
            dr["Hora Inicio"] = "10:00 am";
            dr["Hora Fin"] = "10:50 am";
            dr["Cliente"] = "Luisa Mendoza";
            dr["Mascota"] = "Speedy";
            dr["Estado"] = "Pendiente";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Cita"] = "4";
            dr["Hora Inicio"] = "11:00 am";
            dr["Hora Fin"] = "11:50 am";
            dr["Cliente"] = "Guadalupe Sanchéz";
            dr["Mascota"] = "Fify";
            dr["Estado"] = "Confirmada";
            dt.Rows.Add(dr);

            gvCitas.DataSource = dt;
            gvCitas.DataBind();
        }

        protected void btnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            calFechaCitas.Visible = !calFechaCitas.Visible;
        }

        protected void calFechaCitas_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = calFechaCitas.SelectedDate.ToShortDateString();
            calFechaCitas.Visible = false;
        }

        protected void btnAgregarCita_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Agendar Citas";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalAgendar", "$('#ModalAgendar').modal();", true);
            upModal.Update();

        }

        protected void btnEditarCita_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Editar Citas";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalAgendar", "$('#ModalAgendar').modal();", true);
            upModal.Update();
        }

        protected void btnEliminarCita_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Citas";
            lblEliminarbody.Text = "Desea Eliminar esta cita?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModal.Update();
        }

        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvCitas.SelectedIndex == index)
                {
                    gvCitas.SelectedIndex = -1;
                    btnAtenderCita.Visible = false;
                    btnEditarCita.Visible = false;
                    btnEliminarCita.Visible = false;
                }
                else
                {
                    gvCitas.SelectedIndex = index;
                    if (gvCitas.Rows[index].Cells[6].Text == "Confirmada")
                    {
                        btnAtenderCita.Visible = true;
                    }
                    else
                    {
                        btnAtenderCita.Visible = false;
                    }
                    btnEditarCita.Visible = true;
                    btnEliminarCita.Visible = true;
                }
                //TableCell contactName = selectedRow.Cells[1];
                //string contact = contactName.Text;
            }
        }

        protected void btnAtenderCita_Click(object sender, EventArgs e)
        {

        }

        protected void btnClienteNuevo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBuscarCliente_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnMascotaNueva_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGuardarCita_Click(object sender, EventArgs e)
        {

        }

        protected void calAgendarCita_SelectionChanged(object sender, EventArgs e)
        {
            upModal.Update();
        }

        protected void calAgendarCita_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            upModal.Update();
        }
    }
}