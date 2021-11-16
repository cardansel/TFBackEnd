using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class apps
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public virtual ICollection<Instalaciones> Instalaciones { get; set; }
    }
}
