using System;
using System.Net.Http;

namespace SecurityApplication.Entity
{
    public class Car
    {
        /// <summary>
        /// Variable carID to store id of each every car
        /// </summary>
        private string CarId
        {
            get { return CarId; }

            set
            {
                int length = CarId.Length;
                string newCarId = "";
                if (length > 20)
                {
                    for (int i = 0; i <= 20; i++)
                    {
                        newCarId += CarId[i];
                    }
                    CarId = newCarId;
                }
                else
                {
                    CarId = CarName;
                }
            }
        }

        /// <summary>
        /// Variable carName to store name of each every car
        /// </summary>
        private string CarName
        {
            get { return CarName; }

            set
            {
                int length = CarName.Length;
                string newCarName = "";
                if (length > 20)
                {
                    for (int i = 0; i <= 20; i++)
                    {
                        newCarName += CarName[i];
                    }
                    CarName = newCarName;
                }
                else
                {
                    CarName = CarName;
                }
            }
        }

        /// <summary>
        /// Variable carName to store name of each every car
        /// </summary>
        private int CarPort
        {
            get { return CarPort; }
            set
            {
                string newPort = CarPort.ToString();
                int length = newPort.Length;
                string newCarPort = "";
                if (length > 20)
                {
                    for (int i = 0; i <= 20; i++)
                    {
                        newCarPort += newPort[i];
                    }
                    CarPort = Int16.Parse(newCarPort);
                }
                else
                {
                    CarPort = CarPort;
                }
            }
        }

        /// <summary>
        /// Function constructor Car with 3 parameter
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="carName"></param>
        /// <param name="carPort"></param>
        public Car(string carId, string carName, int carPort)
        {
            CarId = carId;
            CarName = carName;
            CarPort = carPort;
        }

        /// <summary>
        /// Function constructor Car with 0 parameter
        /// </summary>
        public Car()
        {
            CarId = "";
            CarName = "";
            CarPort = 0;
        }

        /// <summary>
        /// Function compare car for compare two car
        /// </summary>
        /// <param name="car"></param>
        /// <returns>
        /// 1: CarId already exist
        /// 2: Name of car already exist
        /// 3: Port car already exist
        /// 0: New Car accept
        /// </returns>
        public int CompareCar(Car car)
        {
            if (CarId.Equals(car.CarId)) return 1;
            else
            {
                if (CarName.Equals(car.CarName)) return 2;
                else
                {
                    if (CarPort.Equals(car.CarPort)) return 3;
                }
                return 0;
            }
        }

    }
}
