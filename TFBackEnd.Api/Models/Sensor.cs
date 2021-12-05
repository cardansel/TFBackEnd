using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Sensor
    {
        public Sensor()
        {
            Telefonos = new List<Telefono>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }


        // Esta anotación se usa para decirle a EF que
        // no cree un campo real en la base de datos para este campo
        // El campo TelefonosList nos servirá para recibir una lista
        // de IDs de Telefonos y con ello vincularlos a los Sensores (en POST y PUT)
        [NotMapped]
        public List<int> TelefonosList { get; set; }
        public virtual ICollection<Telefono> Telefonos { get; set; }
    }
}
