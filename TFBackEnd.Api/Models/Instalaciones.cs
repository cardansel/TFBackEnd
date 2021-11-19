using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Instalaciones
    {
        public int Id { get; set; }
        public bool Exitosa { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        public int idOperario { get; set; }
        public int idApps { get; set; }

        public virtual ICollection<Telefonos> Telefonos { get; set; }
        public virtual Operarios Operarios { get; set; }
        public virtual apps Apps { get; set; }
    }
}
