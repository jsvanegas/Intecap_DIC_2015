using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;//para manejar archivos

namespace Agenda
{
    class ContactoAdmin
    {
        public void insertar(Contacto nuevo) {
            try
            {
                string ruta = @"C:\Users\capacitaciones\Desktop\contactos.csv";
                string linea = string.Concat(nuevo.Nombre, ",", nuevo.Apellido, ",", nuevo.Telefono, ",", nuevo.Correo);
                StreamWriter escritor = File.AppendText(ruta);
                escritor.WriteLine(linea);
                escritor.Flush();
                escritor.Close();
                escritor.Dispose();
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Acceso Denegado");
            }
            catch (PathTooLongException) {
                throw new Exception("El nombre del archivo es muy largo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Contacto> consultar(string ruta) {
            List<Contacto> contactos = new List<Contacto>();
            string[] lineas = File.ReadAllLines(ruta);
            for (int i = 0; i < lineas.Length; i++)
            {
                string[] datos = lineas[i].Split(',');
                Contacto persona = new Contacto();
                persona.Nombre = datos[0];
                persona.Apellido = datos[1];
                persona.Telefono = datos[2];
                persona.Correo = datos[3];
                contactos.Add(persona);
            }
            return contactos;
        }




    }
}
