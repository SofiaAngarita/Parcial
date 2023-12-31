﻿using Dapper;
using model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class ClienteRepository : iClienteRepository
    {
        public readonly mysqlConfig _connection;
        public ClienteRepository(mysqlConfig connection)
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
            var sql = @"delete from cliente where idCliente = @Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }



        public async Task<Cliente> getClienteById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from cliente where idClientes = @Id";
            return await db.QueryFirstOrDefaultAsync<Cliente>(consulta, new { Id = id });
        }
        public async Task<IEnumerable<Cliente>> getCliente()
        {
            var db = dbConnection();
            var consulta = @"select * from cliente";
            return await db.QueryAsync<Cliente>(consulta);
        }



        public async Task<bool> InsertCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @"insert into cliente(Nombre,Telefono, CorreoElectronico) values (@Nombre,@Telefono,@CorreoElectronico)";
            var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Telefono, cliente.CorreoElectronico });



            return result > 0;
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @"update cliente set Nombre=@Nombre,Telefono=@Telefono,CorreoElectronico=@CorreoElectronico";
            var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Telefono, cliente.CorreoElectronico });



            return result > 0;
        }

    }
}