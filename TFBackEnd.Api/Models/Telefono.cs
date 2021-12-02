using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Telefono
    {
        public Telefono()
        {
            Sensores = new List<Sensor>();

        }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Precio { get; set; }

        public virtual ICollection<Instalacion> Instalaciones { get; set; }

        public virtual ICollection<Sensor> Sensores { get; set; }
    }
}
