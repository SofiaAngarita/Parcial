using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class mysqlConfig
    {
        public string _connectionString;
        public mysqlConfig(string connectionString) 
        {
            _connectionString = connectionString;
        }

    }
}