using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        [MaxLength(50, ErrorMessage = "Máx. 50 caracteres")]
        [Required(ErrorMessage = "Ingreso Obligatorio")]
        [DisplayName("DNI o Correo")]
        public string DNIoEmail { get; set; }

        [Required(ErrorMessage = "Ingreso de contraseña Obligatorio")]
        [MaxLength(20, ErrorMessage = "Máx. 20 caracteres")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}
