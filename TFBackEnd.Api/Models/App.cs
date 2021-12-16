using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class App
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Instalacion> Instalaciones { get; set; }
    }
}
