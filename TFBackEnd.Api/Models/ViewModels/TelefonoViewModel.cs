using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models.ViewModels
{
    public class TelefonoViewModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        // public bool Exitosa { get; set; }

        public string OperarioNombre { get; set; }
        public string OperarioApellido { get; set; }
        public string App { get; set; }
    }
}
