using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpenseCalculator.Models
{
    public class SportCar : Car
    {
        private const string _type = "Спортивный автомобиль";

        public SportCar(double averageFuelConsumption, double fuelTankCapacity, double averageSpeed, double remainingFuel)
        {
            Type = _type;
            AverageFuelConsumption = averageFuelConsumption;
            FuelTankCapacity = fuelTankCapacity;
            AverageSpeed = averageSpeed;
            RemainingFuel = remainingFuel;
        }

    }
}
