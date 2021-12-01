using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Sensor
    {
        public Sensor()
        {
            Telefonos = new HashSet<Telefono>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }
    }
}
