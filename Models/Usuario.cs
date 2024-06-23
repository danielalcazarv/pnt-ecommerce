using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCBasico.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DNI { get; set; }

        public string Pass { get; set; }
        
        [Required(ErrorMessage ="Ingreso de nombre Obligatorio")]
        [MaxLength(50,ErrorMessage ="Máx. 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingreso de apellido Obligatorio")]
        [MaxLength(50, ErrorMessage = "Máx. 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingreso de correo Obligatorio")]
        [MaxLength(100, ErrorMessage = "Máx. 100 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingreso de domicilio Obligatorio")]
        public string Domicilio { get; set; }

        [Required(ErrorMessage = "Ingreso de código postal Obligatorio")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Ingreso de código postal Obligatorio")]
        public int Telefono { get; set; }

    }

}