using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static ConsoleApp7.Program;

namespace ConsoleApp7
{
    internal class Program
    {
        // structs //
        public struct Pokemon
        {

            // Propiedades

            public string nombre { get; set; }
            public int nivel { get; set; }

            public int ps { get; set; }
            public int psa { get; set; }

            public int ataque { get; set; }

            public int defensa { get; set; }

            public int ae { get; set; }

            public int de { get; set; }

            public int velocidad { get; set; }

            public string estado { get; set; }



            // Constructor
            public Pokemon(string nombre, int nivel, int ps, int psa, int ataque, int defensa, int ae, int de, int velocidad, string estado)
            {
                this.nombre = nombre;
                this.nivel = nivel;
                this.ps = ps;
                this.psa = psa;
                this.ataque = ataque;
                this.defensa = defensa;
                this.ae = ae;
                this.de = de;
                this.velocidad = velocidad;
                this.estado = estado;
            }

            public void mostrar_cambio_alteracion(string alterado_antiguo) {
                if (alterado_antiguo == "Normal")
                {
                    Console.WriteLine(nombre + " " + ps + " ahora esta" + estado);
                }else if(alterado_antiguo != estado){
                    Console.WriteLine(nombre + " " + ps + " paso de estar" + " " + alterado_antiguo + "a " + estado);
                }
                else {
                    Console.WriteLine(nombre + " " + ps + "no cambio de estado");
                }
            }

            public bool esDosil(int medallas) {
                int nivelcontrolable = 20 + (medallas * 10);
                if (nivelcontrolable < nivel)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public bool tienePeligrosidadalta() {
                if ((ataque + ae + velocidad) / 3 > 60)
                {
                    return true;
                }
                else {
                    return false;
                }
                
            }
            public void curar() {
                psa = ps;
            }

            public void recibirDaño(int daño, bool tipo) {
                //Tipo es un booleano, asumamos 0 para ataque comun 1 para ataque especial.
                int porcentajeDefensa = 0;
                if (tipo) {
                    porcentajeDefensa = (daño * (defensa/2)) / 100;
                    psa = psa - (daño - porcentajeDefensa);
                }
                else {
                    porcentajeDefensa = (daño * (de/2)) / 100;
                    psa = psa - (daño - porcentajeDefensa);
                }
            }

        }

        public struct Entrenador
        {

            // propiedades

            public string nombre { get; set; }
            public int pokedolares { get; set; }
            public string[] medallas { get; set; }
            public Pokemon[] equipo { get; set; }

            //constructor

            public Entrenador(string nombre, int pokedolares, string[] medallas, Pokemon[] equipo)
            {
                this.nombre = nombre;
                this.pokedolares = pokedolares;
                this.medallas = medallas;
                this.equipo = equipo;
            }

            //funciones

            //funcion dame nivel recorre la lista de pokemons y suma todos sus niveles
            public int damenivel()
            {
                int retorno = 0;
                for (int i = 0; i <= 5; i++)
                {
                    retorno = retorno + equipo[i].nivel;
                }
                return retorno;
            }

            public int cuantosPuedoControlar()
            {
                int cantidadControlable = 0;
                int cantMedallas = medallas.Length;
                for (int i = 0; i <= 5; i++)
                {
                    if (equipo[i].esDosil(cantMedallas))
                    {
                        cantidadControlable += 1;
                    }
                }
                Console.WriteLine(cantidadControlable);
                return cantidadControlable;
            }

            public void curarEquipo()
            {
                for (int i = 0; i <= 5; i++)
                {
                    equipo[i].curar();
                }
                Console.WriteLine("Se ha curado al equipo");
            }

            public int cantidadPeligrosidadAlta()
            {
                int contador = 0;
                for (int i = 0; i <= 5; i++)
                {
                    if (equipo[i].tienePeligrosidadalta())
                    {
                        contador++;
                    }
                }
                return contador;
            }

