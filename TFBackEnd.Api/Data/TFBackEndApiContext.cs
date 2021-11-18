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

        public DbSet<TFBackEnd.Api.Models.Telefonos> Telefonos { get; set; }
    }
}
