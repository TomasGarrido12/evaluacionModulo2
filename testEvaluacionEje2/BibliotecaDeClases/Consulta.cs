using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Consulta
    {
        private bool finalizada;
        private bool asignada;
        private string resultado;
        private string areaDeEspecializacion;
        private Paciente paciente;
        private Medico medico;
        public bool Finalizada
        {
            get { return finalizada; }
            set { finalizada = value; }
        }

        public bool Asignada
        {
            get { return asignada; }
            set { asignada = value; }
        }

        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public string AreaDeEspecializacion
        {
            get { return areaDeEspecializacion; }
        }

        public Paciente PacientePropiedad
        {
            get { return paciente; }
        }

        public Medico MedicoPropiedad
        {
            get { return medico; }
        }
        public Consulta(bool finalizada, bool asignada, string resultado, string areaDeEspecializacion, Paciente paciente, Medico medico)
        {
            this.resultado = resultado;
            this.areaDeEspecializacion = areaDeEspecializacion;
            this.paciente = paciente;
            this.medico = medico;
        }
        public static void ResultadoConsulta(Paciente p,Consulta c)
        {
            switch (p.Enfermedad)
            {
                case "Dolor de panza":
                    c.Resultado = $"El paciente {p} con la consulta {c} tiene que tomar 200mg de Antiespasmódicos cada 8 horas";
                    Console.WriteLine(c.Resultado);
                    break;
                case "Emergencia":
                    c.Resultado = $"El paciente{p} con la consulta {c} tiene que ser trasladado a la sala de emergencias";
                    Console.WriteLine(c.Resultado);
                    break;
                case "Dolor de cabeza":
                    c.Resultado = $"El paciente {p} con la consulta {c} tiene que tomar 150mg de Paracetamol cada 6 horas";
                    Console.WriteLine(c.Resultado);
                    break;
            }
        }
    }
}