            public bool perdio()
            {
                // si perdio es verdadero si no perdio es falso
                int contador = 0;
                for (int i = 0; i <= 5; i++)
                {
                    if (equipo[i].psa > 0)
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

        }

        //--------------------------------------------------------------------------------------------------//

        // funciones //
        public static void comparar_nivel(Entrenador entrenador1, Entrenador entrenador2){
            // comparacion
            if (entrenador1.damenivel() > entrenador2.damenivel())
            {
                Console.WriteLine(entrenador1.nombre + " Tiene mas nivel que: " + entrenador2.nombre);
            }
            else if (entrenador2.damenivel() > entrenador1.damenivel())
            {
                Console.WriteLine(entrenador2.nombre + " Tiene mas nivel que: " + entrenador1.nombre);
            }
            else
            {
                Console.WriteLine("Tienen el mismo nivel");
            }
        }

        public static void aplicar_efecto_alterado(Entrenador ash, Entrenador pepe) {
            string[] efectos = ["Paralizado", "Quemado", "Envenenado", "Gravemente envenenado", "Dormido", "Congelado"];
            Entrenador[] entrenadores = { ash, pepe };
            int opcion_entrenador = -1;
            int opcion_pokemon = -1;
            int opcion_efecto = -1;
            int i,x;

            do {
                Console.WriteLine("Elegir a que entrenador queres aplicarle un efecto a uno de sus pokemones");
                Console.WriteLine("1- Ash, 2- Pepe");
                opcion_entrenador = Convert.ToInt32(Console.ReadLine());
                if (opcion_entrenador > 0 && opcion_entrenador < 3) {
                    do
                    {
                        Console.WriteLine("Elegir a que pokemon queres aplicarle un efecto");
                        for (i = 1; i <= 6; i++)
                        {
                            Console.WriteLine(i + " " + entrenadores[opcion_entrenador - 1].equipo[i - 1].nombre);
                        }
                        opcion_pokemon = Convert.ToInt32(Console.ReadLine());
                        if (opcion_pokemon > 0 && opcion_pokemon < 7)
                        {
                            do {
                                Console.WriteLine("Elegir efecto");
                                for (x = 1; x <= 5; x++)
                                {
                                    Console.WriteLine(x + " " + efectos[x-1]);
                                }
                                opcion_efecto = Convert.ToInt32(Console.ReadLine());
                                if (opcion_efecto > 0 && opcion_efecto < 6) {
                                    string estadoviejo = entrenadores[opcion_entrenador - 1].equipo[opcion_pokemon - 1].estado;
                                    entrenadores[opcion_entrenador - 1].equipo[opcion_pokemon - 1].estado = efectos[opcion_efecto - 1];
                                    entrenadores[opcion_entrenador - 1].equipo[opcion_pokemon - 1].mostrar_cambio_alteracion(estadoviejo);
                                }
                                else {
                                    Console.WriteLine("Numero no posible, vuelva a ");
                                }
                            } while (!(opcion_efecto > 0 && opcion_efecto < 6));
                        }
                        else
                        {
                            Console.WriteLine("Numero no posible, vuelva a");
                        }

                    } while (!(opcion_pokemon > 0 && opcion_pokemon < 7));
                }
                else {
                    Console.WriteLine("Numero no posible, vuelva a");
                }
            } while (!(opcion_entrenador > 0 && opcion_entrenador < 3));

        }

        public static Entrenador cualControlaMas(Entrenador ash, Entrenador pepe) {
            
            if (ash.cuantosPuedoControlar() < pepe.cuantosPuedoControlar()) {
                return pepe;
            }
            else if (ash.cuantosPuedoControlar() > pepe.cuantosPuedoControlar()) {
                return ash;
            }
            else {
                Console.WriteLine("Son iguales");
                return ash;
            }
            
        }

        public static Entrenador cualEsMasPeligroso(Entrenador ash, Entrenador pepe) {

            if (ash.cantidadPeligrosidadAlta() > pepe.cantidadPeligrosidadAlta()) {
                return ash;
            } else if(ash.cantidadPeligrosidadAlta() < pepe.cantidadPeligrosidadAlta()){
                return pepe;
            }
            else {
                Console.WriteLine("Son iguales");
                return ash;
            }
                return ash;
        }

        public static Entrenador primero(Entrenador ash, Entrenador pepe) {
            //devuelve el entrenador que empezaria en una pelea hipotetica entre ambos, si empatan en velocidad devuelve al primero de los dos
            if (ash.equipo[0].velocidad < pepe.equipo[0].velocidad) {
                return pepe;
            }
            else {
                return ash;
            }
        }

        public static Entrenador segundo(Entrenador ash, Entrenador pepe)
        {
            //devuelve el entrenador que empezaria en una pelea hipotetica entre ambos, si empatan en velocidad devuelve al primero de los dos
            if (ash.equipo[0].velocidad > pepe.equipo[0].velocidad)
            {
                return pepe;
            }
            else
            {
                return ash;
            }
        }
        
        //Para simplificar y que la batalla funcione correctamente, debe de recibir a los entrenadores en el orden en el que van a tener sus turnos
        public static Entrenador batalla(Entrenador primero, Entrenador segundo) {
            int primeroPokemonEnCampo = 0;
            int segundoPokemonEnCampo = 0;
            int eleccion;
            do {
                // Turno del primero
                Console.WriteLine(" ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.Write(primero.nombre + " ");
                Console.Write(primero.equipo[primeroPokemonEnCampo].nombre + " ");
                Console.Write(primero.equipo[primeroPokemonEnCampo].psa + " ");
                Console.Write(" --------------- ");
                Console.Write(segundo.nombre + " ");
                Console.Write(segundo.equipo[segundoPokemonEnCampo].nombre + " ");
                Console.WriteLine(segundo.equipo[segundoPokemonEnCampo].psa + " ");
                Console.WriteLine(" ");
                do
                {
                    Console.WriteLine(primero.nombre + " que desea hacer?");
                    Console.Write("1) Ataque -----");
                    Console.WriteLine(" 2) AtaqueEspecial");
                    eleccion = Convert.ToInt32(Console.ReadLine());
                    if (eleccion > 0 && eleccion < 3) {
                        if (eleccion == 1)
                        {
                            segundo.equipo[segundoPokemonEnCampo].recibirDaño(primero.equipo[primeroPokemonEnCampo].ataque, false);
                        }
                        else {
                            segundo.equipo[segundoPokemonEnCampo].recibirDaño(primero.equipo[primeroPokemonEnCampo].ae, true);
                        }
                    }
                    else {
                        Console.WriteLine("Opcion no valida.");
                    }
                } while (!(eleccion > 0 && eleccion < 3));

                // Validacion de si tenemos otro turno sino cortamos el loop
                if (segundo.perdio())
                {
                    break;
                }
                // Chequeamos si tenemos que cambiar de pokemon y lo cambiamos
                if (segundo.equipo[segundoPokemonEnCampo].psa <= 0) {
                    Console.WriteLine(" ");
                    Console.WriteLine(segundo.equipo[segundoPokemonEnCampo].nombre + " se ha debilitado");
                    segundoPokemonEnCampo++;
                }

                // Turno del segundo
                Console.WriteLine(" ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.Write(primero.nombre + " ");
                Console.Write(primero.equipo[primeroPokemonEnCampo].nombre + " ");
                Console.Write(primero.equipo[primeroPokemonEnCampo].psa + " ");
                Console.Write(" --------------- ");
                Console.Write(segundo.nombre + " ");
                Console.Write(segundo.equipo[segundoPokemonEnCampo].nombre + " ");
                Console.WriteLine(segundo.equipo[segundoPokemonEnCampo].psa + " ");
                Console.WriteLine(" ");
                do
                {
                    Console.WriteLine(segundo.nombre + " que desea hacer?");
                    Console.Write("1) Ataque ------");
                    Console.WriteLine(" 2) AtaqueEspecial");
                    eleccion = Convert.ToInt32(Console.ReadLine());
                    if (eleccion > 0 && eleccion < 3)
                    {
                        if (eleccion == 1)
                        {
                            primero.equipo[primeroPokemonEnCampo].recibirDaño(segundo.equipo[segundoPokemonEnCampo].ataque, false);
                        }
                        else
                        {
                            primero.equipo[primeroPokemonEnCampo].recibirDaño(segundo.equipo[segundoPokemonEnCampo].ae, true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opcion no valida.");
                    }
                } while (!(eleccion > 0 && eleccion < 3));

                // Validacion de si tenemos otro turno sino cortamos el loop
                if (primero.perdio())
                {
                    break;
                }
                // Chequeamos si tenemos que cambiar de pokemon y lo cambiamos
                if (primero.equipo[primeroPokemonEnCampo].psa <= 0)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(primero.equipo[primeroPokemonEnCampo].nombre + " se ha debilitado");
                    primeroPokemonEnCampo++;
                }

                } while (true);

                if (primero.perdio())
                {
                    return segundo;
                }
                else {
                    return primero;
                }

        }
        //--------------------------------------------------------------------------------------------------//
        static void Main(string[] args)
        {

            // creo una lista de pokemons
            Pokemon[] equipo1 = new Pokemon[]
            {
                new Pokemon("Pikachu", 50, 150, 150, 90, 55, 110, 50, 90, "Paralizado"),
                new Pokemon("Charizard", 55, 180,180, 84, 78, 109, 85, 100, "Normal"),
                new Pokemon("Blastoise", 81, 175,175, 83, 100, 85, 105, 78, "Normal"),
                new Pokemon("Venusaur", 51, 170,170, 82, 83, 100, 100, 80, "Normal"),
                new Pokemon("Snorlax", 48, 160,160, 110, 65, 55, 55, 45, "Normal"),
                new Pokemon("Gengar", 50, 130,130, 65, 60, 130, 110, 110, "Normal")
            };

            // creo otra lista de pokemons
            Pokemon[] equipo2 = new Pokemon[]
             {
                new Pokemon("Dragonite", 52, 160,160, 134, 95, 70, 100, 80, "Normal"),
                new Pokemon("Alakazam", 50, 140,140, 50, 70, 135, 115, 120, "Normal"),
                new Pokemon("Gyarados", 49, 200,200, 130, 60, 95, 85, 65, "Normal"),
                new Pokemon("Rhydon", 53, 155,155, 110, 96, 83, 85, 45, "Normal"),
                new Pokemon("Jolteon", 50, 135,135, 110, 100, 50, 70, 130, "Normal"),
                new Pokemon("Starmie", 51, 145,145, 105, 75, 100, 90, 115, "Normal")
             };

            string[] medallas = new string[5]
            {
                "Medalla Roca",
                "Medalla Cascada",
                "Medalla Trueno",
                "Medalla Arcoíris",
                "Medalla Alma",
            };

            Entrenador entrenador1 = new Entrenador("Ash", 500, medallas, equipo1);
            Entrenador entrenador2 = new Entrenador("Pepe", 100, medallas, equipo2);

                //comparar_nivel(entrenador1,entrenador2);
                //aplicar_efecto_alterado(entrenador1, entrenador2);
                //Console.WriteLine(cualControlaMas(entrenador1, entrenador2).nombre);
                //Console.WriteLine(cualEsMasPeligroso(entrenador1, entrenador2).nombre);

                Console.WriteLine(batalla(primero(entrenador1,entrenador2), segundo(entrenador1,entrenador2)).nombre + " Gano!!!");


        }
    }
}
