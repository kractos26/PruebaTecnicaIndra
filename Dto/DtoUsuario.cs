using System.ComponentModel.DataAnnotations;

namespace Dto
{
    public class DtoUsuario:DtoError
    {
        public int IdUsuario { get; set; }
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "EL usuario es obligatorio categoría.")]
        [MaxLength(100,ErrorMessage = "No puede tener mas de 100 caracteres")]
        public string Nombre { get; set; }
    }
}
