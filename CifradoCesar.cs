using System.IO.Pipelines;
using System.Reflection;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string ABC = "abcdefghijklmnopqrstuvwxyz";
            string permitidos = "abcdefghijklmnopqrstuvwxyz ";

            string procesarTexto()
             {
                    
                    string mensaje = "";
                    bool esValido = false;

                    while (!esValido)
                    {
                        Console.WriteLine("pone un mensaje:");
                        mensaje = Console.ReadLine();
                        mensaje = mensaje.ToLower();


                        bool contieneError = false;


                        for (int i = 0; i < mensaje.Length; i++)
                        {
                            char caracterUsuario = mensaje[i];
                            bool encontrado = false;


                            for (int j = 0; j < permitidos.Length; j++)
                            {
                                if (caracterUsuario == permitidos[j])
                                {
                                    encontrado = true;
                                    break;
                                }
                            }

                            if (!encontrado)
                            {
                                contieneError = true;
                                break;
                            }

                        }

                    if (contieneError)
                    {
                        Console.WriteLine("El mensaje contiene caracteres no permitidos.");
                    }
                    else
                    {
                        esValido = true;
                    }
                }

                return mensaje;
             }

            string cifrar(string texto, int clave) {
                string textocifrado = "";
                int aux;
                int movimiento;

                for (int x = 0; x < texto.Length; x++)
                {

                    for (int i = 0; i < ABC.Length; i++) {

                        if (texto[x] == ' ')
                        {
                            textocifrado += " ";
                            break;
                        }

                        if (ABC[i] == texto[x]) {
                            if (i + clave > 26)
                            {
                                aux = 0;
                                movimiento = aux + (clave - 1);
                                textocifrado += ABC[aux + movimiento];
                            }
                            else {
                                movimiento = clave;
                                textocifrado += ABC[i + movimiento];
                            }
                        }

                    }
                
                }

                return textocifrado;
            }


            Console.WriteLine(cifrar(procesarTexto(),3));
            
            
        
        }
    }
}
