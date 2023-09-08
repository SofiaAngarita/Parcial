namespace data.repositorio
{
    public class MySqlConnection
    {
        private object connectionString;

        public MySqlConnection(object connectionString)
        {
            this.connectionString = connectionString;
        }

        internal Task<int> ExecuteAsync(string sql, object value)
        {
            throw new NotImplementedException();
        }

        internal Task<IEnumerable<T>> QueryAsync<T>(string consulta)
        {
            throw new NotImplementedException();
        }

        internal Task<Cliente> QueryFirstOrDefaultAsync<T>(string consulta, object value)
        {
            throw new NotImplementedException();
        }
    }
}