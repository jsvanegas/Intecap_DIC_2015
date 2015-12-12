using IntroduccionADO.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntroduccionADO
{
    public partial class Form1 : Form
    {

        private string cnnStr = "Data source=127.0.0.1; Initial Catalog=Northwind;Integrated Security=true;";
        private SqlConnection cnn;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(cnnStr);
            cnn.Open();
            if (cnn.State == ConnectionState.Open)
            {
                MessageBox.Show("Conectado a la BD Northwind");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ValidarConexion();
            string sql = "SELECT * FROM Categories";
            DataTable tbl = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter(sql, cnn);
            adaptador.Fill(tbl);
            dataGridView1.DataSource = tbl;


            /*
            List<CategoryVO> categorias = new List<CategoryVO>();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                categorias.Add(ObtenerCategoria(reader));
            }
            cnn.Close();
            dataGridView1.DataSource = categorias;
             */ 
        }

        private static CategoryVO ObtenerCategoria(SqlDataReader reader)
        {
            CategoryVO vo = new CategoryVO()
            {
                CategoryID = reader.GetInt32(0),
                CategoryName = reader.GetString(1),
                Description = reader.GetString(2)
            };
            return vo;
        }

        private void ValidarConexion()
        {
            if (cnn == null)
            {
                cnn = new SqlConnection(cnnStr);
            }

            if (cnn.State != ConnectionState.Open)
            {
                cnn.Open();
            }
        }
    }
}
