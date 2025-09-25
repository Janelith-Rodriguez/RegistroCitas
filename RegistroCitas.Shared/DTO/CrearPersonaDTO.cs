using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCitas.Shared.DTO
{
    public class CrearPersonaDTO
    {
        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string NumDoc { get; set; }

        [Required(ErrorMessage = "El nombre de la persona es obligatorio.")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido de la persona es obligatorio.")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio.")]

        public int TDocumentoId { get; set; }
    }
}
