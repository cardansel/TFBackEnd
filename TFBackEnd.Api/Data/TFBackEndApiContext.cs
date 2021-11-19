using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TFBackEnd.Api.Models;

namespace TFBackEnd.Api.Data
{
    public class TFBackEndApiContext : DbContext
    {
        public TFBackEndApiContext (DbContextOptions<TFBackEndApiContext> options)
            : base(options)
        {
        }

        public DbSet<Telefonos> Telefonos { get; set; }

        public DbSet<TFBackEnd.Api.Models.apps> apps { get; set; }

        public DbSet<TFBackEnd.Api.Models.Instalaciones> Instalaciones { get; set; }

        public DbSet<TFBackEnd.Api.Models.Operarios> Operarios { get; set; }

        public DbSet<TFBackEnd.Api.Models.Sensor> Sensor { get; set; }
 
    }
}
