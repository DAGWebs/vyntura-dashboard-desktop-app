using System;
using System.Data.SqlClient;

namespace Dashboard.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "Server=(local); Database=MVVMLoginDb; Integrated Security=true; TrustServerCertificate=true";
        }

        protected SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                connection?.Close();
                return connection;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while establishing database connection: {ex.Message}");
                throw; // Re-throw the exception to let the caller know there was an error
            }
        }
    }
}
