using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.ViewModels
{
    public class RegistroViewModel
    {
        [Key]
        [MaxLength(12, ErrorMessage = "Máx. 12 caracteres")]
        [Required(ErrorMessage = "Ingreso de DNI Obligatorio")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "Ingreso de contraseña Obligatorio")]
        [MaxLength(20, ErrorMessage = "Máx. 20 caracteres")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Su contraseña ingresada no es igual")]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar Contraseña")]
        public string ConfirmarPassword { get; set; }

        [Required(ErrorMessage = "Ingreso de nombre Obligatorio")]
        [MaxLength(50, ErrorMessage = "Máx. 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingreso de apellido Obligatorio")]
        [MaxLength(50, ErrorMessage = "Máx. 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingreso de correo electrónico Obligatorio")]
        [MaxLength(100, ErrorMessage = "Máx. 100 caracteres")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Por favor ingrese un correo válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingreso de domicilio Obligatorio")]
        public string Domicilio { get; set; }

        [Required(ErrorMessage = "Ingreso de código postal Obligatorio")]
        [MaxLength(20, ErrorMessage = "Máx. 20 caracteres")]
        [DisplayName("Código Postal")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Ingreso de teléfono Obligatorio")]
        [DisplayName("Teléfono")]
        public int Telefono { get; set; }
    }
}
