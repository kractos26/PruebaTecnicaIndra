using DataRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ent = DataEntity;
using mod = DataModelo;
namespace Data
{
    public class DTUsuario
    {
        private readonly Repository<ent.Usuario> repocitorio = new Repository<ent.Usuario>(new mod.CalculosIndraEntities());

        public ent.Usuario Adicionar(ent.Usuario Usuario)
        {
            this.repocitorio.Adicionar(Usuario);
            this.repocitorio.Guardar();
            return Usuario;
        }

        public List<ent.Usuario> Buscar(Expression<Func<ent.Usuario, bool>> predicado)
        {
            return this.repocitorio.Buscar(predicado);
        }


        public ent.Usuario Eliminar(ent.Usuario Entidad)
        {
            this.repocitorio.Eliminar(Entidad);
            this.repocitorio.Guardar();
            return Entidad;
        }

        public List<ent.Usuario> GetAll()
        {
            return this.repocitorio.GetAll();
        }

        public ent.Usuario Modificar(ent.Usuario Entidad)
        {
            this.repocitorio.Modificar(Entidad);
            this.repocitorio.Guardar();
            return Entidad;
        }

        public ent.Usuario TraerUno(Expression<Func<ent.Usuario, bool>> predicado)
        {
            return this.repocitorio.TraerUno(predicado);
        }
    }
}
