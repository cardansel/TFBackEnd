using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Instalacion
    {
        public int Id { get; set; }
        public bool Exitosa { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }

        public int OperarioId { get; set; }
        public virtual Operario Operario { get; set; }

        public int AppId { get; set; }
        public virtual App App { get; set; }

        public int TelefonoId { get; set; }
        public virtual Telefono Telefono { get; set; }
    }
}
