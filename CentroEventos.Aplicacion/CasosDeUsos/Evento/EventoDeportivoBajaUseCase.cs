﻿using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUsos.Evento
{
    public class EventoDeportivoBajaUseCase(IEventoDeportivoRepositorio repoEvento, IServicioAutorizacion servicioAutorizacion, IReservaRepositorio repoReserva){
            private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;

            private readonly IReservaRepositorio _repositorioReserva = repoReserva;

            public void Ejecutar(int idEvento, int idUsuario){

                if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.EventoBaja))
                {
                    throw new FalloAutorizacionException("ERROR - No estas autorizado.");
                }
                
                if (!_repositorioEvento.ExistsById(idEvento))
                {
                    throw new ValidacionException("ERROR - Este evento no existe");
                }

                if (_repositorioReserva.ExistsByIdEvento(idEvento))
                {
                    throw new OperacionInvalidaException("ERROR - Este evento esta vinculado a una reserva.");
                }

                    _repositorioEvento.Eliminar(idEvento);
            }
    }
}
