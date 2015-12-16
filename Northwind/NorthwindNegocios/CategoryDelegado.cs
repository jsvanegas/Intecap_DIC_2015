using NorthwindDatos.DAO;
using NorthwindDatos.Persistencia;
using NorthwindDatos.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindNegocios
{
    public class CategoryDelegado:Conexion
    {
        private CategoryDAO dao;
        public CategoryDelegado() {
            dao = new CategoryDAO(this.cnn);
        }

        public int insertar(string nombre, string descripcion) {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion))
            {
                throw new Exception("Campos inválidos");
            }

            CategoryVO nueva = new CategoryVO() { CategoryName = nombre, Description = descripcion };
            try
            {
                this.Conectar();
                return dao.insertar(nueva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                this.Desconectar();
            }
        }

        public List<CategoryVO> consultar() {
            try
            {
                Conectar();
                return dao.consultar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                Desconectar();
            }
        }


    }
}
