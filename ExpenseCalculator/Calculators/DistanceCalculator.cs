using ExpenseCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseCalculator.Calculators
{
    public class DistanceCalculator
    {
        /// <summary>
        /// Методы подсчета дистанции, которое способно проехать ТС с учетом различных переменных
        /// </summary>
         public double CalculateDistance(PassengerCar car)
         {
            double distance = 0;
            double percent = 0;

            percent = car.NumberOfPassengerSeats * 6;

            if (percent >= 100)
            {
                distance = 0;
                return distance;
            }
            else 
            {
                distance = (100 * car.RemainingFuel) / car.AverageFuelConsumption;
                distance = distance - (distance * 0.01 * percent);

                return distance;
            }
            
        }

        public double CalculateDistance(Truck car)
        {
            double distance = 0;
            double percent = 0;

            percent = (car.LoadCapacity / 200) * 4;

            distance = (100 * car.RemainingFuel) / car.AverageFuelConsumption;
            distance = distance - (distance * 0.01 * percent);

            return distance;
        }

        public double CalculateDistance(SportCar car)
        {
            double distance = 0;

            distance = (100 * car.RemainingFuel) / car.AverageFuelConsumption;

            return distance;
        }

    }
}
