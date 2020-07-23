using Calculos.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using neg = Negocio;

namespace Calculos.Controllers
{
    public class CalculoController : Controller
    {
        neg.BLCalculo blCalculo = new neg.BLCalculo();

        // GET: Calculo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View(new Dto.DtoCalculo());
        }

        [HttpPost]
        public ActionResult Crear(Dto.DtoCalculo dtoCalculo)
        {
            try
            {
                Dto.DtoCalculo dtocalculo = this.blCalculo.CrearCalculo(dtoCalculo);

                return View(dtocalculo);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
               
            }
        }


        [HttpGet]
        public ActionResult Consultar()
        {
            CalculoModelo calculoModelo = new CalculoModelo();
            calculoModelo.dtoCalculos = this.blCalculo.ConsultarCalculo(new Dto.DtoCalculo());
            return View(calculoModelo);
        }

        [HttpPost]
        public ActionResult Consultar(CalculoModelo consultar)
        {
            consultar.dtoCalculos = this.blCalculo.ConsultarCalculo(consultar.DtoCalculo);
            return View(consultar);
        }

        [HttpPost]

        public JsonResult Eliminar(int idCalculo)
        {
            try
            {
                bool respuesta = blCalculo.Eliminar(new Dto.DtoCalculo() { IdCalculo = idCalculo });
                string jsonResponse = JsonConvert.SerializeObject(respuesta);

                return this.Json(respuesta, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return this.Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }

}