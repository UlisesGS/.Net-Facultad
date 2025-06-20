﻿using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IPersonaRepositorio
    {
        public Boolean ExistsById(int id);

        public Boolean ExistsByDNI(int dni); 

        public Boolean ExistsByEmail(string email);

        public void Agregar(Persona persona);

        public void Eliminar(int id);

        public List<Persona> Listar();

        public void Modificar(Persona persona);

        public Persona? BuscarPorId(int id);
    }
}
