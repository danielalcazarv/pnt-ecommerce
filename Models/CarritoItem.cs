namespace e_commerce.Models
{
    public class CarritoItem
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int CantProd {  get; set; }

    }
}
