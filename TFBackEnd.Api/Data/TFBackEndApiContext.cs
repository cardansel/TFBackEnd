﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TFBackEnd.Models;

namespace TFBackEnd.Api.Data
{
    public class TFBackEndApiContext : DbContext
    {
        public TFBackEndApiContext (DbContextOptions<TFBackEndApiContext> options)
            : base(options)
        {
        }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<App> Apps { get; set; }

        public DbSet<Instalacion> Instalaciones { get; set; }

        public DbSet<Operario> Operarios { get; set; }

        public DbSet<Sensor> Sensor { get; set; }
 
    }
}
