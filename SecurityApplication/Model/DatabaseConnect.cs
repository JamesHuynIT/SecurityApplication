using MySql.Data.MySqlClient;
using SecurityApplication.Util;

namespace SecurityApplication.Model
{
    public class DatabaseConnect
    {
        // Prepare the connection
        public static readonly MySqlConnection DatabaseConnection = new MySqlConnection(ConstantVariable.Connectstring);

        /// <summary>
        /// Function Open Database
        /// </summary>
        public static void OpenDatabase()
        {
            // Open the database
            DatabaseConnection.Open();
        }

        /// <summary>
        ///     Function Close Database
        /// </summary>
        /// <returns></returns>
        public static void CloseDatabase()
        {
            DatabaseConnection.Close();
        }
    }
}
