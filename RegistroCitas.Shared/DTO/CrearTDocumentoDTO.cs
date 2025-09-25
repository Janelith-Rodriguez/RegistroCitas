using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCitas.Shared.DTO
{
    public class CrearTDocumentoDTO
    {
        [Required(ErrorMessage = "El código del tipo de documento es obligatorio.")]
        [MaxLength(10, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de documento es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }
    }
}
