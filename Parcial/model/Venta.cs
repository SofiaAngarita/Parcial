using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    internal class Venta
    {
        public int idViajes { get; set; }
        public string Valoracion { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Costo { get; set; }
        public int Conductores_id { get; set; }
        public int Clientes_id { get; set; }
    }
}
