using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SecurityApplication.Entity;
using SecurityApplication.Util;

/**
 *  Class Database Account is class call connect to MySQL database table account
 *  and query data in table
 *  Author: NhanHTT
 *  Version: 1.0
 *  Date: 04/01/2017
 */
namespace SecurityApplication.Model
{
    public class DatabaseAccount
    {
        /// <summary>
        ///     Function Query All Account in Database
        /// </summary>
        /// <returns>List account</returns>
        public List<Account> LoadAccount()
        {
            var accountList = new List<Account>();

            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryAccount, DatabaseConnect.DatabaseConnection);

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
                        var userName = reader.GetString(1);
                        var password = reader.GetString(2);

                        // Load to new account
                        var account = new Account(userName, password);

                        // Add account to list
                        accountList.Add(account);
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

            return accountList;
        }

        /// <summary>
        ///     Function Find Account in database
        ///     <param name="username">User name to find</param>
        /// </summary>
        /// <returns>Account found in database</returns>
        public Account FindAccount(string username)
        {
            var account = new Account();

            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryFindAccount, DatabaseConnect.DatabaseConnection);
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
                        //ID 0, USERNAME 1, PASSWORD 2
                        var userName = reader.GetString(1);
                        var password = reader.GetString(2);

                        account = new Account(userName, password);
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

            return account;
        }

        /// <summary>
        /// Function Count all Account in database
        /// </summary>
        /// <returns></returns>
        public int CountAccount()
        {
            // Count Number of Account
            int count = 0;

            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryCountAccount, DatabaseConnect.DatabaseConnection);

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
    }
}