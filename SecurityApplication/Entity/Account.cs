namespace SecurityApplication.Entity
{
    public class Account
    {
        public Account(string userName, string password)
        {
            Username = userName;
            Password = password;
        }

        private string Username { get; set; }
        private string Password { get; set; }

        /*
         * Function Compare Account
         * return vaule:
         *  0: Account doesn't exist
         *  1: Account correct
         *  2: Wrong password
         */

        public int CompareAccount(Account account)
        {
            if (account.Username.Equals(Username))
            {
                if (account.Password.Equals(Password))
                {
                    return 1;
                }
                return 2;
            }
            return 0;
        }
    }
}