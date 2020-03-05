using CalculatorTest.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CalculatorConsoleClient
{
    class ADOLogger : IDiagnostics
    {
        private string _ConnectionString;
        private const string QUERY_BASE = "INSERT INTO LogEntries (Result)"
            + "VALUES (@value)";

        public ADOLogger(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public void LogIntResult(int result)
        {
            var queryString = "INSERT INTO LogEntries (Result)"
                + $"VALUES (@value)";
            using (var connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(QUERY_BASE, connection))
                {
                    command.Parameters.Add("@value", System.Data.SqlDbType.Int).Value = result;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
