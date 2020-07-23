using Dto;
using Mapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using per = Data;
using ent = DataEntity;
namespace Negocio
{
    public class BLUsuario
    {
        private readonly Mapas mapas = new Mapas();
        private readonly per.DTUsuario dTUsuario = new per.DTUsuario();

        /// <summary>
        /// Initializes a new instance of the <see cref="BLUsuario"/> class.
        /// </summary>
        public BLUsuario()
        {
            this.mapas.MapearEntidadeModeo();
            this.mapas.MapearModeloEntidad();
        }

        public List<DtoUsuario> ConsultarUsuario(DtoUsuario DtoUsuario)
        {
            try
            {
                List<ent.Usuario> objUsuario = this.dTUsuario.Buscar(x => x.IdUsuario == (DtoUsuario.IdUsuario > 0 ? DtoUsuario.IdUsuario : x.IdUsuario) && x.Nombre.ToLower() == (DtoUsuario.Nombre != string.Empty ? DtoUsuario.Nombre.ToLower() : x.Nombre.ToLower()));
                List<DtoUsuario> dtoUsuario = AutoMapper.Mapper.Map<List<ent.Usuario>, List<Dto.DtoUsuario>>(objUsuario);
                return dtoUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DtoUsuario ConsultarUnUsuario(DtoUsuario DtoUsuario)
        {
            try
            {
                ent.Usuario objUsuario = this.dTUsuario.TraerUno(x => x.IdUsuario == (DtoUsuario.IdUsuario > 0 ? DtoUsuario.IdUsuario : x.IdUsuario) && x.Nombre.ToLower() == (DtoUsuario.Nombre != string.Empty ? DtoUsuario.Nombre.ToLower() : x.Nombre.ToLower()));
                DtoUsuario dtoUsuario = AutoMapper.Mapper.Map<ent.Usuario, Dto.DtoUsuario>(objUsuario);
                return dtoUsuario != null ? dtoUsuario : new DtoUsuario(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DtoUsuario CrearUsuario(DtoUsuario DtoUsuario)
        {
            try
            {
                ent.Usuario objUsuario = AutoMapper.Mapper.Map<Dto.DtoUsuario, ent.Usuario>(DtoUsuario);
                objUsuario = this.dTUsuario.Adicionar(objUsuario);
                Dto.DtoUsuario dtoFactu = AutoMapper.Mapper.Map<ent.Usuario, Dto.DtoUsuario>(objUsuario);
                return dtoFactu;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DtoUsuario ModificarUsuario(DtoUsuario DtoUsuario)
        {
            try
            {
                ent.Usuario objUsuario = this.dTUsuario.TraerUno(x => x.IdUsuario == DtoUsuario.IdUsuario);
                objUsuario.IdUsuario = DtoUsuario.IdUsuario;
                objUsuario.Nombre = DtoUsuario.Nombre;
                objUsuario = this.dTUsuario.Modificar(objUsuario);
                Dto.DtoUsuario dtoFactu = AutoMapper.Mapper.Map<ent.Usuario, DtoUsuario>(objUsuario);
                return dtoFactu;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
