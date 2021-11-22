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

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<TFBackEnd.Api.Models.app> apps { get; set; }

        public DbSet<TFBackEnd.Api.Models.Instalacione> Instalaciones { get; set; }

        public DbSet<TFBackEnd.Api.Models.Operario> Operarios { get; set; }
 
    }
}
