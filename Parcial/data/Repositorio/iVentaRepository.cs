using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositorio
{
    public class iVentaRepository
    {
        Task<IEnumerable<Venta>> get();
        Task<Venta> getVentaById(int id);
        Task<bool> InsertVenta(Venta venta);
        Task<bool> UpdateVenta(Venta venta);
        Task<bool> deleteVenta(int id);
    }
}
