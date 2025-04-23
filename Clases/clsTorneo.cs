using Parcial_3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Parcial_3.Clases
{
    public class clsTorneo
    {
        private DBTorneoEntities dbTorneo = new DBTorneoEntities();
        public Torneo torneo { get; set; }

        public string Registrar()
        {
            string respuesta = "";
            try
            {
                dbTorneo.Torneos.Add(torneo);
                dbTorneo.SaveChanges();
                respuesta = "Torneo Registrado correctamente";
            }
            catch (Exception ex)
            {
                respuesta = "Error al registrar torneo: " + ex.Message;
            }
            return respuesta;
        }
        public List<Torneo> ConsultarTodos()
        {
            try
            {
                List<Torneo> computadores = dbTorneo.Torneos
                                                .OrderBy(t => t.idTorneos)
                                                .ToList();
                return computadores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Torneo> ConsultarXTipo(string tipoTorneo)
        {
            try
            {
                List<Torneo> computadores = dbTorneo.Torneos
                                                .Where(t => t.TipoTorneo == tipoTorneo)
                                                .OrderBy(t => t.idTorneos)
                                                .ToList();
                return computadores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Torneo> ConsultarXFecha(DateTime fechaTorneo)
        {
            try
            {
                List<Torneo> computadores = dbTorneo.Torneos
                                                .Where(t => t.FechaTorneo == fechaTorneo)
                                                .OrderBy(t => t.idTorneos)
                                                .ToList();
                return computadores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Torneo> ConsultarXNombre(string nombreTorneo)
        {
            try
            {
                List<Torneo> torn = dbTorneo.Torneos.Where(t => t.NombreTorneo == nombreTorneo).OrderBy(t => t.idTorneos).ToList();
                return torn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Torneo ConsultarXID(int idTorneo)
        {
            try
            {
                Torneo torn = dbTorneo.Torneos.FirstOrDefault(t => t.idTorneos == idTorneo);
                return torn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Actualizar()
        {
            string respuesta = "";
            try
            {
                Torneo torn = ConsultarXID(torneo.idTorneos);
                if (torn == null)
                {
                    respuesta = "Torneo no encontrado";
                }
                else
                {
                    dbTorneo.Torneos.AddOrUpdate(torneo);
                    dbTorneo.SaveChanges();
                    respuesta = "Torneo actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error al actualizar torneo: " + ex.Message;
            }
            return respuesta;
        }
        public string Eliminar()
        {
            string respuesta = "";
            try
            {
                Torneo torn = ConsultarXID(torneo.idTorneos);
                if (torn == null)
                {
                    respuesta = "Torneo no encontrado";
                }
                else
                {
                    dbTorneo.Torneos.Remove(torn);
                    dbTorneo.SaveChanges();
                    respuesta = "Torneo eliminado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error al eliminar torneo: " + ex.Message;
            }
            return respuesta;
        }
    }
}