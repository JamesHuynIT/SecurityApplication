using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SecurityApplication.Entity;
using SecurityApplication.Util;

/**
 *  Class Database Car is class call connect to MySQL database table car
 *  and query data in table
 *  Author: NhanHTT
 *  Version: 1.0
 *  Date: 04/01/2017
 */
namespace SecurityApplication.Model
{
    public class DatabaseCar
    {
        /// <summary>
        /// Function Find Car in database by uisng carName
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Car FindCar(string username)
        {
            var car = new Car();

            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryFindCar, DatabaseConnect.DatabaseConnection);
            commandDatabase.Parameters.AddWithValue("@USERNAME", username);

            try
            {
                // Open Database
                DatabaseConnect.OpenDatabase();

                // Execute the query
                var reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //ID 0, USERNAME 1, HOSTNAME 2, DISPLAYNAME 3, USERNAME 4, PASSWORD 5
                        var userName = reader.GetString(1);
                        var hostName = reader.GetString(2);
                        var displayName = reader.GetString(3);
                        var userNameCar = reader.GetString(4);
                        var password = reader.GetString(5);

                        car = new Car(userName, hostName, displayName, userNameCar, password);
                    }
                }

                // Close Database
                DatabaseConnect.CloseDatabase();
            }

            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log to file database
                LogApp.LogDatabaseError(ex.Message);
            }
            return car;
        }

        /// <summary>
        /// Function Query all Car in database
        /// </summary>
        /// <returns></returns>
        public List<Car> LoadCar()
        {
            var carList = new List<Car>();

            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryCar, DatabaseConnect.DatabaseConnection);
            try
            {
                // Open Database
                DatabaseConnect.OpenDatabase();

                // Execute the query
                var reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //ID 0, USERNAME 1, HOSTNAME 2, DISPLAYNAME 3, USERNAME 4, PASSWORD 5
                        var userName = reader.GetString(1);
                        var hostName = reader.GetString(2);
                        var displayName = reader.GetString(3);
                        var userNameCar = reader.GetString(4);
                        var password = reader.GetString(5);

                        var car = new Car(userName, hostName, displayName, userNameCar, password);
                        carList.Add(car);
                    }
                }

                // Close Database
                DatabaseConnect.CloseDatabase();
            }

            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log to file database
                LogApp.LogDatabaseError(ex.Message);
            }
            return carList;
        }

        /// <summary>
        /// Function Count All Car in Database
        /// </summary>
        /// <returns></returns>
        public int CountCar()
        {
            // Count Number of car
            int count = 0;

            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryCountCar, DatabaseConnect.DatabaseConnection);

            try
            {
                // Open Database
                DatabaseConnect.OpenDatabase();

                // Execute the query
                var reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //ID 0, USERNAME 1, PASSWORD 2
                        count = reader.GetInt16(0);
                    }
                }

                // Close Database
                DatabaseConnect.CloseDatabase();
            }

            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log to file database
                LogApp.LogDatabaseError(ex.Message);
            }

            return count;
        }

        /// <summary>
        /// Function Add New Car to database
        /// </summary>
        /// <param name="newCar"></param>
        public bool AddNewCar(Car newCar)
        {
            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryAddNewCar, DatabaseConnect.DatabaseConnection);

            commandDatabase.Parameters.AddWithValue("@USERNAME", newCar.UserName);
            commandDatabase.Parameters.AddWithValue("@HOST_NAME_CAR", newCar.HostName);
            commandDatabase.Parameters.AddWithValue("@DISPLAY_NAME", newCar.DisplayName);
            commandDatabase.Parameters.AddWithValue("@USERNAME_CAR", newCar.UserNameCar);
            commandDatabase.Parameters.AddWithValue("@PASSWORD_CAR", Md5Convert.Md5Parse(newCar.Password));

            // Insert success or not
            var insertBool = false;

            try
            {
                // Open Database
                DatabaseConnect.OpenDatabase();

                // Execute the query
                var reader = commandDatabase.ExecuteNonQuery();

                if (1 == reader)
                {
                    insertBool = true;
                }

                // Close Database
                DatabaseConnect.CloseDatabase();

                return insertBool;
            }

            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log to file database
                LogApp.LogDatabaseError(ex.Message);

                return false;
            }
        }

        /// <summary>
        /// Function RollBack
        /// </summary>
        public void RollBack()
        {

            try
            {
                MySqlConnection databaseConnection = new MySqlConnection(ConstantVariable.Connectstring);
                databaseConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand();
                MySqlTransaction mySqlTransaction = databaseConnection.BeginTransaction(); 
                mySqlCommand.Connection = databaseConnection;
                mySqlCommand.Transaction = mySqlTransaction;
                mySqlTransaction.Rollback();
                databaseConnection.Close();
            }

            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log to file database
                LogApp.LogDatabaseError(ex.Message);
            }
        }
    }
}
