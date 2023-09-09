using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iClienteRepository
    {
        Task<IEnumerable<Cliente>> getCliente();
        Task<Cliente> getClienteById(int id);
        Task<bool> InsertCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> deleteCliente(int id);
    }
}
