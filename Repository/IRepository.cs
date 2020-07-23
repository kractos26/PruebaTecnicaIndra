using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    interface IRepository<T> where T : class
    {
        List<T> GetAll();

        List<T> Buscar(Expression<Func<T, bool>> predicado);

        T TraerUno(Expression<Func<T, bool>> predicado);

        T TraerUltimo(Expression<Func<T, bool>> predicado);

        T Adicionar(T Entidad);

        T Modificar(T Entidad);

        T Eliminar(T Entidad);

        void Guardar();
    }
}
