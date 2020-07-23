using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dto;

namespace Negocio.Tests
{
    [TestClass()]
    public class BLCalculoTests
    {
        BLCalculo blcalulo = new BLCalculo();
        [TestMethod()]
        public void ConsultarCalculoTest()
        {
            try
            {
                Assert.IsTrue(this.blcalulo.ConsultarCalculo(new DtoCalculo()).Count > 0);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void CrearCalculoCorrectoTest()
        {

            try
            {
                DtoCalculo respuesta = this.blcalulo.CrearCalculo(new DtoCalculo() { Limite = 500, Usuario = new DtoUsuario() { Nombre = "pedro" } });
                Assert.IsTrue(respuesta.IdCalculo > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void CrearCalculoIncorrectoTest()
        {

            try
            {
                DtoCalculo respuesta = this.blcalulo.CrearCalculo(new DtoCalculo() { Limite = 500, Usuario = new DtoUsuario() { Nombre = "jasinto" } });
                Assert.IsFalse(respuesta.IdCalculo == 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}