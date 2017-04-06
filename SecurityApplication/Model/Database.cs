using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SecurityApplication.Entity;
using SecurityApplication.Util;

/**
 *  Class Database is class call connect to MySQL database 
 *  and query data in table
 *  Author: NhanHTT
 *  Version: 1.0
 *  Date: 04/01/2017
 */

namespace SecurityApplication.Model
{
    public class Database
    {
        // Prepare the connection
        private static readonly MySqlConnection DatabaseConnection = new MySqlConnection(ConstantVariable.Connectstring);

        private MySqlDataReader _reader;

        /*
         * Function Open Database
         */

        private void OpenDatabase()
        {
            // Open the database
            DatabaseConnection.Open();
        }

        /// <summary>
        ///     Function Close Database
        /// </summary>
        /// <returns></returns>
        private void CloseDatabase()
        {
            DatabaseConnection.Close();
        }

        /// <summary>
        ///     Function Query All Account in Database
        /// </summary>
        /// <returns>List account</returns>
        public List<Account> LoadAccount()
        {
            var accountList = new List<Account>();

            // Prepare the query
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryAccount, DatabaseConnection);

            try
            {
                // Open Database
                OpenDatabase();

                // Execute the query
                _reader = commandDatabase.ExecuteReader();

                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        //ID 0, USERNAME 1, PASSWORD 2
                        var userName = _reader.GetString(1);
                        var password = _reader.GetString(2);

                        // Load to new account
                        var account = new Account(userName, password);

                        // Add account to list
                        accountList.Add(account);
                    }
                }

                // Close Database
                CloseDatabase();
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
            var commandDatabase = new MySqlCommand(ConstantVariable.QueryFindAccount, DatabaseConnection);
            commandDatabase.Parameters.AddWithValue("@USERNAME", username);
            try
            {
                // Open Database
                OpenDatabase();

                // Execute the query
                _reader = commandDatabase.ExecuteReader();

                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        //ID 0, USERNAME 1, PASSWORD 2
                        var userName = _reader.GetString(1);
                        var password = _reader.GetString(2);

                        account = new Account(userName, password);
                    }
                }

                // Close Database
                CloseDatabase();
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
    }
}