using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Models
{
    public class Instalacion
    {
        public int Id { get; set; }
        public bool Exitosa { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }
        public virtual ICollection<App> Apps { get; set; }
        public virtual  ICollection<Operario> Operarios { get; set; }
    }
}
