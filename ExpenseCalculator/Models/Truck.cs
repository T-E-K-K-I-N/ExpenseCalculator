using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpenseCalculator.Models
{
    public class Truck : Car
    {
        private const string _type = "Грузовой автомобиль";

        /// <summary>
        /// Вес груза
        /// </summary>
        [Required(ErrorMessage = "Не указано значение грузоподъемности ТС")]
        [Range(1, 5000, ErrorMessage = "Недопустимое значение")]
        public double LoadCapacity { get; set; }

        public Truck(double averageFuelConsumption, double fuelTankCapacity, double averageSpeed, double remainingFuel, double loadCapacity)
        {
            Type = _type;
            AverageFuelConsumption = averageFuelConsumption;
            FuelTankCapacity = fuelTankCapacity;
            AverageSpeed = averageSpeed;
            RemainingFuel = remainingFuel;
            LoadCapacity = loadCapacity;
        }
    }
}
