using e_commerce.Context;
using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class CarritoController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly List<CarritoItem> _itemsCarrito;

        public CarritoController(EcommerceDbContext context)
        {
            _context = context;
            _itemsCarrito = new List<CarritoItem>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregaCarrito(int id) {
            
            var productoAgregar = _context.Productos.Find(id);

            var existeItemCarrito = _itemsCarrito.FirstOrDefault(item  => item.Producto.Id == id);

            if (existeItemCarrito != null)
            {
                existeItemCarrito.CantProd++;

            }
            else
            {
                _itemsCarrito.Add(new CarritoItem
                {
                    Producto = productoAgregar,
                    CantProd = 1
                });

            }

            return RedirectToAction("CarritoView");
        }
    }
}
