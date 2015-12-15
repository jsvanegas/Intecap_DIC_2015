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

        private string cnnStr = "Data source=192.168.7.79;Initial Catalog=Northwind;Integrated Security=false;User Id=IntecapNET;Password=IntecapNET;";
        private SqlConnection cnn;

        public Form1()
        {
            InitializeComponent();
            cargarListaCategorias();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string sql =
                string.Format("INSERT INTO Categories(CategoryName, Description) " +
                              "VALUES('{0}', '{1}')", nombre, descripcion);

            ValidarConexion();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            int result = cmd.ExecuteNonQuery();
            if (result>0)
            {
                MessageBox.Show("Categoria Guardada");
            }
        }


        private void cargarListaCategorias() {
            ValidarConexion();
            string sql = "SELECT CategoryID, CategoryName FROM Categories";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            DataTable td = new DataTable();
            new SqlDataAdapter(sql, cnn).Fill(td);

            lstCategorias.DisplayMember = "CategoryName";
            lstCategorias.ValueMember = "CategoryID";
            lstCategorias.DataSource = td;

        }

        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedValue!=null)
            {
                int id = Convert.ToInt32(lstCategorias.SelectedValue);
                ValidarConexion();
                string sql =
                    string.Format("SELECT CategoryName, Description FROM Categories WHERE CategoryID={0}", id);
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                CategoryVO vo = new CategoryVO();
                if (reader.Read())
                {
                    vo.CategoryName = reader.GetString(0);
                    vo.Description = reader.GetValue(1).ToString();
                    txtNombreActualizar.Text = vo.CategoryName;
                    txtDescripcionActualizar.Text = vo.Description;
                }
                else
                {
                    MessageBox.Show("No se encontró la categoría " + lstCategorias.Text);
                }
                cnn.Close();    
            }
            

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreActualizar.Text;
            string descripcion = txtDescripcionActualizar.Text;
            int id = Convert.ToInt32(lstCategorias.SelectedValue);
            ValidarConexion();
            string sql = string.Format(
                "UPDATE Categories SET CategoryName='{0}', Description='{1}' WHERE CategoryID={2}",
                nombre, descripcion, id);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            if (cmd.ExecuteNonQuery()>0)
            {
                MessageBox.Show("Registro actualizado");
                cargarListaCategorias();
            }
        }




    }
}
