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
                string sql = string.Format("INSERTO INTO Categories (CategoryName, Description) VALUES('{0}', '{1}')", vo.CategoryName, vo.Description);
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
                List<CategoryVO> categorias = new List<CategoryVO>();
                string sql = "SELECT * FROM Categories";
                cmd.CommandText = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(obtenerCategoria(reader));
                }
                return categorias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
