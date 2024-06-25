using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingreso de nombre Obligatorio")]
        [MaxLength(50, ErrorMessage = "Máx. 50 caracteres")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Ingreso precio Obligatorio")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Ingreso de stock Obligatorio")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Ingreso de marca Obligatorio")]
        [MaxLength(20, ErrorMessage = "Máx. 20 caracteres")]
        public string Marca { get; set; }

        public string Imagen { get; set; }

    }
}
