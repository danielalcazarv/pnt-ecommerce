﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace e_commerce.Models
{
    [Index(nameof(Correo),IsUnique = true)]
    [Index(nameof(DNI), IsUnique= true)]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DNI { get; set; }
        
        [Required(ErrorMessage = "Ingreso de contraseña Obligatorio")]
        [MaxLength(20, ErrorMessage = "Máx. 20 caracteres")]
        public string Password { get; set; }
        
        [Required(ErrorMessage ="Ingreso de nombre Obligatorio")]
        [MaxLength(50,ErrorMessage ="Máx. 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingreso de apellido Obligatorio")]
        [MaxLength(50, ErrorMessage = "Máx. 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingreso de correo electrónico Obligatorio")]
        [MaxLength(100, ErrorMessage = "Máx. 100 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingreso de domicilio Obligatorio")]
        public string Domicilio { get; set; }

        [Required(ErrorMessage = "Ingreso de código postal Obligatorio")]
        [MaxLength(20, ErrorMessage = "Máx. 20 caracteres")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Ingreso de teléfono Obligatorio")]
        public int Telefono { get; set; }

    }

}