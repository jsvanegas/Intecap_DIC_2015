using NorthwindDatos.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDatos.DAO
{
    public class ProductosDAO
    {
        private SqlConnection cnn;
        private SqlCommand cmd;

        public ProductosDAO(SqlConnection _cnn) {
            this.cnn = _cnn;
            cmd = new SqlCommand();
            cmd.Connection = this.cnn;
        }

        public IQueryable<TopProductosDTO> sp_TopVentasRangoFechas(DateTime fechaInicio, DateTime fechaFin) {
            List<TopProductosDTO> lista = new List<TopProductosDTO>();
            cmd.CommandText = "sp_TopVentasRangoFechas";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("fi", System.Data.SqlDbType.Date).Value = fechaInicio;
            cmd.Parameters.Add("ff", System.Data.SqlDbType.Date).Value = fechaFin;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new TopProductosDTO()
                    {
                        Nombre = reader.GetString(0),
                        Cantidad = reader.GetInt32(1)
                    });
                }
                return lista.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
