using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFBackEnd.Api.Data;

namespace TFBackEnd.Api.Models.ViewModels
{
    public class InstalacionViewModel
    {
        public int Id { get; set; }
        public bool Exitosa { get; set; }
        public DateTime fecha { get; set; }

        public string Operario { get; set; }
        public string App { get; set; }
        public string Telefono { get; set; }

    }
}
