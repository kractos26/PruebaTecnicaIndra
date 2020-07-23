using System;
using System.ComponentModel.DataAnnotations;

namespace Dto
{
    public class DtoCalculo:DtoError
    {
        public int IdCalculo { get; set; }

        public int? Respuesta { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdUsuario { get; set; }

        [Display(Name = "Respuesta (Maxima)")]

        public int? RespuestaMaxima { get; set; }

        [Display(Name = "Respuesta (Minima)")]

        public int? RespuestaMinina { get; set; }

        [Required(ErrorMessage = "EL limite es obligatorio.")]
        [Range(1, 9999, ErrorMessage = "No puede tener mas de 5 caracteres")]
        public int? Limite { get; set; }
        public DtoUsuario Usuario { get; set; }

        public DtoCalculo()
        {
            this.Usuario = new DtoUsuario();
        }
    }
}
