using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositorio
{
    public interface iEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> get();
        Task<Empleado> getEmpleadoById(int id);
        Task<bool> InsertEmpleado(Empleado empleado);
        Task<bool> UpdateEmpleado(Empleado empleado);
        Task<bool> deleteEmpleado(int id);
    }
}
