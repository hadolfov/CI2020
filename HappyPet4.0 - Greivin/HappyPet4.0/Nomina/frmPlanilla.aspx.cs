using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPet4._0
{
    public partial class frmPlanilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPruebaPlanilla();

            }
        }
        private void CargarPruebaPlanilla()
        {
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Id");
            DataColumn dc1 = new DataColumn("Nombre");
            DataColumn dc2 = new DataColumn("Apellido");
            DataColumn dc3 = new DataColumn("Horas");
            DataColumn dc4 = new DataColumn("Salario");
            DataColumn dc5 = new DataColumn("Estado");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);


            DataRow dr = dt.NewRow();
            dr["Id"] = "117362618";
            dr["Nombre"] = "Juan";
            dr["Apellido"] = "Mora";
            dr["Horas"] = "48";
            dr["Salario"] = "4000000";
            dr["Estado"] = "Activo";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "327344699";
            dr["Nombre"] = "Martin";
            dr["Apellido"] = "Garcia";
            dr["Horas"] = "48";
            dr["Salario"] = "5000000";
            dr["Estado"] = "Activo";
            dt.Rows.Add(dr);


            gvPlanilla.DataSource = dt;
            gvPlanilla.DataBind();
        }
    }
}