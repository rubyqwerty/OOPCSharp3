using System;
using System.Collections.Generic;

namespace Lab2_OOP
{
    class InternetOperator
    {
       public static int counterObject = 0;
        public static BaseObject MyOperators = new BaseObject();

        private string nameOfTheOperator = "Не задано"; // название оператора
        private double theCostOfTariff; // цена тарифа
        private double internetSpeed; // Скорость интернета
         private double speedPriceRatio; // Коэффициент выгодны: вычситывается, как скорость интернета / цену тарифа
        private int numberOfUsers; // Количество юзеров
        private string phoneNumberOffice; // Номер телефона офиса
        private int score; // Рейтинг
        private string countryCoverage; // Страна, в которой работает интерент оператор

        // Конструктор по умолчанию
        public InternetOperator()
        {
            nameOfTheOperator = "";
            theCostOfTariff = 0;
            numberOfUsers = 0;
            internetSpeed = 0;
            phoneNumberOffice = "";
            score = 0;
            countryCoverage = "";
            speedPriceRatio = -1;
        }

        // Конструктор с одним параметром
        public InternetOperator(string _NameOfTheOperator)
        {
            NameOfTheOperator = _NameOfTheOperator;
            MyOperators.Push(this);
        }

        // Конструктор с двумя параметрами
        public InternetOperator(double _InternetSpeed, double _TheCostOfTheTariff)
        {
            InternetSpeed = _InternetSpeed;
            TheCostOfTariff = _TheCostOfTheTariff;
            SpeedPriceRatio = _InternetSpeed / _TheCostOfTheTariff;
        }

        // Конструктор с 7 параметрами
        public InternetOperator(string _NameOfTheOperator, double _TheCostOfTheTariff,
            int _NumberOfUsers, double _InternetSpeed, string _PhoneNumberOffice,
            int _Score, string _CountriesCoverage)
        {
            
            NameOfTheOperator = _NameOfTheOperator;
            TheCostOfTariff = _TheCostOfTheTariff;
            NumberOfUsers = _NumberOfUsers;
            InternetSpeed = _InternetSpeed;
            PhoneNumberOffice = _PhoneNumberOffice;
            Score = _Score;
            CountryCoverage = _CountriesCoverage;
            SpeedPriceRatio = _InternetSpeed / _TheCostOfTheTariff;
            if (Contains(this))
                throw new DuplicateObjectException("Объект с таким именем уже есть!", NameOfTheOperator);
            CounterObject++;
            MyOperators.Push(this);
        }

        // Переопределение метода ToString() для вывода всех полей класса
        public override string ToString()
        {
            return $"Имя: {nameOfTheOperator}\n" +
                $"Цена: { theCostOfTariff}\n" +
                $"Количество пользователей: {numberOfUsers}\n" +
                $"Скорость интернета: {internetSpeed}\n" +
                $"Номер офиса: {phoneNumberOffice}\n" +
                $"Рейтинг: {score}\n" +
                $"Покрытие стран:\n{countryCoverage}";
        }

        // Метод, возвращающий значение определенного поля
        public string GetValue(string name)
        {
            switch (name)
            {
                case "NameOfTheOperator":
                    return $"{nameOfTheOperator}";
                case "TheCostOfTheTariff":
                    return $"{theCostOfTariff}";
                case "NumberOfUsers":
                    return $"{numberOfUsers}";
                case "InternetSpeed":
                    return $"{internetSpeed}";
                case "PhoneNumberOffice":
                    return $"{phoneNumberOffice}";
                case "Score":
                    return $"{score}";
                case "CountriesCoverage":
                    return $"{countryCoverage}";
                default:
                    return "";
            }
        }
    

        // Метод, возвращающий числовое поле в 16-ричной форме
        public string GetHexNumber()
        {
            return Convert.ToString(NumberOfUsers, 16);
        }

        // Проврека на уже созданный объект
        public static bool Contains(InternetOperator newObject)
        {
            foreach (InternetOperator Object in MyOperators.Objects)
            {
                if (newObject.nameOfTheOperator.Equals(Object.nameOfTheOperator))
                    return true;
            }
            return false;
        }

        public int NumberOfUsers { get => numberOfUsers; set => numberOfUsers = value; }
        public string PhoneNumberOffice { get => phoneNumberOffice; set => phoneNumberOffice = value; }
        public int Score { get => score; set => score = value; }
        public string CountryCoverage { get => countryCoverage; set => countryCoverage = value; }
        public string NameOfTheOperator { get => nameOfTheOperator; set => nameOfTheOperator = value; }
        public double TheCostOfTariff
        {
            get => theCostOfTariff;
            set
            {
                if (value == 0)
                    throw new InternetOperatorException("Встречено деление на 0!\n" +
                        "Коэфициент выгоды = скорость тарифа / цена тарифа" , "theCostOfTariff");
                theCostOfTariff = value;
                speedPriceRatio = InternetSpeed / value;
            }
        }
        public double InternetSpeed
        {
            get => internetSpeed;
            set
            {
                internetSpeed = value;
                speedPriceRatio = value / TheCostOfTariff;
            }
        }
        public double SpeedPriceRatio
        {
            get => speedPriceRatio;
            set => speedPriceRatio = value;
        }
        public static int CounterObject { get => counterObject; private set => counterObject = value; }
    }
}
