using Dapper;
using data.repositorio;
using model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositorio
{
    public class VentaRepository:iVentaRepository
    {
        public readonly mysqlConfig _connection;
        public VentaRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> InsertVenta(Venta venta)
        {
            var db = dbConnection();
            var sql = @"insert into venta(FechaVenta, Empleado_idEmpleado, Cliente_idCliente, Seguro_idSeguro ) values (@FechaVenta, @Empleado_idEmpleado,@Cliente_idCliente,@Seguro_idSeguro)";
            var result = await db.ExecuteAsync(sql, new { venta.FechaVenta, venta.Empleado_idEmpleado, venta.Cliente_idCliente, venta.Seguro_idSeguro });



            return result > 0;
        }

    }
}
