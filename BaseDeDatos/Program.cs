using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba_Base_de_Datos;
namespace Prueba_Base_de_Datos
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var db = new AppDbContext();
            //Insertar

            var nuevo = new datos
            {
                apellido = "Traverso",
                dni = "857436321",
                nombre = "Roberto",
                tucu = 5
            };

            db.Datos.Add(nuevo);


            //Consultar
            var todos = await db.Datos.ToListAsync();
            foreach(var e in todos){
                Console.WriteLine(e.nombre);
            }
            //ejecutar una linea de SQL
            string sql = "SELECT id,apellido,dni,nombre,tucu from datos";
            var lista = await db.Datos.FromSqlRaw(sql).ToListAsync();

            //buscar un usuario en especifico
            int id = 1;
            var datoBuscado = await db.Datos.FindAsync(id);
            //Update
            if(datoBuscado != null) {
                datoBuscado.nombre = "robertovich";

                await db.SaveChangesAsync();
            }

            if (datoBuscado != null)
            {
                db.Datos.Remove(datoBuscado);
                await db.SaveChangesAsync();
            }


        }
    }
}
