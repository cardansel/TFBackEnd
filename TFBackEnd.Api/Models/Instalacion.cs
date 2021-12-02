using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Instalacion
    {
        public int Id { get; set; }
        public bool Exitosa { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Operario Operario { get; set; }
        public virtual App App { get; set; }
        public virtual Telefono Telefono { get; set; }
    }
}
