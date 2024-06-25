﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.Models;
using System.Collections.Generic;
using e_commerce.ViewModels;

namespace e_commerce.Context
{
    public class EcommerceDbContext : DbContext
    {

        public EcommerceDbContext(DbContextOptions<EcommerceDbContext>options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Producto> Productos { get; set; }
    }
}