using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCarrito { get; set; }
        public string IdUsuario { get; set; }
        public double Total { get; set; }
        
        
    }
}
