namespace Simulacro_Matrices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rendimientoE1, rendimientoE2;
            String[,] equipo1 = new string[23, 3];
            String[,] equipo2 = new string[23, 3];
            equipo1 = llenar(equipo1);
            equipo2 = llenar(equipo2);
            Console.WriteLine("Equipo1");
            mostrar(equipo1);
            Console.WriteLine("Equipo2");
            mostrar(equipo2);
            rendimientoE1 = valorarequipo(equipo1);
            rendimientoE2 = valorarequipo(equipo2);
            if (rendimientoE1 > rendimientoE2)
            {
                Console.WriteLine("El equipo 1 es mejor que el equipo 2");
            }
            else if (rendimientoE1 < rendimientoE2)
            {
                Console.WriteLine("El equipo 2 es mejor que el equipo 1");
            }
            else
            {
                Console.WriteLine("Los equipos son iguales");
            }
           
            
            
            
            string[,] llenar(string[,] equipollenar)
            {
                String[] nombres = { "Juan", "María", "Pedro", "pepe1", "pepe2", "pepe3", "pepe4", "pepe5", "pepe6", "pepe7", "pepe8", "pepe9", "pepe10", "pepe11", "pepe12", "pepe13", "pepe14", "pepe15", "pepe16", "pepe17", "pepe18", "pepe19", "pepe20", "pepe21" };
                String[] posiciones = { "Portero", "Defensa", "Mediocampista", "Delantero" };
                Random aleatorio = new Random();
                for (int x = 0; x < equipollenar.GetLength(0); x++)
                {
                    equipollenar[x, 0] = nombres[aleatorio.Next(0, 24)];
                }

                for (int i = 0; i < equipollenar.GetLength(0); i++)
                {
                    equipollenar[i, 1] = posiciones[aleatorio.Next(0, 4)];
                }

                for (int j = 0; j < equipollenar.GetLength(0); j++)
                {
                    equipollenar[j, 2] = aleatorio.Next(50, 101).ToString();
                }

                return equipollenar;
            }
            void mostrar(string[,] equipo)
            {
                for (int x = 0; x < equipo.GetLength(0); x++)
                {
                    for (int y = 0; y < equipo.GetLength(1); y++)
                    {
                        Console.Write(equipo[x, y] + " ");
                    }
                    Console.WriteLine(" ");
                }
            }
            int valorarequipo(string[,] equipo) {
                int resultado = 0;
                for (int x = 0; x < equipo.GetLength(0); x++) { 
                    resultado = resultado + Convert.ToInt32(equipo[x, 2]);
                }
                    return resultado;
            }
        }
    }

}
