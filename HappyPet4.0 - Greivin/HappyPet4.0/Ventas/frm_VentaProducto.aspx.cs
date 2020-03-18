using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPet4._0.Ventas
{
    public partial class frm_VentaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPrueba();
                btnEliminarProductos.Visible = false;
                btnEditarProducto.Visible = false;
            }
        }

        private void CargarPrueba()
        {
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Código");
            DataColumn dc1 = new DataColumn("Descripción");
            DataColumn dc2 = new DataColumn("Precio");
            DataColumn dc3 = new DataColumn("Cantidad");
            DataColumn dc4 = new DataColumn("Subtotal");
            DataColumn dc5 = new DataColumn("Descuento");
            DataColumn dc6 = new DataColumn("Impuesto");
            DataColumn dc7 = new DataColumn("Total");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);

            DataRow dr = dt.NewRow();
            dr["Código"] = "1";
            dr["Descripción"] = "Alimento para perro";
            dr["Precio"] = "5000";
            dr["Cantidad"] = "1";
            dr["Subtotal"] = "5000";
            dr["Impuesto"] = "650";
            dr["Descuento"] = "0";
            dr["Total"] = "5650";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Código"] = "2";
            dr["Descripción"] = "Shampoo para perro";
            dr["Precio"] = "3500";
            dr["Cantidad"] = "2";
            dr["Subtotal"] = "7000";
            dr["Impuesto"] = "819";
            dr["Descuento"] = "700";
            dr["Total"] = "7119";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Código"] = "2";
            dr["Descripción"] = "Collar anti pulgas";
            dr["Precio"] = "10000";
            dr["Cantidad"] = "1";
            dr["Subtotal"] = "10000";
            dr["Impuesto"] = "1300";
            dr["Descuento"] = "0";
            dr["Total"] = "11300";
            dt.Rows.Add(dr);

            gvProductos.DataSource = dt;
            gvProductos.DataBind();

            txtSubtotal.Text = "22000";
            txtImpuesto.Text = "2769";
            txtDescuento.Text = "700";
            txtTotal.Text = "24069";
        }

        protected void btnClienteNuevo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBuscarCliente_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarProductos_Click(object sender, EventArgs e)
        {

        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvProductos.SelectedIndex == index)
                {
                    gvProductos.SelectedIndex = -1;
                    btnEliminarProductos.Visible = false;
                    btnEditarProducto.Visible = false;
                }
                else
                {
                    gvProductos.SelectedIndex = index;
                    btnEliminarProductos.Visible = true;
                    btnEditarProducto.Visible = true;
                }
            }
        }

        protected void btnEditarProducto_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarProducto_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}