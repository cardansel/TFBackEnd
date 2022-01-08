using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Telefono
    {
        public Telefono()
        {
            Sensores = new List<Sensor>();

        }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Precio { get; set; }


        public virtual ICollection<Instalacion> Instalaciones { get; set; }

        

        // Esta anotación se usa para decirle a EF que
        // no cree un campo real en la base de datos para este campo
        // El campo SensoresList nos servirá para recibir una lista
        // de IDs de Sensores y con ello vincularlos al Telefono (en POST y PUT)
        [NotMapped]
        public List<int> SensoresList { get; set; }
        public virtual ICollection<Sensor> Sensores { get; set; }
    }
}
