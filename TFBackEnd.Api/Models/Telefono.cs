using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Models
{
    public class Telefono
    {
        public Telefono()
        {
            Sensor = new HashSet<Sensor>();
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Precio { get; set; }
        public int IdInstalacion { get; set; }

        public virtual Instalacion Instalacion { get; set; }
        public virtual ICollection<Sensor> Sensor { get; set; }
    }
}
