namespace SecurityApplication.Util
{
    public class ConstantVariable
    {
        // Port Name
        public static readonly string PORTNAME = "COM4";

        // Baud Rate
        public static readonly int BAUDRATE = 9600;

        // Connect String 
        public static string CONNECTSTRING =
            "datasource=127.0.0.1;port=3306;username=root;password=;database=securitycamera;";

        // Query
        public static string QUERY_ACCOUNT = "SELECT * FROM ACCOUNT";

        // Message Error Account
        public static string MESAGE_ERROR_ACCOUNT = "Sorry account doesn't exist!";

        // Message Error Password
        public static string MESAGE_ERROR_PASSWORD = "Sorry password is not correct!";

        // Message Empty
        public static string MESAGE_ERROR_EMPTY = "Sorry username or password must not empty. \nThanks you!";
    }
}