using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Security.Permissions;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;
using System.ComponentModel;
using Microsoft.OData.Edm;
using Microsoft.Graph;
using Newtonsoft.Json.Converters;

namespace DPRN1_U3_A3_PIVM
{
    class Proceso
    {
        Menu menu = new Menu();

        private List<Solicitante> listaSolicitante;
        private Dato dato;
        private Solicitante solicitante;


        public void SolicitarOpciones()
        {
            listaSolicitante = new List<Solicitante>();

            int Opcion;
            String _distancia;
            String destino;

            dato = new Dato("Solicitante.bd");

            do
            {
                do
                {
                    if (File.Exists("Solicitante.bd"))
                    {
                        listaSolicitante = dato.deserializar();
                        Console.WriteLine("\n***  Existe Solicitudes Registradas *** ");
                    }

                    Console.WriteLine("\n1. Registrar Solicitante");
                    Console.WriteLine("2. Mostrar listado de Solicitante");
                    Console.WriteLine("3. Salir");
                    Console.WriteLine("\nSeria tan amable de Seleccionar una opcion");
                    Opcion = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (Opcion < 1 || Opcion > 3)
                    {
                        Console.WriteLine("Ingrese una opción válida [1-3]");
                    }

                } while (Opcion < 1 || Opcion > 3);

                switch (Opcion)
                {
                    case 1:
                        // => Registrar al Solicitante

                        datosSolicitante();
                        Console.Clear();
                        menu.menu();
                        SolicitarOpciones();
                        break;

                    case 2:
                        // => // => Tramite Visa

                        Console.Clear();
                        menu.menu();
                        ListarSolicitantes();
                        Console.Clear();
                        menu.menu();

                        break;

                    case 3:
                        // => Exit
                        Console.WriteLine("\nGracias por utilizar nuestros servicios\n");
                        Environment.Exit(0);
                        break;

                }

            } while (Opcion != 3);
        }
        public void ListarSolicitantes()
        {
            Console.WriteLine("-Lista de Solicitantes");
            Console.ReadKey();
            foreach (Solicitante b in listaSolicitante)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("ID: " + b.iniciales);
                Console.WriteLine("Nombre: " + b.nombre);
                Console.WriteLine("Apellido: " + b.apellidos);
                Console.WriteLine("Fecha nacimiento: " + b.fechNacimiento);
                Console.WriteLine("Tipoo: $" + b.tipo);
                Console.WriteLine("Costo de la Visa: " + b.costo);
                Console.WriteLine("Vigencia: " + b.vigencia);
                Console.WriteLine("Requisitos: " + b.requisitos);

                Console.ReadKey();

            }
        }
        // * CALCULO DE COSTO
        private Tuple<int, int> calculandoCostos(int edad)
        {
            int costoVisa = 0;
            int tipoVisa = 0;
            int Opcion;

            Console.WriteLine("\nSeleccione un tipo de Visa");
            if (edad <= 15)
            {
                costoVisa = 3200;
                tipoVisa = 1;
            }
            else
            {


                    do
                    {

                        Console.WriteLine("1. Visa Turista");
                        Console.WriteLine("2. Visa Peticion");
                        Console.WriteLine("3. Visa Empresarial");
                        Console.WriteLine("4. Regresar ");
                        Console.WriteLine("\nSeria tan amable de Seleccionar una opcion");
                        Opcion = int.Parse(Console.ReadLine());
                        //Console.Clear();

                        if (Opcion < 1 || Opcion > 4)
                        {
                            Console.WriteLine("Ingrese una opción válida [1-4]");
                        }
                    } while (Opcion < 1 || Opcion > 4);
                    switch (Opcion)
                    {
                        case 1:
                            costoVisa = 3200;
                            tipoVisa = 1;
                            break;
                        case 2:
                            costoVisa = 3800;
                            tipoVisa = 2;
                            break;
                        case 3:
                            costoVisa = 4100;
                            tipoVisa = 3;
                            break;
                        case 4:
                            break;
                    }

            }

            return new Tuple<int, int>(costoVisa, tipoVisa);
        }

        public void datosSolicitante()
        {

            Solicitante solicitante = new Solicitante();

            Console.WriteLine("\nSeria tan amable de Introducir los siguientes datos");

            Console.Write("Introdusca sus Iniciales: ");
            string iniciales;
            iniciales = Console.ReadLine();
            solicitante.iniciales = iniciales;

            Console.WriteLine("Nombre del solicitante: ");
            solicitante.nombre = Console.ReadLine();

            Console.WriteLine("Apellidos: ");
            solicitante.apellidos = Console.ReadLine();

            Console.WriteLine("Fecha Nacimiento DD/MM/YYY: ");
            string ano = Console.ReadLine();
            DateTime fechaNacimiento = Convert.ToDateTime(ano);
            int edad = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
            solicitante.fechNacimiento = edad;

            int costoVisa = 0;
            int tipoVisa = 0;
            (costoVisa, tipoVisa) = calculandoCostos(edad);
            solicitante.tipo = tipoVisa;
            solicitante.costo = costoVisa;

            Console.WriteLine("Vigencia: ");
            solicitante.vigencia = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Requisitos: ");
            //solicitante.requisitos = Convert.ToBoolean(Console.ReadLine());

            listaSolicitante.Add(solicitante);
            dato.serializar(listaSolicitante);
            Console.WriteLine("Datos Guardados");
            Console.ReadKey();


            Console.WriteLine("Los datos del solicitante son: ");
            MostrarDatos(iniciales);
            Console.ReadKey();

        }
        public void MostrarDatos(string Iniciales)
        {
            menu.menu();
            Console.WriteLine("Me proporciona las Iniciales del Solicitante");
            String ValorEntrada = Console.ReadLine();

            if (ValorEntrada == null)
            {
                Console.WriteLine("Me proporciona las Iniciales del Solicitante ****");
                ValorEntrada = Console.ReadLine();
            }
            Console.ReadKey();
            foreach (Solicitante b in listaSolicitante)
            {

                if (b.iniciales == ValorEntrada)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Nombre: " + b.nombre);
                    Console.WriteLine("Apellido: " + b.apellidos);
                    Console.WriteLine("Fecha nacimiento: " + b.fechNacimiento);
                    Console.WriteLine("Tipoo: $" + b.tipo);
                    Console.WriteLine("Costo de la Visa: " + b.costo);
                    Console.WriteLine("Vigencia: " + b.vigencia);
                    Console.WriteLine("Requisitos: " + b.requisitos);
                }

                Console.ReadKey();

            }
        }

    }
}
