using System.Data.Odbc;
using UnityEngine;

namespace Example.Odbc
{
    public class DatabaseManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Connection Properties")]
        public string Host = "localhost";
        public string Port = "3306";
        public string User = "root";
        public string Password = "root";
        public string Database = "test";

        #endregion

        private void Start()
        {
            try
            {
                string connectionString = "DRIVER={MySQL ODBC 8.0 Unicode Driver};" +
                                          $"SERVER={Host};" +
                                          $"PORT={Port};" +
                                          $"DATABASE={Database};" +
                                          $"UID={User};" +
                                          $"PWD={Password};";
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    connection.Open();
                    print("Open Connection");
                }
            }
            catch (OdbcException exception)
            {
                print(exception.Message);
            }
        }
    }
}