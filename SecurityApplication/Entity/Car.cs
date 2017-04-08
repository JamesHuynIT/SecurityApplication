namespace SecurityApplication.Entity
{
    public class Car
    {
        /// <summary>
        /// Variable hostname to store hostname of each every car
        /// </summary>
        public string HostName { get; }

        /// <summary>
        /// Variable display name to store display name of each every car
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Variable carName to store name of each every car
        /// </summary>
        public string UserName { get; }


        /// <summary>
        /// Variable password to store password of each every car
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Function constructor Car with 3 parameter
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="displayName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public Car(string hostName, string displayName, string userName, string password)
        {
            HostName = hostName;
            DisplayName = displayName;
            UserName = userName;
            Password = password;

        }

        /// <summary>
        /// Function constructor Car with 0 parameter
        /// </summary>
        public Car()
        {
            HostName = "";
            DisplayName = "";
            UserName = "";
            Password = "";

        }

        /// <summary>
        /// Function compare car for compare two car
        /// </summary>
        /// <param name="car"></param>
        /// <returns>
        /// 1: HostName already exist
        /// 2: UserName of car already exist
        /// 0: New Car accept
        /// </returns>
        public int CompareCar(Car car)
        {
            if (HostName.Equals(car.HostName)) return 1;
            else
            {
                if (UserName.Equals(car.UserName)) return 2;
                else
                {
                    return 0;
                }
            }
        }

    }
}
