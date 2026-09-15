namespace MiArbolito2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arbol arbolitox = new Arbol();

            arbolitox.insertar(50);
            arbolitox.insertar(20);
            arbolitox.insertar(30);
            arbolitox.insertar(70);
            arbolitox.insertar(10);
            arbolitox.insertar(80);

            Console.WriteLine("Busqueda valor");
            Console.WriteLine(arbolitox.buscar(15));

        }
    }
}
