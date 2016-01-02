using NorthwindDatos.DAO;
using NorthwindDatos.DTO;
using NorthwindDatos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindNegocios
{
    public class ProductosDelegado : Conexion
    {


        private ProductosDAO dao;

        public ProductosDelegado()
        {
            dao = new ProductosDAO(this.cnn);
        }

        public IQueryable<TopProductosDTO> consultarTopProductos(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                this.Conectar();
                return dao.sp_TopVentasRangoFechas(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Desconectar();
            }
        }


    }
}
