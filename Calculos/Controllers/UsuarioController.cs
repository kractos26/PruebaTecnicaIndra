using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dto;
using Newtonsoft.Json;
using neg = Negocio;
namespace Calculos.Controllers
{
    public class UsuarioController : Controller
    {
        private neg.BLUsuario bLUsuario = new neg.BLUsuario();
        // GET: Usuario
       

        public JsonResult Buscar(Dto.DtoUsuario dtoUsuario)
        {
            DtoUsuario usuario =  this.bLUsuario.ConsultarUnUsuario(dtoUsuario);
            string jsonResponse = JsonConvert.SerializeObject(usuario);

            return this.Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }
    }
}