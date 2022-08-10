using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ExpenseCalculator.Models;

namespace ExpenseCalculator.Validators
{
    /// <summary>
    /// Класс для валидации данных ТС
    /// </summary>
    public class CarValidator 
    {
       /// <summary>
       /// Функция создания объекта грузового ТС с валидацией данных
       /// </summary>
       public Truck TruckCreator(double averageFuelConsumption, double fuelTankCapacity,
           double averageSpeed, double remainingFuel, double loadCapacity)
        {
            Truck car = new Truck(averageFuelConsumption, fuelTankCapacity, 
                averageSpeed, remainingFuel, loadCapacity);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(car);

            if(!Validator.TryValidateObject(car, context, results))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage,"Ошибка создания объекта ТС", 
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                return null;
            }
            else
            {
                return car;
            }
        }

        /// <summary>
        /// Функция создания объекта легкового ТС с валидацией данных
        /// </summary>
        public PassengerCar PassengerCarCreator(double averageFuelConsumption, double fuelTankCapacity,
            double averageSpeed, double remainingFuel, ushort numberOfPassengerSeats)
        {
            PassengerCar car = new PassengerCar(averageFuelConsumption, fuelTankCapacity,
                averageSpeed, remainingFuel, numberOfPassengerSeats);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(car);

            if (!Validator.TryValidateObject(car, context, results))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage, "Ошибка создания объекта ТС",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                return null;
            }
            else
            {
                return car;
            }
        }

        /// <summary>
        /// Функция создания объекта легкового ТС с валидацией данных
        /// </summary>
        public SportCar SportCarCreator(double averageFuelConsumption, double fuelTankCapacity,
            double averageSpeed, double remainingFuel)
        {
            SportCar car = new SportCar(averageFuelConsumption, fuelTankCapacity,
                averageSpeed, remainingFuel);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(car);

            if (!Validator.TryValidateObject(car, context, results))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage, "Ошибка создания объекта ТС",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                return null;
            }
            else
            {
                return car;
            }
        }



    }
}
