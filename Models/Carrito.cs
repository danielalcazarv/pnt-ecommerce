using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCarrito { get; set; }

        public List<CarritoItem> ItemsDeCarrito { get; set; }
        public double? PrecioTotal { get; set; }
        public int? CantTotal { get; set; }
        
        
    }
}
