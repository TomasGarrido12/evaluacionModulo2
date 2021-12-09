using System;
using System.Collections.Generic;
namespace BibliotecaDeClases
{
    public class Persona
    {
        private string nombre;
        private string apellido;

        public string Nombre
        {
            get { return nombre; }
        }
        public string Apellido
        {
            get { return apellido; }
        }
        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}
