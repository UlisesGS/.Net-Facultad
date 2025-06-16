using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion;

public class Hasheador
{
    public static string Hashear(string contrasenia)
    {
        using SHA256 hash = SHA256.Create();
        byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
