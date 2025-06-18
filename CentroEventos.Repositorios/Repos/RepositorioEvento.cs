namespace CentroEventos.Repositorios.repos;

using System.Collections.Generic;
using System.Data;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;
using System.Linq;

public class RepositorioEvento(DataContext db) : IEventoDeportivoRepositorio
{
    public void Agregar(EventoDeportivo evento)
    {
        db.EventosDeportivos.Add(evento);
        db.SaveChanges();
    }

    public EventoDeportivo? BuscarPorId(int id)
    {
        return db.EventosDeportivos.FirstOrDefault(e => e.Id == id);
    }

    public int CupoMaximo(int id)
    {
        return db.EventosDeportivos.FirstOrDefault(e => e.Id == id)!.CupoMaximo;
    }

    public void Eliminar(int id)
    {
        EventoDeportivo? evento = BuscarPorId(id);
        db.EventosDeportivos.Remove(evento!);
        db.SaveChanges();
    }

    public bool ExistsById(int id)
    {
        return db.EventosDeportivos.Any(e => e.Id == id);
    }

    public List<EventoDeportivo> Listar()
    {
        return db.EventosDeportivos.ToList();
    }

    public void Modificar(EventoDeportivo evento)
    {
        db.EventosDeportivos.Update(evento);
        db.SaveChanges();
    }

    public List<EventoDeportivo> ListarFechaFutura()
    {
        return db.EventosDeportivos.Where(e => e.FechaHoraInicio > DateTime.Now).ToList();
    }

    public bool ExistsByIdResponsable(int idPersona)
    {
        return db.EventosDeportivos.Any(e => e.ResponsableId == idPersona);
    }
    
    public bool ExistsByIdResponsableEnEvento(int idPersona, int id)
    {
        return db.EventosDeportivos.Any(e => e.Id == id && e.ResponsableId == idPersona);
    }
}
