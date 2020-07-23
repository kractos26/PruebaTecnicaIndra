using AutoMapper;
using ent = DataEntity;

namespace Mapeo
{
    public class Mapas
    {

        public void MapearEntidadeModeo()
        {
            #region mapas entidad a modelos
            Mapper.CreateMap<ent.Calculo, Dto.DtoCalculo>();
            Mapper.CreateMap<ent.Usuario, Dto.DtoUsuario>();
           

            #endregion
        }

        /// <summary>
        /// Configuracion del mapeo de modelo a entidades.
        /// </summary>
        public void MapearModeloEntidad()
        {
            #region mapas entidad a modelos
            Mapper.CreateMap<Dto.DtoCalculo, ent.Calculo>();
            Mapper.CreateMap<Dto.DtoUsuario, ent.Usuario>();
           
            #endregion
        }
    }
}
