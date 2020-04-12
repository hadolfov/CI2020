using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HappyPet4._0
{
    public partial class TipoMarca1__1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPrueba();
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                gvCitas.SelectedIndex = -1;
            }
        }

        private void CargarPrueba()
        {
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Id Marca");
            DataColumn dc1 = new DataColumn("Nombre de la Marca");
            DataColumn dc2 = new DataColumn("Estado");


            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);


            DataRow dr = dt.NewRow();
            dr["Id Marca"] = "1";
            dr["Nombre de la Marca"] = "Entrada";
            dr["Estado"] = "Activo";
            dt.Rows.Add(dr);

            gvCitas.DataSource = dt;
            gvCitas.DataBind();
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Marcas";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalMarcas", "$('#ModalMarcas').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Editar Marcas";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalMarcas", "$('#ModalMarcas').modal();", true);
            upModal.Update();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Marcas";
            lblEliminarbody.Text = "Desea Eliminar la siguiente Marca?";
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
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                }
                else
                {
                    //gvCitas.SelectedIndex = index;
                    //if (gvCitas.Rows[index].Cells[6].Text == "Confirmada")
                    //{
                    //    btnAtender.Visible = true;
                    //}
                    //else
                    //{
                    //    btnAtenderCita.Visible = false;
                    //}
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
                }
                //TableCell contactName = selectedRow.Cells[1];
                //string contact = contactName.Text;
            }
        }

    }
}