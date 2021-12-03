using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFBackEnd.Api.Models.Response
{
    public class Respuesta
    {
        public int Paso { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            this.Paso = 0;
        }
    }
}
