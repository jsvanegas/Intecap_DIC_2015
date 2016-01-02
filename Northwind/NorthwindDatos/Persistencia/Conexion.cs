using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDatos.Persistencia
{
    public class Conexion
    {
        protected SqlConnection cnn;

        private string servidor = @"JUANCHO\SQLEXPRESS";
        private string baseDatos = "Northwind";
        private string usuario = "IntecapNET";
        private string clave = "IntecapNET";

        public Conexion() {
            cnn = new SqlConnection(
                string.Format(
                    "Data source={0};Initial Catalog={1};Integrated Security=true;",
                //"Data source={0};Initial Catalog={1};User Id={2};Password={3}",
                    servidor, baseDatos, usuario, clave
                )
            );
        }

        protected void Conectar() {
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Desconectar() {
            try
            {
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
