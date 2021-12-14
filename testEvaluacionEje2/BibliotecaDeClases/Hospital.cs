using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Hospital
    {
        public Queue<Medico> medicosDisponibles;
        private PuestoDeAtencion consultorio;
        public Queue<Consulta> listaDeConsulta;
        private string nombre;

        public int PacientesPendientes
        {
            get { return Medico.listaDeEspera.Count; }
        }
        public Consulta Consulta
        {
            get { return listaDeConsulta.Dequeue(); }//Para finalizar la consulta
            set { _ = this + value; }
        }
        private Hospital()
        {
            medicosDisponibles = new Queue<Medico>();
            listaDeConsulta = new Queue<Consulta>();
            consultorio = new PuestoDeAtencion(PuestoDeAtencion.Consultorio.Consultorio1);
        }
        public Hospital(string nombre):this()
        {
            this.nombre = nombre;
        }
        public Medico Medico
        {
            get { return medicosDisponibles.Dequeue(); }
            set { _ = this + value; }//el this es el objeto de tipo Hospital y el value es el objeto de tipo Medico. Con la sobrecarga del + agrego al medico a la listaDeMedicosDisponibles en caso de que no se encuentre ahi
        }
        public Paciente Paciente
        {
            get { return Medico.listaDeEspera.Dequeue(); }//retorna el primer paciente de la lista de atencion
        }

        public static bool operator ==(Hospital h, Consulta c)
        {
            foreach (Consulta consulta in h.listaDeConsulta)
            {
                if (consulta == c)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Hospital h, Consulta c)
        {
            return !(h == c);
        }
        public static bool operator +(Hospital h, Consulta c)
        {
            if ((h != c) && c.Asignada == false)
            {
                h.listaDeConsulta.Enqueue(c);
                return c.Asignada = true;
            }
            return false;
        }
        public static bool operator ==(Hospital h, Medico m)
        {
            foreach (Medico medico in h.medicosDisponibles)
            {
                if (medico == m)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Hospital h, Medico m)
        {
            return !(h == m);
        }

        public static bool operator +(Hospital h, Medico m)//agrego un medico a la lista de medicos disponibles
        {
            if ((h != m) && m.Atendiendo == false)
            {
                h.medicosDisponibles.Enqueue(m);
                m.Atendiendo = true;
                return true;
            }
            return false;
        }

        public static bool operator ~(Hospital h) //Con este metodo atiendo al proximo paciente en la fila utilizando al proximo medico disponible
        {
            if (h.PacientesPendientes > 0)
            {
                return h.consultorio.Atender(h.Medico, h.Paciente, h.Consulta);
            }
            return false;
        }

        public static string MostrarListadoMedicosDisponibles(Hospital h)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Medico medico in h.medicosDisponibles)
            {
                sb.AppendLine(Medico.MostrarMedicoDisponible(medico));
            }
            return sb.ToString();
        }

    }
}
