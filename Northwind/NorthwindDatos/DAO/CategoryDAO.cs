using NorthwindDatos.VO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDatos.DAO
{
    public class CategoryDAO
    {
        private SqlConnection cnn;
        private SqlCommand cmd;

        public CategoryDAO(SqlConnection _cnn) {
            this.cnn = _cnn;
            cmd = new SqlCommand();
            cmd.Connection = this.cnn;
        }

        public int insertar(CategoryVO vo) {
            try
            {
                string sql = string.Format("INSERT INTO Categories (CategoryName, Description) VALUES('{0}', '{1}')", vo.CategoryName, vo.Description);
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CategoryVO> consultar() {
            try
            {
                string sql = "SELECT * FROM Categories";
                cmd.CommandText = sql;
                return recorrerReaderCategorias(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CategoryVO> consultar(string filtro) {
            try
            {
                string q = "SELECT * FROM Categories WHERE CategoryName LIKE '%{0}%' OR Description LIKE '%{0}%'";
                cmd.CommandText = string.Format(q, filtro);
                return recorrerReaderCategorias(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<CategoryVO> recorrerReaderCategorias(SqlCommand cmd)
        {
            List<CategoryVO> categorias = new List<CategoryVO>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                categorias.Add(obtenerCategoria(reader));
            }
            return categorias;
        }


        private CategoryVO obtenerCategoria(SqlDataReader reader)
        {
            return new CategoryVO()
            {
                CategoryID = reader.GetInt32(0),
                CategoryName = reader.GetString(1),
                Description = reader.GetString(2)
            };
        }

    }
}
