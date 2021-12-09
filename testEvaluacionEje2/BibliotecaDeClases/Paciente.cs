using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Paciente : Persona
    {
        private int dni;
        private int edad;
        private string obraSocial;
        private string enfermedad;
        private bool pacienteAtendido;

        public int Dni
        {
            get { return dni; }
        }
        public int Edad
        {
            get { return edad; }
        }

        public string ObraSocial
        {
            get { return obraSocial; }
        }

        public string Enfermedad
        {
            get { return enfermedad; }
        }

        public bool PacienteAtendido
        {
            get { return pacienteAtendido; }
            set { pacienteAtendido = value; }
        }

        public Paciente(string nombre, string apellido, int dni, int edad, string obraSocial, string enfermedad, bool pacienteAtendido) : base(nombre, apellido)
        {
            this.dni = dni;
            this.edad = edad;
            this.obraSocial = obraSocial;
            this.enfermedad = enfermedad;
            this.pacienteAtendido = pacienteAtendido;
        }
        public static explicit operator string(Paciente p)
        {
            return p.enfermedad;
        }

        public static bool operator ==(Paciente p1, Paciente p2)//Dos pacientes van a ser iguales si coinciden sus DNI
        {
            return (p1 is not null && p2 is not null) && p1.dni == p2.dni;
        }
        public static bool operator !=(Paciente p1, Paciente p2)
        {
            return !(p1 == p2);
        }
        public static string MostrarPacienteSinAtender(Paciente p)
        {
            if (p.pacienteAtendido == false)
            {
                return ($"El paciente {p.Nombre} {p.Apellido} de {p.Edad} anios, con DNI {p.Dni} tiene {p.enfermedad} y la obra social {p.ObraSocial}");
            }
            else
            {
                return ("No hay pacientes por atender");
            }
        }

    }
}
