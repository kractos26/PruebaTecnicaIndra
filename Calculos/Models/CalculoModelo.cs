using System.Collections.Generic;

namespace Calculos.Models
{
    public class CalculoModelo
    {
        public Dto.DtoCalculo DtoCalculo { get; set; }
        public List<Dto.DtoCalculo> dtoCalculos { get; set; }

       public CalculoModelo()
        {
            this.dtoCalculos = new List<Dto.DtoCalculo>();
            this.DtoCalculo = new Dto.DtoCalculo();
        }
    }
}