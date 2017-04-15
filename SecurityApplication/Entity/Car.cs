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
        public string UserNameCar { get; }

        /// <summary>
        /// Variable carName to store name of each every car
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Variable password to store password of each every car
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Function constructor Car with 5 parameter
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="hostName"></param>
        /// <param name="displayName"></param>
        /// <param name="userNameCar"></param>
        /// <param name="password"></param>
        public Car(string userName, string hostName, string displayName, string userNameCar, string password)
        {
            UserName = userName;
            HostName = hostName;
            DisplayName = displayName;
            UserNameCar = userNameCar;
            Password = password;

        }

        /// <summary>
        /// Function constructor Car with 0 parameter
        /// </summary>
        public Car()
        {
            UserName = "";
            HostName = "";
            DisplayName = "";
            UserNameCar = "";
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
            if (UserNameCar.Equals(car.UserNameCar)) return 2;
            return 0;
        }

    }
}
