using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models.ViewModels
{
    public class OperarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Aplicacion { get; set; }
        public bool Exitosa { get; set; }
        public DateTime Fecha { get; set; }

    }
}
