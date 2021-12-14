using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BibliotecaDeClases
{
    public class Medico : Persona
    {

        private string especialidad;
        private int pacientesAtendidos = 0;
        private bool atendiendo;
        public Queue<Paciente> listaDeEspera;

        public string Especialidad
        {
            get { return especialidad; }
        }

        public int PacientesAtendidos
        {
            get { return pacientesAtendidos; }
            set { pacientesAtendidos = value; }
        }

        public bool Atendiendo
        {
            get { return atendiendo; }
            set { atendiendo = value; }
        }

        private Medico(string nombre, string apellido):base(nombre,apellido)
        {
            this.listaDeEspera = new Queue<Paciente>();
        }
        public Medico(string nombre, string apellido, string especialidad, int pacientesAtendidos, bool atendiendo) : this(nombre,apellido)
        {
            this.especialidad = especialidad;
            this.pacientesAtendidos = pacientesAtendidos;
            this.atendiendo = atendiendo;

        }
        public static bool operator ==(Medico m, Paciente p)
        {
            foreach (Paciente paciente in m.listaDeEspera)
            {
                if (paciente == p)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Medico m, Paciente p)
        {
            return !(m == p);
        }
        public static bool operator +(Medico m, Paciente p)//agrego un paciente a la lista de espera
        {
            if ((m != p) && p.PacienteAtendido == false)
            {
                m.listaDeEspera.Enqueue(p);
                p.PacienteAtendido = true;
                return true;
            }
            return false;
        }
        public static bool EstadoActualMedico(Medico m)
        {
            return m.Atendiendo;
        }
        public static string MostrarMedicoDisponible(Medico m)
        {
            if (m.Atendiendo == false)
            {
                return ($"El medico {m.Nombre} {m.Apellido} esta especializado en el area de {m.especialidad} y tiene {m.PacientesAtendidos} pacientes atendidos");
            }
            else
            {
                return ($"No hay medicos disponibles");
            }
        }
        public static string MostrarListadoPacientesSinAtender(Medico m)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paciente paciente in m.listaDeEspera)
            {
                sb.AppendLine(Paciente.MostrarPacienteSinAtender(paciente));
            }
            return sb.ToString();
        }

    }
}
