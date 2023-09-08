using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositorio
{
    internal class MysqlConfig
    {
        public string _connectionString;
        public MysqlConfig(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}