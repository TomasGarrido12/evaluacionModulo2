using System;
using BibliotecaDeClases;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Paciente p1 = new Paciente("Tomas","Garrido",39744898,25,"No tiene","Emergencia",false);
            Paciente p2 = new Paciente("Paula","Gonzales",3948484,26,"Tiene", "Dolor de cabeza",false);
            Medico m1 = new Medico("Jose","Serravale","Otorrino",0,false);
            Medico m2 = new Medico("Carlos", "Pepoide", "Ortopedia", 0, false);
            Consulta c1 = new Consulta(false,false,"","",p1,m1);
            Consulta c2 = new Consulta(false, false, "", "", p2, m1);
            Consulta c3 = new Consulta(false, false, "", "", p1, m2);
            Hospital h1 = new Hospital("Santa Maria");

            if (h1 + m1)
            {
                Console.WriteLine("Se agrego m1 a la lista de medicos dispoinibles");
            }

            if (m1 + p1)
            {
                Console.WriteLine("Se agrego c1 a la cola");
            }


            //if ()
            //{
            //    Console.WriteLine("Cliente c1 ya esta en la cola");
            //}

            //if (n1 + c2)
            //{
            //    Console.WriteLine("Se agrego c2 a la cola");
            //}

            //if (n1 + c3)

            //{
            //    Console.WriteLine("Se agrego c3 a la cola");
            //}

            //Console.WriteLine("Clientes pendientes: {0}", n1.ClientesPendientes);

            //while (~n1)
            //{
            //    Console.WriteLine("Clientes pendientes: {0}", n1.ClientesPendientes);
            //}
        }
    }
}
