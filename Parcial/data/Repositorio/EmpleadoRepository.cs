using data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var sql = @"delete from conductores where idConductores = @Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<Empleado> GetEmpleadoById(int id, MySqlConnection db)
        {
            MySqlConnection mySqlConnection = dbConnection();
            var db = mySqlConnection;
            var consulta = @"select * from conductores where idConductores = @Id";
            return db.QueryFirstOrDefaultAsync<Empleado>(consulta, new { Id = id });
        }
        public Task<IEnumerable<Empleado>> getEmpleado()
        {
            var db = dbConnection();
            var consulta = @"select * from conductores";
            return db.QueryAsync<Empleado>(consulta);
        }
        public async Task<bool> insertEmpleado(Empleado conductor)
        {
            var db = dbConnection();
            var sql = @"insert into conductores(Documento,Nombre,disponibilidad,placa,modelo,licencia,Foto,TipoDoc_idTipoDoc) values(@Documento,@Nombre,@disponibilidad,@placa,@modelo,@licencia,@Foto,@tipoDoc)";
            var result = await db.ExecuteAsync(sql, new { conductor.documento, conductor.nombre, conductor.disponibilidad, conductor.placa, conductor.modelo, conductor.licencia, conductor.foto, conductor.tipoDoc });

            return result > 0;
        }
        public async Task<bool> updateConductor(Empleado conductor)
        {
            var db = dbConnection();
            var sql = @"update conductores set Documento=@Documento,Nombre=@Nombre,disponibilidad=@disponibilidad,placa=@placa,modelo=@modelo,licencia=@licencia,Foto=@Foto, TipoDoc_idTipoDoc=@tipoDoc where idConductores=@Id";
            var result = await db.ExecuteAsync(sql, new { conductor.documento, conductor.nombre, conductor.disponibilidad, conductor.placa, conductor.modelo, conductor.licencia, conductor.foto, conductor.tipoDoc, conductor.id });

            return result > 0;

        }

    }

    internal class Empleado
    {
    }

    internal class Empleado
    {
    }
}