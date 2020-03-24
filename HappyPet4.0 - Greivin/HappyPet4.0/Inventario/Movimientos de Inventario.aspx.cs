using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPet4._0
{
    public partial class Ingreso_Ordenes_de_Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            calFechaCitas.Visible = !calFechaCitas.Visible;
        }

        protected void calFechaCitas_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = calFechaCitas.SelectedDate.ToString();
            calFechaCitas.Visible = false;
        }

        private void CargarPrueba()
        {
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Articulo");
            DataColumn dc1 = new DataColumn("Descripcion");
            DataColumn dc5 = new DataColumn("Cantidad");
            DataColumn dc2 = new DataColumn("Impuesto");
            DataColumn dc3 = new DataColumn("Descuento");
            DataColumn dc4 = new DataColumn("Precio");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);

            DataRow dr = dt.NewRow();
            dr["Articulo"] = "1";
            dr["Descripcion"] = "Alimento para Perro 20kg";
            dr["Cantidad"] = "15 und";
            dr["Impuesto"] = "13%";
            dr["Descuento"] = "0";
            dr["Precio"] = "5000";
            dt.Rows.Add(dr);

            gvCitas.DataSource = dt;
            gvCitas.DataBind();
        }

        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Seleccionar" && IsPostBack)
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    if (gvCitas.SelectedIndex == index)
            //    {
            //        gvCitas.SelectedIndex = -1;
            //        btnAtenderCita.Visible = false;
            //        btnEditarCita.Visible = false;
            //        btnEliminarCita.Visible = false;
            //    }
            //    else
            //    {
            //        gvCitas.SelectedIndex = index;
            //        if (gvCitas.Rows[index].Cells[6].Text == "Confirmada")
            //        {
            //            btnAtenderCita.Visible = true;
            //        }
            //        else
            //        {
            //            btnAtenderCita.Visible = false;
            //        }
            //        btnEditarCita.Visible = true;
            //        btnEliminarCita.Visible = true;
            //    }
            //}
        }


    }
}