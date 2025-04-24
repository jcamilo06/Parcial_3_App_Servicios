using Microsoft.Ajax.Utilities;
using Parcial_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_3.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        private DBTorneoEntities dbTorneo = new DBTorneoEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        public bool ValidarUsuario()
        {
            try
            {
                AdministradorITM admin = dbTorneo.AdministradorITMs.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (admin == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                AdministradorITM admin = dbTorneo.AdministradorITMs.FirstOrDefault(u => u.Usuario == login.Usuario && u.Clave == login.Clave);
                if (admin == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            // if (login.Usuario == "admin")
            if (ValidarUsuario() && ValidarClave())
            {
                //Se genera el token
                string Token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from A in dbTorneo.Set<AdministradorITM>()
                       where A.Usuario == login.Usuario &&
                               A.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = A.Usuario,
                           Autenticado = true,
                           Perfil = A.NombreCompleto,
                           PaginaInicio = "",
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> listRpta = new List<LoginRespuesta>();
                listRpta.Add(loginRespuesta);
                return listRpta.AsQueryable();
            }
        }
    }
}