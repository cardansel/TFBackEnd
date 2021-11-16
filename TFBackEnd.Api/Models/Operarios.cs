using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Operarios
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public virtual ICollection<Instalaciones> Instalaciones { get; set; }
    }
}
