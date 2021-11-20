using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Models
{
    public class App
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
       // public int IdInstalacion { get; set; }
        public virtual Instalacion Instalacion { get; set; }
    }
}
