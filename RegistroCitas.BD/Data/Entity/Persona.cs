﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCitas.BD.Data.Entity
{
    [Index(nameof(TDocumentoId), nameof(NumDoc), Name = "Persona_UQ", IsUnique = true)]
    [Index(nameof(Apellido), nameof(Nombre), Name = "Persona_Apellido_Nombre", IsUnique = false)]
    public class Persona : EntityBase
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
        //[MaxLength(20, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public int TDocumentoId { get; set; }

        public TDocumento TDocumento { get; set; }
        public List<ContactosEmergencia> ContactosEmergencias { get; set; }
    }
}
