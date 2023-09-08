using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositorio
{
    internal class iEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> getEmpleado();
        Task<Empleado> getEmpleadoById(int id);
        Task<bool> insertEmpleado(Empleado empleado);
        Task<bool> updateConductor(Empleado empleado);
        Task<bool> deleteEmpleado(int id);
    }
}
