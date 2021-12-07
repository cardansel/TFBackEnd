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

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<App> Apps { get; set; }

        public DbSet<Instalacion> Instalaciones { get; set; }

        public DbSet<Operario> Operarios { get; set; }

        public DbSet<Sensor> Sensor { get; set; }


        
 
    }
}
