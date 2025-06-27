using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.Text.RegularExpressions;
using Npgsql.Internal;

namespace traffic_accident.models
{
    internal class Driver
    {
        private int series;
        public int Series
        {
            get => series;
            set
            {
                if (value < 1000 || value > 9999)
                    throw new ArgumentException("Получено неверное значение серии водительского удостоверения.");
                series = value;
            }
        }

        private int number;
        public int Number
        {
            get => number;
            set
            {
                if (value < 100000 || value > 999999)
                    throw new ArgumentException("Получено неверное значение номера водительского удостоверения.");
                number = value;
            }
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        
        // TODO переделать обработку дат как для аварий
        private DateTime dateBirth;
        public DateTime DateBirth
        {
            get => dateBirth;
            set
            {
                DateTime minAge = new DateTime(DateTime.Now.Year - 16, DateTime.Now.Month, DateTime.Now.Day);

                if (value < minAge)
                    throw new ArgumentException("Получена неверная дата рождения водителя.");
                dateBirth = value;
            }
        }
        public string Address { get; set; }

        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if(!Regex.IsMatch(value, @"^8-9\d{2}-\d{3}-\d{2}-\d{2}$"))
                    throw new ArgumentException("Получен неверный номер телефона водителя.");
                phoneNumber = value;
            }
        }
        public Categories Categories { get; private set; }
        // TODO переделать обработку дат как для аварий
        private DateTime dateIssue;
        public DateTime DateIssue
        {
            get => dateIssue;
            set
            {
                DateTime timeAction = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);

                if (value < timeAction || value > DateTime.Now)
                    throw new ArgumentException
                        ("Получена неверная дата получения водительского удостоверения," +
                        "или срок действия водительского удостоверения истёк.");
                DateIssue = value;
            }
        }

        public Driver() => Categories = new Categories();
    }
}
