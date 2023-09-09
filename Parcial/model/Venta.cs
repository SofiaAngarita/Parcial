using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Venta
    {
        public int idVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Empleado_idEmpleado { get; set; }
        public int Cliente_idCliente { get; set; }
        public int Seguro_idSeguro { get; set; }

    }
}
