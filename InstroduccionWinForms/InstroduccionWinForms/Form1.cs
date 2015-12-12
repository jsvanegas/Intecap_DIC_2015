using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstroduccionWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var marcas = new[]{
                new { id=1, nombre="Samsung"},
                new { id=2, nombre="Lenovo"},
                new { id=3, nombre="Apple"},
                new { id=4, nombre="SONY"},
                new { id=5, nombre="LG"},
            };

            /*
            for (int i = 0; i < marcas.Length; i++)
            {
                cmbMarcas.Items.Add(marcas[i]);
            }
             */
            cmbMarcas.DataSource = marcas;
            cmbMarcas.DisplayMember = "nombre";
            cmbMarcas.ValueMember = "id";





        }
    }
}
