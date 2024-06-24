using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using e_commerce.Context;
using e_commerce.Models;
using e_commerce.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace e_commerce.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly EcommerceDbContext _context;

        public UsuariosController(EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        // TODO ****Hay que modificar FRONT que es lo que muestra OJO****
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        // TODO ****Hay que modificar FRONT que es lo que muestra OJO****
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.DNI == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Registro de Usuarios
        public IActionResult Registro()
        {
            return View();
        }

        // POST: Registro de Usuarios
        [HttpPost]
        public IActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.DNI = model.DNI;
                usuario.Password = model.Password;
                usuario.Nombre = model.Nombre;
                usuario.Apellido = model.Apellido;
                usuario.Correo = model.Correo;
                usuario.Domicilio = model.Domicilio;
                usuario.Telefono = model.Telefono;
                usuario.CodigoPostal = model.CodigoPostal;

                try
                {
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{usuario.Nombre} {usuario.Apellido} ha sido registrado de forma satisfactoria. Por favor loguearse.";
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "El DNI y/o correo que intenta ingresar ya fue registrado.");
                    return View(model);
                }
                return View();
            }

            return View(model);
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _context.Usuarios.Where(x => (x.DNI == model.DNIoEmail || x.Correo == model.DNIoEmail) && x.Password == model.Password).FirstOrDefault();
                
                if (usuario != null)
                {
                    //Si encuentra crea la cookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Nombre),
                        new Claim(ClaimTypes.Role, "Usuario"),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("PaginaSegura");
                }
                else
                {
                    ModelState.AddModelError("", "DNI/Correo o Contraseña Incorrecto/s.");
                }
            }
            return View(model);
        }

        // LogOut
        public IActionResult LogOut() 
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }


        // GET: Página segura 
        //****Cambiar para que redireccione a productos****
        [Authorize]
        public IActionResult PaginaSegura()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DNI,Password,Nombre,Apellido,Correo,Domicilio,CodigoPostal,Telefono")] Usuario usuario)
        {
            if (id != usuario.DNI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.DNI))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        
        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.DNI == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuarios.Any(e => e.DNI == id);
        }



    }
}
