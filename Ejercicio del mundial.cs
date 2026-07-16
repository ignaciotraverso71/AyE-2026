namespace Mundial
{
    internal class Program
    {
        public struct Jugador {
            //Parametros
            public string nombre { get; set; }
            public string apellido { get; set; }
            public double cantGoles { get; set; }
            public double cantDisparos { get; set; }
            public double cantAsistencias { get; set; }
            public int casaca { get; set; }
            public string posicion { get; set; }
            public string equipo { get; set; }

            //Constructor
            public Jugador(string nombre, string apellido, double cantGoles, double cantDisparos, double cantAsistencias, int casaca, string posicion, string equipo) 
            { 
                this.nombre = nombre;
                this.cantAsistencias = cantAsistencias;
                this.apellido = apellido;
                this.cantGoles = cantGoles;
                this.cantDisparos = cantDisparos;
                this.casaca = casaca; 
                this.posicion = posicion;
                this.equipo = equipo;
            }

            //Funciones
            public double indiceAtaque() {
                double indice;
                indice = (this.cantGoles / this.cantDisparos) * 100;
                return indice;
            }

            public int G_A()
            {
                int G_A ;
                G_A = Convert.ToInt32(this.cantGoles) + Convert.ToInt32(this.cantAsistencias);
                return G_A;
            }

        }




        static void Main(string[] args)
        {
            Jugador[] maximosGoleadores = new Jugador[]
             {
                 new Jugador("Lionel", "Messi", 8, 16, 4 , 10, "Delantero", "Argentina"),
                 new Jugador("Kylian", "Mbappé", 8, 17, 20, 10, "Delantero", "Francia"),
                 new Jugador("Erling", "Haaland", 7, 14, 3, 9, "Delantero", "Noruega"),
                 new Jugador("Harry", "Kane", 6, 11, 9, 5, "Delantero", "Inglaterra"),
                 new Jugador("Jude", "Bellingham", 6, 10, 4, 10, "Mediocampista", "Inglaterra"),
                 new Jugador("Ousmane", "Dembélé", 5, 8, 3, 11, "Delantero", "Francia"),
                 new Jugador("Mikel", "Oyarzabal", 5, 12,2, 21, "Delantero", "España"),
                 new Jugador("Julián", "Quiñones", 4, 7, 1, 33, "Delantero", "México"),
                 new Jugador("Vinícius", "Júnior", 4, 11, 2, 7, "Delantero", "Brasil"),
                 new Jugador("Ismaïla", "Sarr", 4, 6, 3, 18, "Delantero", "Senegal")

             };

            Jugador MayorIndice = JugadorMayorIndiceAtaque(maximosGoleadores);

            Console.WriteLine(MayorIndice.nombre + " " + MayorIndice.apellido + " " + MayorIndice.equipo + " " + MayorIndice.indiceAtaque());

            Jugador MayorGoles = JugadorMayorCantidadGoles(maximosGoleadores);

            Console.WriteLine(MayorGoles.nombre + " " + MayorGoles.apellido + " " + MayorGoles.equipo + " " + MayorGoles.indiceAtaque());

            Jugador MayorG_A = JugadorMayorG_A(maximosGoleadores);

            Console.WriteLine(MayorG_A.nombre + " " + MayorG_A.apellido + " " + MayorG_A.equipo + " " + MayorG_A.indiceAtaque());


        }




        public static Jugador JugadorMayorIndiceAtaque(Jugador[] jugadores) {
            Jugador JugadorMayorindice = new Jugador();
            JugadorMayorindice = jugadores[0];
            Jugador JugadorActual = new Jugador();
            for (int i = 1; i < jugadores.Length; i++) {
                JugadorActual = jugadores[i];
                if (JugadorActual.indiceAtaque() > JugadorMayorindice.indiceAtaque()) {
                    JugadorMayorindice = JugadorActual;
                }
            }
            return JugadorMayorindice;
        }

        public static Jugador JugadorMayorCantidadGoles(Jugador[] jugadores) { 
            Jugador mayor = new Jugador();
            mayor = jugadores[0];
            Jugador JugadorActual = new Jugador();
            for (int i = 1; i < jugadores.Length; i++)
            {
                JugadorActual = jugadores[i];
                if (JugadorActual.cantGoles > mayor.cantGoles)
                {
                    mayor = JugadorActual;
                }
            }
            return mayor;

        }

        public static Jugador JugadorMayorG_A(Jugador[] jugadores)
        {
            Jugador mayor = new Jugador();
            mayor = jugadores[0];
            Jugador JugadorActual = new Jugador();
            for (int i = 1; i < jugadores.Length; i++)
            {
                JugadorActual = jugadores[i];
                if (JugadorActual.G_A() > mayor.G_A())
                {
                    mayor = JugadorActual;
                }
            }
            return mayor;

        }
    }
}
