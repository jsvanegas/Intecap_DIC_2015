using NorthwindNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWeb
{
    public partial class categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }

        private void cargarTabla()
        {

            CategoryDelegado delegado = new CategoryDelegado();
            gridCategorias.DataSource = delegado.consultar(txtFiltro.Text);
            gridCategorias.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            new CategoryDelegado().insertar(txtNombre.Text, txtDescripcion.Text);
            cargarTabla();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarTabla();
        }
    }
}