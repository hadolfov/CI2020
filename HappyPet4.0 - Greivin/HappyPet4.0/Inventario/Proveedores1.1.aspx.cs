using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HappyPet4._0
{
    public partial class Proveedores1__1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPrueba();
                btnAtenderCita.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                gvCitas.SelectedIndex = -1;
            }

        }


        private void CargarPrueba()
        {
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Identificacion");
            DataColumn dc1 = new DataColumn("Nombre Empresa/Persona");
            DataColumn dc2 = new DataColumn("Primer Apellido");
            DataColumn dc3 = new DataColumn("Segundo Apellido");
            DataColumn dc4 = new DataColumn("Email");
            DataColumn dc5 = new DataColumn("Numero Telefono 1");
            DataColumn dc6 = new DataColumn("Numero Telefono 2");
            DataColumn dc7 = new DataColumn("Estado");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);

            DataRow dr = dt.NewRow();
            dr["Identificacion"] = "3102415633";
            dr["Nombre Empresa/Persona"] = "Greencore";
            dr["Primer Apellido"] = "Solutions";
            dr["Segundo Apellido"] = "SRL";
            dr["Email"] = "xxx@greecore.co.cr";
            dr["Numero Telefono 1"] = "111-111-111";
            dr["Numero Telefono 2"] = "222-222-222";
            dr["Estado"] = "Activo";
            dt.Rows.Add(dr);

            gvCitas.DataSource = dt;
            gvCitas.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Proveedores";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalProveedores", "$('#ModalProveedores').modal();", true);
            upModal.Update();

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Editar Proveedor";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalProveedores", "$('#ModalProveedores').modal();", true);
            upModal.Update();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Proveedor";
            lblEliminarbody.Text = "Desea Eliminar el Proveedor ?";
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
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
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
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
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
    }

}
