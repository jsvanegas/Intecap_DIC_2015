using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDatos.DAO
{
    public class CategoryDAO
    {

        private NorthwindEntities db;

        public CategoryDAO(NorthwindEntities _db) {
            this.db = _db;
        }

        public int insertar(Categories nueva) {
            db.Categories.Add(nueva);
            return db.SaveChanges();
        }

        public List<Categories> consultar() {
            return db.Categories.ToList();
        }

        public List<Categories> consultar(string filtro) { 
            return (from c in db.Categories
                    where c.CategoryName.Contains(filtro) || c.Description.Contains(filtro)
                    select c).ToList();
            /*
            return db.Categories
                    .Where(c => c.CategoryName.Contains(filtro) || c.Description.Contains(filtro))
                    .ToList();
             */ 
        }

        public int insertar(List<Categories> nuevos) {
            foreach (var categoria in nuevos)
            {
                db.Categories.Add(categoria);
            }
            return db.SaveChanges();
        }


        public int actualizar(int id, Categories editar) {
            var objetoActualizar = consultarPorId(id);
            objetoActualizar.CategoryName = editar.CategoryName;
            objetoActualizar.Description = editar.Description;
            return db.SaveChanges();
        }

        public int eliminar(int id) {
            db.Categories.Remove(consultarPorId(id));
            return db.SaveChanges();
        }

        public Categories consultarPorId(int id) {
            /*
            return (from f in db.Categories
                   where f.CategoryID == id
                   select f).SingleOrDefault();
            */
            return db.Categories.Find(id);


        }



    }
}
