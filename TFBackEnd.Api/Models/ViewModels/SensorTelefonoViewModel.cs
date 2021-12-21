using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models.ViewModels
{
    public class SensorTelefonoViewModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Precio { get; set; }
        public string Sensor { get; set; }
        public bool InstalllExito { get; set; }
        public DateTime InstallDate { get; set; }
        public string NombreOperario { get; set; }
        public string ApellidoOperario { get; set; }
        public string App { get; set; }
    }
}
