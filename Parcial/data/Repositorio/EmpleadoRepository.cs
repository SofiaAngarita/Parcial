﻿
using model;
using data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace data.repositorio
{
    public class EmpleadoRepository : iEmpleadoRepository
    {
        public readonly mysqlConfig _connection;
        public EmpleadoRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> deleteEmpleado(int id)
        {
            var db = dbConnection();
            var sql = @"delete from empleado where idEmpleado = @Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public async Task<Empleado> GetEmpleadoById(int id)
        {
            MySqlConnection mySqlConnection = dbConnection();
            var db = mySqlConnection;
            var consulta = @"select * from empleado where idEmpleado = @Id";
            return await db.QueryFirstOrDefaultAsync<Empleado>(consulta, new { Id = id });
        }
        public Task<IEnumerable<Empleado>> GetEmpleado()
        {
            var db = dbConnection();
            var consulta = @"select * from empleado";
            return db.QueryAsync<Empleado>(consulta);
        }
        public async Task<bool> InsertEmpleado(Empleado empleado)
        {
            var db = dbConnection();
            var sql = @"insert into empleado(Nombre, Telefono, CorreoElectronico ) values ( @Nombre, @Telefono, @CorreoElectronico )";
            var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Telefono, empleado.CorreoElectronico });

            return result > 0;
        }
        public async Task<bool> updateEmpleado(Empleado empleado)
        {
            var db = dbConnection();
            var sql = @"update empleado set Nombre=@Nombre, Telefono=@Telefono, CorreoElectronico=@CorreoElectronico where idEmpleado=@ID";
            var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Telefono, empleado.CorreoElectronico, empleado.ID });

            return result > 0;

        }

    }

}