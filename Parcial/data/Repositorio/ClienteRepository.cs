using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class clienteRepository : iClienteRepository
    {
        public readonly mysqlConfig _connection;
        public clienteRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> deleteCliente(int id)
        {
            var db = dbConnection();
            var sql = @"delete from clientes where idClientes = @Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }



        public Task<Cliente> getClienteById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from clientes where idClientes = @Id";
            return db.QueryFirstOrDefaultAsync<Cliente>(consulta, new { Id = id });
        }



        public Task<IEnumerable<Cliente>> getClientes()
        {
            var db = dbConnection();
            var consulta = @"select * from clientes";
            return db.QueryAsync<Cliente>(consulta);
        }



        public async Task<bool> InsertCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @"insert into clientes(Nombre,Telefono, CorreoElectronico) values (@Nombre,@Telefono,@CorreoElectronico)";
            var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Telefono, cliente.CorreoElectronico });



            return result > 0;
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @"update clientes set Nombre=@Nombre,Telefono=@Telefono,CorreoElectronico=@CorreoElectronico";
            var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Telefono, cliente.CorreoElectronico });



            return result > 0;
        }

    }
}