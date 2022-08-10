using ExpenseCalculator.Validators;
using ExpenseCalculator.Models;
using ExpenseCalculator.Calculators;

namespace ExpenseCalculator
{
    public partial class Calculator : Form
    {
        /// <summary>
        /// Константы для цветов полей
        /// </summary>
        private Color errorColor = Color.Coral;
        private Color errorFreeColor = Color.Aquamarine;

        /// <summary>
        /// Объект класса для валидации
        /// </summary>
        CarValidator validator = new CarValidator();

        public Calculator()
        {
            InitializeComponent();
        }


        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            DistanceCalculator distanceCalculator = new DistanceCalculator();
            TimeCalculator timeCalculator = new TimeCalculator();
            double distance = 0;
            double time = 0;
            bool replacingTheDistance = false;

            bool check = CheckingFields();
            if (check is true)
            {
                // Преобразуем данные из текстовых полей
                double averageFuelConsumption = Convert.ToDouble(textBox1.Text);
                double fuelTankCapacity = Convert.ToDouble(textBox2.Text);
                double remainingFuel = Convert.ToDouble(textBox6.Text);
                double averageSpeed = Convert.ToDouble(textBox3.Text);

                // Если флаг установлен в значение "Легковое ТС"
                if (radioButtonPassengerCar.Checked is true) 
                {
                    PassengerCar car;

                    // Преобразуем данные из текстового поля
                    ushort numberOfPassengerSeats = Convert.ToUInt16(textBox5.Text);

                    // Создаем объект ТС с учетом валидации
                    car = validator.PassengerCarCreator(averageFuelConsumption, fuelTankCapacity, 
                        averageSpeed, remainingFuel, numberOfPassengerSeats);

                    // Если флаг установлен на вычисление дистанции
                    if (radioButtonDistance.Checked is true)
                    {
                        // Вычилсяем дистанцию с учетом запаса хода
                        distance = distanceCalculator.CalculateDistance(car);

                        // Выводим полученную дистанцию
                        textBox7.Text = distance.ToString();
                    }

                    // Если флаг установлен на вычисление времени, которое ТС затратит на указанную дистанцию
                    else if (radioButtonTime.Checked is true)
                    {
                        // Преобразуем данные из текстового поля
                        double setDistance = Convert.ToDouble(textBoxDistance.Text);

                        // Вычисляем время за которое ТС пройдет нужную дистанцию
                        // Возвращаем два значения: время и булевое значение того, происходила ли замена дистанции в методе
                        timeCalculator.CalculateTime(car, setDistance, out time, out replacingTheDistance);

                        // Если происходила замена дистанции в методе
                        if (replacingTheDistance)
                        {
                            MessageBox.Show("Заданная дистанция больше той, которую может пройти ТС с учетом запаса хода!" +
                                "\nРасчет времени ТС в пути производился с учетом этого нюанса!", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Выводим полученное значение 
                        textBox7.Text = time.ToString();
                    }
                }
                else if (radioButtonTruck.Checked is true)
                {
                    Truck car;
                    double loadCapacity = Convert.ToDouble(textBox4.Text);
                    car = validator.TruckCreator(averageFuelConsumption, fuelTankCapacity, 
                        averageSpeed, remainingFuel, loadCapacity);


                    if (radioButtonDistance.Checked is true)
                    {
                        distance = distanceCalculator.CalculateDistance(car);

                        textBox7.Text = distance.ToString();
                    }
                    else if(radioButtonTime.Checked is true)
                    {
                        double setDistance = Convert.ToDouble(textBoxDistance.Text);
                        timeCalculator.CalculateTime(car, setDistance, out time, out replacingTheDistance);

                        if (replacingTheDistance)
                        {
                            MessageBox.Show("Заданная дистанция больше той, которую может пройти ТС с учетом запаса хода!" +
                                "\nРасчет времени ТС в пути производился с учетом этого нюанса!", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        textBox7.Text = time.ToString();
                    }
                }
                else if (radioButtonSportCar.Checked is true)
                {
                    SportCar car;
                    car = validator.SportCarCreator(averageFuelConsumption, fuelTankCapacity, 
                        averageSpeed, remainingFuel);

                    if (radioButtonDistance.Checked is true)
                    {
                        distance = distanceCalculator.CalculateDistance(car);

                        textBox7.Text = distance.ToString();
                    }
                    else if (radioButtonTime.Checked is true)
                    {
                        double setDistance = Convert.ToDouble(textBoxDistance.Text);
                        timeCalculator.CalculateTime(car, setDistance, out time, out replacingTheDistance);

                        if(replacingTheDistance)
                        {
                            MessageBox.Show("Заданная дистанция больше той, которую может пройти ТС с учетом запаса хода!" +
                                "\nРасчет времени ТС в пути производился с учетом этого нюанса!", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        textBox7.Text = time.ToString();
                    }
                }
            }
        }


        /// <summary>
        /// Функция проверки на пустые поля
        /// </summary>
        private bool CheckingFields()
        {
            if ((textBox1.Text is "" || textBox1.Text is "от 1 до 50" || textBox1.Text is ",") 
                || (textBox2.Text is "" || textBox2.Text is "от 10 до 400" || textBox2.Text is ",") 
                || (textBox3.Text is "" || textBox3.Text is "от 10 до 200" || textBox3.Text is ",")
                || (textBox6.Text is "" || textBox6.Text is "не меньше 0" || textBox6.Text is "," ))
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return false;
            }
            else
            {
                if (radioButtonTruck.Checked is true)
                {
                    if (textBox4.Text is "" || textBox4.Text is "от 1 до 5000" || textBox4.Text is ",")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (radioButtonPassengerCar.Checked is true)
                {
                    if (textBox5.Text is "" || textBox5.Text is "от 1 до 4")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                return true;

            }
        }


        #region Автозамена значений / подсветка верных значений
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != ",")
            {
                // Преобразуем данные из текстового поля
                double averageFuelConsumption = Convert.ToDouble(textBox1.Text);
                // Проверяем на условие
                if (averageFuelConsumption < 1)
                {
                    textBox1.Text = "1";
                }
                else if (averageFuelConsumption > 50)
                {
                    textBox1.Text = "50";
                }
                //Выставляем цвет фона поля
                else { textBox1.BackColor = errorFreeColor; }
            }
            else
            {
                textBox1.Text = "от 1 до 50"; //подсказка
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != ",")
            {
                double fuelTankCapacity = Convert.ToDouble(textBox2.Text);
                if (fuelTankCapacity < 10)
                {
                    textBox2.Text = "10";
                }
                else if (fuelTankCapacity > 400)
                {
                    textBox2.Text = "400";
                }
                else { textBox2.BackColor = errorFreeColor; }
            }
            else
            {
                textBox2.Text = "от 10 до 400"; //подсказка
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox3.Text != ",")
            {
                double averageSpeed = Convert.ToDouble(textBox3.Text);
                if (averageSpeed < 10 )
                {
                    textBox3.Text = "10";
                }
                else if (averageSpeed > 200)
                {
                    textBox3.Text = "200";
                }
                else { textBox3.BackColor = errorFreeColor; }
            }
            else
            {
                textBox3.Text = "от 10 до 200";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox4.Text != ",")
            {
                double loadCapacity = Convert.ToDouble(textBox4.Text);
                if (loadCapacity < 1)
                {
                    textBox4.Text = "1";
                }
                else if (loadCapacity > 5000)
                {
                    textBox4.Text = "5000";
                }
                else { textBox4.BackColor = errorFreeColor; }
            }
            else
            {
                textBox4.Text = "от 1 до 5000";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                ushort numberOfPassengerSeats = Convert.ToUInt16(textBox5.Text);
                if (numberOfPassengerSeats < 1 )
                {
                    textBox4.Text = "1";
                }
                else if (numberOfPassengerSeats > 4)
                {
                    textBox4.Text = "4";
                }
                else { textBox4.BackColor = errorFreeColor; }
            }
            else
            {
                textBox5.Text = "от 1 до 4";
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox6.Text != ",")
            {
                double fuelTankCapacity = Convert.ToDouble(textBox2.Text);
                double remainingFuel = Convert.ToDouble(textBox6.Text);
                if (remainingFuel < 0)
                {
                    textBox6.Text = "0";
                }
                else if ( remainingFuel > fuelTankCapacity)
                {
                    textBox6.Text = fuelTankCapacity.ToString(); 
                }
                else { textBox6.BackColor = errorFreeColor; }
            }
            else
            {
                textBox6.Text = "не меньше 0"; //подсказка
                textBox6.ForeColor = Color.Gray;
            }
        }

        #endregion

        #region Ввод с клавиатуры в текстовые поля
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если вводимый символ с клавиутуры число или клавиша BackSpace
            if (!(e.KeyChar <= 47 || e.KeyChar >= 58) || 
                (e.KeyChar == '\b') || (e.KeyChar == 44))
            {
                // Выходим
                return;
            }
            // Запрещаем ввод символа
            else { e.Handled = true; }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= 47 || e.KeyChar >= 58) || 
                (e.KeyChar == '\b') || (e.KeyChar == 44))
            {
                return;
            }
            else { e.Handled = true; }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= 47 || e.KeyChar >= 58) || 
                (e.KeyChar == '\b') || (e.KeyChar == 44))
            {
                return;
            }
            else { e.Handled = true; }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= 47 || e.KeyChar >= 58) ||
                (e.KeyChar == '\b') || (e.KeyChar == 44))
            {
                return;
            }
            else { e.Handled = true; }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= 47 || e.KeyChar >= 58) || 
                (e.KeyChar == '\b'))
            {
                return;
            }
            else { e.Handled = true; }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= 47 || e.KeyChar >= 58) ||
                (e.KeyChar == '\b') || (e.KeyChar == 44))
            {
                return;
            }
            else { e.Handled = true; }
        }

        #endregion

        #region Активность полей
        private void radioButtonPassengerCar_CheckedChanged(object sender, EventArgs e)
        {
            // Меняем активность текстбоксов
            textBox4.Enabled = false;
            textBox5.Enabled = true;
        }

        private void radioButtonTruck_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox4.Enabled = true;
        }

        private void radioButtonSportCar_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void radioButtonDistance_CheckedChanged(object sender, EventArgs e)
        {

           // Устанавливаем видимость лейблов 
            labelTextLeft.Visible = true;
            labelTextRight.Visible = true;
            labelDistance.Visible = false;
            textBoxDistance.Visible = false;

            // Переводим текстбокс в неактивное состояние
            textBoxDistance.Enabled = false;

            // Очищаем текстбокс
            textBox7.Text = "";

            // Устанавливаем текст в лейблы
            labelTextLeft.Text = "ТС пройдет\n " +
                "растояние равное: ";
            labelTextRight.Text = "КМ.";
        }

        private void radioButtonTime_CheckedChanged(object sender, EventArgs e)
        {

            labelTextLeft.Visible = true;
            labelTextRight.Visible = true;
            labelDistance.Visible = true;
            textBoxDistance.Visible = true;

            textBoxDistance.Enabled = true;

            textBox7.Text = "";

            labelTextLeft.Text = "ТС будет в пути: ";
            labelTextRight.Text = "Ч.";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "от 10 до 400" && textBox2.Text != "")
            {
                textBox6.Enabled = true;
            }
            else
            {
                textBox6.Enabled = false;
            }
        }

        #endregion

        #region Подсказки текстовых полей
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "от 1 до 50")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "от 10 до 400")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "от 10 до 200")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "от 1 до 5000")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "от 1 до 4")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "не меньше 0")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            // Загружаем наши подсказки в текстовые поля

            textBox1.Text = "от 1 до 50"; 
            textBox1.ForeColor = Color.Gray;

            textBox2.Text = "от 10 до 400"; 
            textBox2.ForeColor = Color.Gray;

            textBox3.Text = "от 10 до 200";
            textBox3.ForeColor = Color.Gray;

            textBox4.Text = "от 1 до 5000";
            textBox4.ForeColor = Color.Gray;

            textBox5.Text = "от 1 до 4";
            textBox5.ForeColor = Color.Gray;

            textBox6.Text = "не меньше 0";
            textBox6.ForeColor = Color.Gray;
        }



        #endregion


    
    }
}