using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class FrmRegistrar : Form
    {
        public FrmRegistrar()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuadar_Click(object sender, EventArgs e)
        {
            Contacto nuevo = new Contacto();
            nuevo.Nombre = txtNombre.Text;
            nuevo.Apellido = txtApellido.Text;
            nuevo.Telefono = txtTelefono.Text;
            nuevo.Correo = txtCorreo.Text;
            ContactoAdmin admin = new ContactoAdmin();

            try
            {
                admin.insertar(nuevo);
                MessageBox.Show("Contacto Agregado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
