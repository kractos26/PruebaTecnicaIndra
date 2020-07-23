using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly DbContext _contex;
        public Repository(DbContext contex)
        {
            this._contex = contex;

        }

        public T Adicionar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State != EntityState.Deleted)
            {
                this._contex.Entry<T>(Entidad).State = EntityState.Added;
            }
            else
            {
                this._contex.Set<T>().Add(Entidad);
            }
            return Entidad;
        }

        public List<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _contex.Set<T>().Where(predicado).ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Eliminar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State == EntityState.Deleted)
            { this._contex.Set<T>().Attach(Entidad); }
            _contex.Entry<T>(Entidad).State = EntityState.Deleted;
            return Entidad;
        }

        public List<T> GetAll()
        {
            return _contex.Set<T>().ToList();
        }

        public void Guardar()
        {
            this._contex.SaveChanges();
        }

        public T Modificar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State == EntityState.Deleted)
            { this._contex.Set<T>().Attach(Entidad); }

            _contex.Entry<T>(Entidad).State = EntityState.Modified;

            return Entidad;
        }

        public T TraerUno(Expression<Func<T, bool>> predicado)
        {
            return _contex.Set<T>().FirstOrDefault(predicado);
        }

        public T TraerUltimo(Expression<Func<T, bool>> predicado)
        {
            return _contex.Set<T>().LastOrDefault(predicado);
        }
    }
}
