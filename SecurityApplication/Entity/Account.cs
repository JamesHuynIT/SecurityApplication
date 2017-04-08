namespace SecurityApplication.Entity
{
    public class Account
    {
        public Account(string userName, string password)
        {
            Username = userName;
            Password = password;
        }

        public Account()
        {
            Username = "";
            Password = "";
        }

        /// <summary>
        /// Variable username to store username of each every account
        /// </summary>
        private string Username { get; }

        /// <summary>
        /// Variable password to store password of each every account
        /// </summary>
        private string Password { get; }

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
                return account.Password.Equals(Password) ? 1 : 2;
            }
            return 0;
        }

        public override bool Equals(object obj)
        {
            Account account = new Account(Username, Password);
            if (1 == account.CompareAccount((Account)obj))
            {
                return true;
            }
            return false;
        }
    }
}