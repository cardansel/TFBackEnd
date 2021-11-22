using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Instalacione
    {
        public int Id { get; set; }
        public bool Exitosa { get; set; }
        public DateTime fecha { get; set; }

        public int idOperario { get; set; }
        public int idApp { get; set; }

        public virtual ICollection<Telefono> Telefono { get; set; }
        public virtual Operario Operario { get; set; }
        public virtual app App { get; set; }
    }
}
