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
        Persona? persona = BuscarPorId(id);
        db.Personas.Remove(persona!);
        db.SaveChanges();
    }

    public bool ExistsByDNI(int dni)
    {
        return db.Personas.FirstOrDefault(p => p.DNI == dni) != null;
    }

    public bool ExistsByEmail(string email)
    {
        return db.Personas.FirstOrDefault(p => p.Email == email) != null;
    }

    public bool ExistsById(int id)
    {
        return db.Personas.FirstOrDefault(p => p.Id == id) != null;
    }

    public List<Persona> Listar()
    {
        return db.Personas.ToList();
    }

    public void Modificar(Persona persona)
    {
        var original = db.Personas.Find(persona.Id);

        if (original != null)
        {
            original.Nombre = persona.Nombre;
            original.Apellido = persona.Apellido;
            original.Email = persona.Email;
            original.DNI = persona.DNI;
            original.Telefono = persona.Telefono;

            db.SaveChanges();
        }
    }
}
 