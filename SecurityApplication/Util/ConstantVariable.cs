﻿namespace SecurityApplication.Util
{
    public class ConstantVariable
    {
        // Port Name
        public static readonly string Portname = "COM4";

        // Baud Rate
        public static readonly int Baudrate = 9600;

        // Connect String 
        public static string Connectstring =
            "datasource=127.0.0.1;port=3306;username=root;password=;database=securitycamera;";

        // Query All Account
        public static string QueryAccount = "SELECT * FROM ACCOUNT";

        // Query Count Account
        public static string QueryCountAccount = "SELECT COUNT(*) FROM ACCOUNT";

        // Query Find Account
        public static string QueryFindAccount = "SELECT * FROM ACCOUNT WHERE USERNAME=@USERNAME";

        // Query Find Car
        public static string QueryFindCar= "SELECT * FROM CAR WHERE CARNAME=@CARNAME";

        // Query All Car
        public static string QueryCar = "SELECT * FROM CAR";
               
        // Query Count Car
        public static string QueryCountCar = "SELECT COUNT(*) FROM CAR";

        // Query Add New Car
        public static string QueryAddNewCar = "INSERT INTO CAR(CAR_ID, CAR_NAME, CAR_PORT) VALUES (@CARID, @CARNAME, @CARPORT)";

        // Message Error Account
        public static string MesageErrorAccount = "Sorry account doesn't exist!";

        // Message Error Password
        public static string MesageErrorPassword = "Sorry password is not correct!";

        // Message Empty
        public static string MesageErrorEmpty = "Sorry username or password must not empty. \nThanks you!";

        // File Log Database
        public static string LogDatabase = "LogDatabaseSecurityApp.txt";

        // File Log Application
        public static string LogApplcation = "LogSecurityApplcation.txt";
    }
}