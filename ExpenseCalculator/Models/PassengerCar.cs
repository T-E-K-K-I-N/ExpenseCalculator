using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpenseCalculator.Models
{
    public class PassengerCar : Car
    {
        private const string _type = "Легковой автомобиль";

        /// <summary>
        /// Количество пассажирских мест
        /// </summary>
        [Range(1, 4, ErrorMessage = "Недопустимое значение")]
        public ushort NumberOfPassengerSeats { get; set; }

        public PassengerCar(double averageFuelConsumption, double fuelTankCapacity, double averageSpeed, double remainingFuel, ushort numberOfPassengerSeats)
        {
            Type = _type;
            AverageFuelConsumption = averageFuelConsumption;
            FuelTankCapacity = fuelTankCapacity;
            AverageSpeed = averageSpeed;
            RemainingFuel = remainingFuel;
            NumberOfPassengerSeats = numberOfPassengerSeats;
        }
    }
}
