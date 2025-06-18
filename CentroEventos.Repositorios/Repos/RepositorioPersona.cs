/* namespace CentroEventos.Repositorios.repos;

using System.Collections.Generic;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;
public class RepositorioPersona(DataContext db) : IPersonaRepositorio
{
    public void Agregar(Persona persona)
    {
        db.Personas.Add(persona);
        db.SaveChanges();
    }

    public Persona? BuscarPorId(int id)
    {
        return db.Personas.FirstOrDefault(p => p.Id == id);
    }

    public void Eliminar(int id)
    {
        Usuario us = BuscarPorId(id);
        db.Personas.Remove
    }

    public bool ExistsByDNI(int dni)
    {
        return db.Personas.FirstOrDefault(p => p.DNI == dni) != null;
    }

    public bool ExistsByEmail(string email)
    {
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            if (p.Email == email)
                return true;
        }
        return false;
    }

    public bool ExistsById(int id)
    {
        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            if (p.Id == id)
                return true;
        }
        return false;
    }

    public List<Persona> Listar()
    {
        List<Persona> listaPersona = [];

        using var leer = new StreamReader(archivoDatos);
        string? linea;
        while ((linea = leer.ReadLine()) != null)
        {
            Persona p = RestaurarDesdeTexto(linea);
            listaPersona.Add(p);
        }

        return listaPersona;
    }

    public void Modificar(Persona persona)
    {
        List<string> nuevasLineas = [];

        using (var reader = new StreamReader(archivoDatos))
        {
            string? linea;
            while ((linea = reader.ReadLine()) != null)
            {
                var p = RestaurarDesdeTexto(linea);
                nuevasLineas.Add(p.Id == persona.Id ? GuardarComoCadena(persona) : linea);
            }
        }

        using var writer = new StreamWriter(archivoDatos, false);
        foreach (string l in nuevasLineas)
        {
            writer.WriteLine(l);
        }
    }
}
 */