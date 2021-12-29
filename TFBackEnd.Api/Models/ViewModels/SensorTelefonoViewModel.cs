using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models.ViewModels
{
    public class SensorTelefonoViewModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Sensor { get; set; }
        public float Precio { get; set; }
        
    }
}
