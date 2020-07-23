using Dto;
using Mapeo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using ent = DataEntity;
using per = Data;
namespace Negocio
{
    public class BLCalculo
    {
        private readonly Mapas mapas = new Mapas();
        private readonly per.DTCalculo dTCalculo = new per.DTCalculo();

        /// <summary>
        /// Initializes a new instance of the <see cref="BLCalculo"/> class.
        /// </summary>
        public BLCalculo()
        {
            this.mapas.MapearEntidadeModeo();
            this.mapas.MapearModeloEntidad();
        }

        public List<DtoCalculo> ConsultarCalculo(DtoCalculo dtoCalculo)
        {
            try
            {
                List<ent.Calculo> objCalculo = this.dTCalculo.Buscar(x => x.IdCalculo == (dtoCalculo.IdCalculo > 0 ? dtoCalculo.IdCalculo : x.IdCalculo) && x.Usuario.Nombre.ToLower() == (dtoCalculo.Usuario.Nombre != null ? dtoCalculo.Usuario.Nombre.ToLower() : x.Usuario.Nombre)
                && x.Respuesta == (dtoCalculo.Respuesta != null ? dtoCalculo.Respuesta:x.Respuesta)
                && x.Respuesta <= (dtoCalculo.RespuestaMaxima != null ? dtoCalculo.RespuestaMaxima : x.Respuesta)
                && x.Respuesta >= (dtoCalculo.RespuestaMinina != null ? dtoCalculo.RespuestaMinina : x.Respuesta)

                );

                List<DtoCalculo> listdtoCalculo = AutoMapper.Mapper.Map<List<ent.Calculo>, List<DtoCalculo>>(objCalculo);
                return listdtoCalculo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DtoCalculo CrearCalculo(DtoCalculo dtoCalculo)
        {
            BLUsuario bLUsuario = new BLUsuario();
            try
            {
                DtoUsuario usuario = bLUsuario.ConsultarUnUsuario(dtoCalculo.Usuario);
                if (usuario.Nombre != null)
                {
                    ent.Calculo objCalculo = AutoMapper.Mapper.Map<Dto.DtoCalculo, ent.Calculo>(dtoCalculo);
                    objCalculo.Fecha = DateTime.Now;
                    objCalculo.Respuesta = this.Calcular(dtoCalculo.Limite.Value);
                    objCalculo.IdUsuario = usuario.IdUsuario;
                    objCalculo = this.dTCalculo.Adicionar(objCalculo);
                    Dto.DtoCalculo dtoCalcu = AutoMapper.Mapper.Map<ent.Calculo, Dto.DtoCalculo>(objCalculo);
                    return dtoCalcu;
                }
                else
                {
                    throw new Exception("EL usuario no existe");
                }

            }
            catch (Exception ex)
            {
                dtoCalculo.MensajeError = ex.Message;
                return dtoCalculo;
            }
        }

        public DtoCalculo ModificarCalculo(DtoCalculo dtoCalculo)
        {
            try
            {
                ent.Calculo objCalculo = this.dTCalculo.TraerUno(x => x.IdCalculo == dtoCalculo.IdCalculo);
                objCalculo.IdCalculo = dtoCalculo.IdCalculo;
                objCalculo.Fecha = dtoCalculo.Fecha;
                objCalculo = this.dTCalculo.Modificar(objCalculo);
                Dto.DtoCalculo dtoCalcu = AutoMapper.Mapper.Map<ent.Calculo, DtoCalculo>(objCalculo);
                return dtoCalcu;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int Calcular(int limite)
        {
            int sum = 0;
            for (int i = 0; i <= limite; i++)
            {
                sum += (i % 3 == 0 || i % 5 == 0) ? i : 0;
            }
            return sum;
        }

        public bool Eliminar(DtoCalculo dtoCalculo)
        {
            try
            {
                ent.Calculo calculo = this.dTCalculo.TraerUno(x => x.IdCalculo == dtoCalculo.IdCalculo && DbFunctions.DiffDays(DateTime.Now,x.Fecha.Value) >= 30);
                if (calculo != null)
                {
                    this.dTCalculo.Eliminar(calculo);
                }
                else
                {
                    throw new Exception("No se puede eliminar calculos menores a 30 días");
                }

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
    }
}
