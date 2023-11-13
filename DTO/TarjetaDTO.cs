using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TarjetaDTO
    {
        [Required(ErrorMessage ="Digita o Titular")]
        public string? Titular { get; set; }
        [Required(ErrorMessage = "Digita o Número da targeta")]
        public string? Numero { get; set; }
        [Required(ErrorMessage = "Digita Vigencia")]
        public string? Vigencia{ get; set; }
        [Required(ErrorMessage = "Digita o código CVV")]
        public string? CVV{ get; set; }
    }
}
