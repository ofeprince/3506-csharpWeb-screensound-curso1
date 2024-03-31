using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System.Data.Common;

namespace ScreenSound.Db
{
    internal class Connection
    { 

        private Connection()
        {
            
        }

        public static SqlConnection GetConnection()
        {

            string connectionString = "Server=localhost\\SQLEXPRESS;Database=AluraDbWeb;Trusted_Connection=True;TrustServerCertificate=true";
            return new SqlConnection(connectionString);
        }

    }
}
