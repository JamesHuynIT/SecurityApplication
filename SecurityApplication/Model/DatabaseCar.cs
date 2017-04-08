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
                        //ID 0, HOSTNAME 1, DISPLAYNAME 2, USERNAME 3, PASSWORD 4
                        var hostName = reader.GetString(1);
                        var displayName = reader.GetString(2);
                        var userName = reader.GetString(3);
                        var password = reader.GetString(4);

                        car = new Car(hostName, displayName, userName, password);
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
                        //ID 0, HOSTNAME 1, DISPLAYNAME 2, USERNAME 3, PASSWORD 4
                        var hostName = reader.GetString(1);
                        var displayName = reader.GetString(2);
                        var userName = reader.GetString(3);
                        var password = reader.GetString(4);

                        var car = new Car(hostName, displayName, userName, password);
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
            commandDatabase.Parameters.AddWithValue("@HOST_NAME", newCar.HostName);
            commandDatabase.Parameters.AddWithValue("@DISPLAY_NAME", newCar.DisplayName);
            commandDatabase.Parameters.AddWithValue("@USERNAME", newCar.UserName);
            commandDatabase.Parameters.AddWithValue("@PASSWORD", newCar.Password);

            // Insert success or not
            var insertBool = false;

            try
            {
                // Open Database
                DatabaseConnect.OpenDatabase();

                // Execute the query
                var reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
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
    }
}
