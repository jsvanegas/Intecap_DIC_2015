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
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void saludar(object sender, EventArgs e)
        {
            MessageBox.Show("Hola mundo");
        }

        private void txtCampo1_TextChanged(object sender, EventArgs e)
        {
            txtCampo2.Text = txtCampo1.Text;
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;

            if (int.TryParse(txtA.Text, out a) && int.TryParse(txtB.Text, out b))
            {
                txtResultado.Text = (a + b).ToString();
            }
            else {
                MessageBox.Show("Alguno de los valores no es válido");
            }


        }
    }
}
