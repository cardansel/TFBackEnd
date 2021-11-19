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
            Telefono = new HashSet<Telefonos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Telefonos> Telefono { get; set; }
    }
}
