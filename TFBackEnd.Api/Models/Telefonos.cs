﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models
{
    public class Telefonos
    {
        public Telefonos()
        {
            Sensors = new HashSet<Sensor>();
        }

        public int id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public float precio { get; set; }

        public int idInstalacion { get; set; }

        public virtual Instalaciones Instalaciones { get; set; }

        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
