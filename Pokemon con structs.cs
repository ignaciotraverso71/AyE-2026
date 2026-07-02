namespace ConsoleApp5
{
    internal class Program
    {
        
        // hp,nombre,tipo,nivel,movimientos[],estadisticas[],estado

        // estadisticas estructura
        // 0 - Ataque, 1 - AtaqueEspecial, 2 - Defensa, 3- DefensaEspecial 4 - Velocidad 

        // movimientos estructura
        // 0 - Placaje, 1 - AtaqueRapido, 2 - Gruñir, 3 - Especial  
        public struct Pokemon {

            // Propiedades
            public string nombre { get; set; }
            public int hp { get; set; }
            public string estado { get; set; }
            public string tipo { get; set; }
            public int nivel { get; set; }
            public string[] movimientos  { get; set; }
            public int[] estadisticas { get; set; }
            


            // Constructor
            public Pokemon(int hp, string nombre, string tipo, int nivel, string[] movimientos, int[] estadisticas, string estado)
            {
                this.hp = hp;
                this.estado = estado;
                this.nombre = nombre;
                this.tipo = tipo;
                this.nivel = nivel;
                this.movimientos = movimientos;
                this.estadisticas = estadisticas;
            }

            // Metodos

            public void MostrarInformacion()
            {
                Console.WriteLine($"Nombre: {nombre}");
                Console.WriteLine($"Tipo: {tipo}");
                Console.WriteLine($"Nivel: {nivel}");
                Console.WriteLine("Movimientos: " + string.Join(", ", movimientos));
                Console.WriteLine("Estadísticas: " + string.Join(", ", estadisticas));
            }

            public void SubirNivel()
            {
                nivel++;
                Console.WriteLine($"{nombre} ha subido al nivel {nivel}!");
            }

            public void HacerMovimiento(string movimientoUsado) {
            
            }


            public void RecibirDaño(int daño, string tipo) {
                int dañototal = daño - (estadisticas[2] / 2);
                if (tipo != "Normal")
                {
                    hp = hp - (dañototal * 2);
                }
                else {
                    hp = hp - dañototal;
                }
            }

        }
        static void Main(string[] args)
        {
            String[] movimientos = { "Placaje", "AtaqueRapido", "Gruñir", "Especial" };
            String[] pokedex = { "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch'd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew" };
            String[] tipos = { "Grass", "Grass", "Grass", "Fire", "Fire", "Fire", "Water", "Water", "Water", "Bug", "Bug", "Bug", "Bug", "Bug", "Bug", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Poison", "Poison", "Electric", "Electric", "Ground", "Ground", "Poison", "Poison", "Poison", "Poison", "Poison", "Poison", "Fairy", "Fairy", "Fire", "Fire", "Normal", "Normal", "Poison", "Poison", "Grass", "Grass", "Grass", "Bug", "Bug", "Bug", "Bug", "Ground", "Ground", "Normal", "Normal", "Water", "Water", "Fighting", "Fighting", "Fire", "Fire", "Water", "Water", "Water", "Psychic", "Psychic", "Psychic", "Fighting", "Fighting", "Fighting", "Grass", "Grass", "Grass", "Water", "Water", "Rock", "Rock", "Rock", "Fire", "Fire", "Water", "Water", "Electric", "Electric", "Normal", "Normal", "Normal", "Water", "Water", "Poison", "Poison", "Water", "Water", "Ghost", "Ghost", "Ghost", "Rock", "Psychic", "Psychic", "Water", "Water", "Electric", "Electric", "Grass", "Grass", "Ground", "Ground", "Fighting", "Fighting", "Normal", "Poison", "Poison", "Ground", "Ground", "Normal", "Grass", "Normal", "Water", "Water", "Water", "Water", "Water", "Water", "Psychic", "Bug", "Ice", "Electric", "Fire", "Bug", "Normal", "Water", "Water", "Water", "Normal", "Normal", "Water", "Electric", "Fire", "Normal", "Rock", "Rock", "Rock", "Rock", "Rock", "Normal", "Ice", "Electric", "Fire", "Dragon", "Dragon", "Dragon", "Psychic", "Psychic" };
            int aleatoriopokemon;
            Random aleatorio = new Random();
            string pokemonNombre;
            string pokemonTipo;
            string pokemonqueataca;
            int eleccion;
            int estadisticaUsar;
            string tipo;
            // false = pokemon1, true = pokemon2
            bool ultimo;
            // false = pokemon1, true = pokemon2
            bool atacanteactual;
           //------------------------------------------------------------//
            
            
            int[] estadisticas = { 30, 24, 20, 50, 60 };
            aleatoriopokemon = aleatorio.Next(0, 152);
            pokemonNombre = pokedex[aleatoriopokemon];
            pokemonTipo = pokedex[aleatoriopokemon];
            Pokemon pokemon1 = new Pokemon(20,pokemonNombre,pokemonTipo,50, movimientos, estadisticas, "normal");


            int [] estadisticas2 = { 25, 35, 40, 70, 80 };
            aleatoriopokemon = aleatorio.Next(0, 152);
            pokemonNombre = pokedex[aleatoriopokemon];
            pokemonTipo = pokedex[aleatoriopokemon];
            Pokemon pokemon2 = new Pokemon(20, pokemonNombre, pokemonTipo, 47, movimientos, estadisticas2, "normal");

            // determina primer atacante

            ultimo = determinarprimerturno();
            do
            {
                Console.WriteLine(pokemon1.estadisticas[4] + " " + pokemon2.estadisticas[4]);
                Console.WriteLine("Vida : " + pokemon1.nombre + " " + pokemon1.hp + " Vida: " + pokemon2.nombre + " " + pokemon2.hp);

                if (!ultimo)
                {
                    atacanteactual = true;
                    pokemonqueataca = "Pokemon2";
                }
                else
                {
                    atacanteactual = false;
                    pokemonqueataca = "Pokemon1";
                }

                Console.Write("Turno del " + pokemonqueataca);
                Console.WriteLine(" Que desea hacer?");
                Console.WriteLine("1- Placaje 2- AtaqueRapido 3- Gruñir 4- Especial");
                // estadisticas estructura
                // 0 - Ataque, 1 - AtaqueEspecial, 2 - Defensa, 3- DefensaEspecial 4 - Velocidad 
                eleccion = Convert.ToInt32(Console.ReadLine());
                if (!atacanteactual)
                {
                    switch (eleccion)
                    {
                        case 1:
                            estadisticaUsar = 0;
                            tipo = "Normal";
                            break;
                        case 2:
                            estadisticaUsar = 0;
                            tipo = "Normal";
                            break;
                        case 3:
                            estadisticaUsar = 0;
                            tipo = "Normal";
                            break;
                        case 4:
                            estadisticaUsar = 1;
                            tipo = pokemon1.tipo;
                            break;
                        default:
                            estadisticaUsar = 0;
                            tipo = "Normal";
                            break;

                    }
                    pokemon2.RecibirDaño(pokemon1.estadisticas[estadisticaUsar], tipo);
                    ultimo = false;
                }
                else
                {
                    switch (eleccion)
                    {
                        case 1:
                            estadisticaUsar = 0;
                            tipo = "Normal";
                            break;
                        case 2:
                            estadisticaUsar = 0;
                            tipo = "Normal";
                            break;
                        case 3:
                            estadisticaUsar = 0;
                            tipo = "Normal";
                            break;
                        case 4:
                            estadisticaUsar = 1;
                            tipo = pokemon2.tipo;
                            break;
                        default:
                            estadisticaUsar = 0;
                            tipo = "Normal";
                            break;

                    }
                    pokemon1.RecibirDaño(pokemon2.estadisticas[estadisticaUsar], tipo);
                    ultimo = true;
                }
            } while (pokemon1.hp > 0 && pokemon2.hp > 0);


            if (pokemon1.hp < 0)
            {
                Console.WriteLine("Ganador: " + pokemon2.nombre);
            }
            else {
                Console.WriteLine("Ganador: " + pokemon1.nombre);
            }
                // determina primer atacante
                bool determinarprimerturno()
                {
                    bool primero;
                    if (pokemon1.estadisticas[4] > pokemon2.estadisticas[4])
                    {
                        primero = true;
                    }
                    else
                    {
                        primero = false;
                    }
                    return primero;
                } 
        }




        }
    }

