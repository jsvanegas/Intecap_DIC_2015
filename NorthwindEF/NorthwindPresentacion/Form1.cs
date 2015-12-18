using NorthwindDelegado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindPresentacion
{
    public partial class Form1 : Form
    {
        private CategoryDelegado delegado;
        public Form1()
        {
            delegado = new CategoryDelegado();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultar();
        }

        private void consultar() {
            dataGridView1.DataSource = delegado.consultar(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consultar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delegado.insertar(textBox1.Text, textBox2.Text);
            consultar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value);
            delegado.eliminar(id);
            consultar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var celdas = dataGridView1.SelectedRows[0].Cells;
            int id = Convert.ToInt32(celdas[0].Value);
            string nombre = textBox1.Text;
            string dx = textBox2.Text;
            delegado.actualizar(id, nombre, dx);
            consultar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var celdas = dataGridView1.SelectedRows[0].Cells;
            textBox1.Text = celdas[1].Value.ToString();
            textBox2.Text = celdas[2].Value.ToString();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agregadas: "+ delegado.insertarVarias());
            consultar();
        }
    }
}
