using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Contacto
    {

        #region Atributos

        private string nombre;
        //private string apellido;
        private string telefono;
        private string correo;

        #endregion

        #region Propiedades
        //ejemplo de propiedad tradicional
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        //ejemplo de propiedad simplificada
        public string Apellido { get; set; }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        #endregion

    }
}
