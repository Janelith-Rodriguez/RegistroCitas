using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCitas.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "ContactoEmergencia_UQ", IsUnique = true)]
    public class ContactoEmergencia : EntityBase
    {

        [Required(ErrorMessage = "El nombre del contacto de emergencia es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La relación del contacto de emergencia es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Relacion { get; set; }

        [Required(ErrorMessage = "El telefono del contacto de emergencia es obligatorio.")]
        [MaxLength(15, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El email del contacto de emergencia es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Email { get; set; }
    }
}
