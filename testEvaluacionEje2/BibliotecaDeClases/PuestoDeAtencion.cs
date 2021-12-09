using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BibliotecaDeClases
{
    public class PuestoDeAtencion
    {
        public enum Consultorio
        {
            Consultorio1
        }

        private static int numeroActual;
        private Consultorio consultorio;

        public static int NumeroActual
        {
            get { return numeroActual; }
            set { numeroActual = value; }
        }

        static PuestoDeAtencion()
        {
            numeroActual = 0;
        }

        public PuestoDeAtencion(Consultorio consultorio)
        {
            this.consultorio = consultorio;
        }
        public bool Atender(Medico m, Paciente p, Consulta c)//Asigno un medico y paciente a una consulta, luego cambio el estado de la consulta a finalizada
        {
            if ((p is not null && m is not null) && !(m.Atendiendo && p.PacienteAtendido) && (c.Asignada == true))
            {
                Thread.Sleep(2000);
                m.PacientesAtendidos++;
                c.Finalizada = true;
                Consulta.ResultadoConsulta(p,c);
                return true;
            }
            return false;
        }

    }
}
