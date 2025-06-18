using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios.Data;

public class DbSqlite
{
    public static void Inicializar(DataContext context)
    {
        if (context.Database.EnsureCreated())
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Base de datos creada y modo journal configurado.");
        }
    }
}