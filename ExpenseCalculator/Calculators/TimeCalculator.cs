using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseCalculator.Models;

namespace ExpenseCalculator.Calculators
{
    public class TimeCalculator
    {
        DistanceCalculator calculator = new DistanceCalculator();
        /// <summary>
        /// Методы подсчета времени, за которое ТС проедет заданное растояние
        /// </summary>
        public void CalculateTime(PassengerCar car, double distance, out double time, out bool replacingTheDistance)
        {
            double possibleDistance = calculator.CalculateDistance(car);

            if (distance > possibleDistance)
            {
                time = possibleDistance / car.AverageSpeed;
                replacingTheDistance = true;
            }
            else
            {
                time = distance / car.AverageSpeed;
                replacingTheDistance = false;
            }
        }

        public void CalculateTime(Truck car, double distance, out double time, out bool replacingTheDistance)
        {
            double possibleDistance = calculator.CalculateDistance(car);

            if (distance > possibleDistance)
            {
                time = possibleDistance / car.AverageSpeed;
                replacingTheDistance = true;
            }
            else
            {
                time = distance / car.AverageSpeed;
                replacingTheDistance = false;
            }
        }

        public void CalculateTime(SportCar car, double distance, out double time, out bool replacingTheDistance)
        {
            double possibleDistance = calculator.CalculateDistance(car);

            if (distance > possibleDistance)
            {
                time = possibleDistance / car.AverageSpeed;
                replacingTheDistance = true;
            }
            else
            {
                time = distance / car.AverageSpeed;
                replacingTheDistance = false;
            }
        }
    }
}
