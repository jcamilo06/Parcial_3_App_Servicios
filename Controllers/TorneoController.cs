using Parcial_3.Clases;
using Parcial_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Parcial_3.Controllers
{
    [RoutePrefix("api/Torneo")]
    public class TorneoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]

        public List<Torneo> ConsultarTodos()
        {
            try
            {
                clsTorneo clsTorneo = new clsTorneo();
                return clsTorneo.ConsultarTodos();
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarXTipo")]
        public List<Torneo> ConsultarXTipo(string tipoTorneo)
        {
            try
            {
                clsTorneo clsTorneo = new clsTorneo();
                return clsTorneo.ConsultarXTipo(tipoTorneo);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarXFecha")]

        public List<Torneo> ConsultarXFecha(DateTime fechaTorneo)
        {
            try
            {
                clsTorneo clsTorneo = new clsTorneo();
                return clsTorneo.ConsultarXFecha(fechaTorneo);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarXNombreTorneo")]
        public List<Torneo> ConsultarXNombreTorneo(string nombreTorneo)
        {
            try
            {
                clsTorneo clsTorneo = new clsTorneo();
                return clsTorneo.ConsultarXNombre(nombreTorneo);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("Registrar")]
        public string Registrar([FromBody] Torneo torneo)
        {
            try
            {
                clsTorneo clsTorneo = new clsTorneo();
                clsTorneo.torneo = torneo;
                return clsTorneo.Registrar();
            }
            catch (Exception ex)
            {
                return "Error al registrar torneo: " + ex.Message;
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Torneo torneo)
        {
            try
            {
                clsTorneo clsTorneo = new clsTorneo();
                clsTorneo.torneo = torneo;
                return clsTorneo.Actualizar();
            }
            catch (Exception ex)
            {
                return "Error al actualizar torneo: " + ex.Message;
            }
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Torneo torneo)
        {
            try
            {
                clsTorneo clsTorneo = new clsTorneo();
                clsTorneo.torneo = torneo;
                return clsTorneo.Eliminar();
            }
            catch (Exception ex)
            {
                return "Error al eliminar torneo: " + ex.Message;
            }

        }
    }
}