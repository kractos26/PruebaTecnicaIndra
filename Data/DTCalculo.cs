using DataRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ent = DataEntity;
using mod = DataModelo;

namespace Data
{
    /// <summary>
    /// Clase que permite la percistencia de los calculos
    /// </summary>
   public class DTCalculo
    {
        /// <summary>
        /// instancia al generico de repocitorio
        /// </summary>
        private readonly Repository<ent.Calculo> repocitorio = new Repository<ent.Calculo>(new mod.CalculosIndraEntities());

        /// <summary>
        /// Permite guardar los calculos
        /// </summary>
        /// <param name="Calculo">Datos del calculo a guardar</param>
        /// <returns></returns>
        public ent.Calculo Adicionar(ent.Calculo Calculo)
        {
            this.repocitorio.Adicionar(Calculo);
            this.repocitorio.Guardar();
            return Calculo;
        }

        /// <summary>
        /// Permite obtener una lista de calculos
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        public List<ent.Calculo> Buscar(Expression<Func<ent.Calculo, bool>> predicado)
        {
            return this.repocitorio.Buscar(predicado);
        }

        /// <summary>
        /// Permite eliminar calculos.
        /// </summary>
        /// <param name="calculo">Datos del calculo a eliminar</param>
        /// <returns></returns>
        public ent.Calculo Eliminar(ent.Calculo calculo)
        {
            this.repocitorio.Eliminar(calculo);
            this.repocitorio.Guardar();
            return calculo;
        }

        /// <summary>
        /// Permite obtener todos los calculos
        /// </summary>
        /// <returns></returns>
        public List<ent.Calculo> GetAll()
        {
            return this.repocitorio.GetAll();
        }

        /// <summary>
        /// Permite modificar un calculo
        /// </summary>
        /// <param name="calculo">datos del calculo a modificar</param>
        /// <returns></returns>
        public ent.Calculo Modificar(ent.Calculo calculo)
        {
            this.repocitorio.Modificar(calculo);
            this.repocitorio.Guardar();
            return calculo;
        }

        /// <summary>
        /// Permite traer un calculo
        /// </summary>
        /// <param name="predicado">filtros.</param>
        /// <returns></returns>
        public ent.Calculo TraerUno(Expression<Func<ent.Calculo, bool>> predicado)
        {
            return this.repocitorio.TraerUno(predicado);
        }

    }
}
