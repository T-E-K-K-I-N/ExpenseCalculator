using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpenseCalculator.Models
{
    public class Car
    {
        /// <summary>
        /// Тип транспортного средства
        /// </summary>
        [Required(ErrorMessage = "Не указан тип ТС")]
        public string Type { get; set; }

        /// <summary>
        /// Среднее потребление топлива
        /// </summary>
        [Required(ErrorMessage = "Не указано значение для среднего потребления топлива ТС")]
        [Range(1, 50, ErrorMessage = "Недопустимое значение")]
        public double AverageFuelConsumption { get; set; }

        /// <summary>
        /// Объем топливного бака
        /// </summary>
        [Required(ErrorMessage = "Не указан объем топливного бака ТС")]
        [Range(10, 400, ErrorMessage = "Недопустимое значение")]
        public double FuelTankCapacity { get; set; }

        /// <summary>
        /// Объем оставшегося топлива
        /// </summary>
        [Required(ErrorMessage = "Не указан объем оставшегося топлива")]
        [Range(0, 400, ErrorMessage = "Недопустимое значение")]
        public double RemainingFuel { get; set; }

        /// <summary>
        /// Средняя скорость
        /// </summary>
        [Required(ErrorMessage = "Не указано значение средней скорости ТС")]
        [Range(10, 200, ErrorMessage = "Недопустимое значение")]
        public double AverageSpeed { get; set; }

    }
}
