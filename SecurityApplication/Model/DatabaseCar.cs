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
        /// <param name="carname"></param>
        /// <returns></returns>
        public Car FindCar(string carname)
        {
            var car = new Car();

            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryFindCar, DatabaseConnect.DatabaseConnection);
            commandDatabase.Parameters.AddWithValue("@CARNAME", carname);
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
                        var carId = reader.GetString(1);
                        var carName = reader.GetString(2);
                        var carPort = reader.GetInt16(3);

                        car = new Car(carId, carName, carPort);
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
                        //ID 0, USERNAME 1, PASSWORD 2
                        var carId = reader.GetString(1);
                        var carName = reader.GetString(2);
                        var carPort = reader.GetInt16(3);

                        var car = new Car(carId, carName, carPort);
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
        public void AddNewCar(Car newCar)
        {
            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryAddNewCar, DatabaseConnect.DatabaseConnection);

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
                        //count = reader.GetInt16(0);
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
        }
    }
}
