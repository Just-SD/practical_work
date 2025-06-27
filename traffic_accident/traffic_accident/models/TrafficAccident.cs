using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace traffic_accident.models
{
    class TrafficAccident
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string? TypeDescription { get; set; }

        private DateTime date;
        public string? Date
        {
            get => date.Date.ToString();
            set
            {
                DateTime result;

                if (value == null)
                    throw new NullReferenceException("Дата не получена.");
                else if (!DateTime.TryParse(value, out result))
                    throw new ArgumentException("Полученное значение не является датой.");

                if (result > DateTime.Now)
                    throw new ArgumentException("Получена неверная дата аварии.");
                date = result;
            }
        }

        private string carNumber;
        public string CarNumber
        {
            get => carNumber;
            set
            {
                if (!Regex.IsMatch(value, @"^[АВЕКМНОРСТУХ]{1}\d{3}[АВЕКМНОРСТУХ]{2}\d{2,3}$"))
                    throw new ArgumentException("Получен неверный номер автомобиля.");
                carNumber = value;
            }
        }

        private int seriesDrivingLicense;
        public int SeriesDrivingLicense
        {
            get => seriesDrivingLicense;
            set
            {
                if (value < 1000 || value > 9999)
                    throw new ArgumentException("Получено неверное значение серии водительского удостоверения.");
                seriesDrivingLicense = value;
            }
        }

        private int numberDrivingLicense;
        public int NumberDrivingLicense
        {
            get => numberDrivingLicense;
            set
            {
                if (value < 100000 || value > 999999)
                    throw new ArgumentException("Получено неверное значение номера водительского удостоверения.");
                numberDrivingLicense = value;
            }
        }
        public bool IsMultipleParticipants { get; set; }
        public CarNumbers CarNumbers { get; private set; }
        public int CauseId { get; set; }
        public int? SubcauseId { get; set; }
        public string? CauseDescription { get; set; }
        public string AddressTrafficAccident { get; set; }
        public bool OutsideLocality { get; set; }
        public bool AtCrossroads { get; set; }
        public bool OnStreet { get; set; }

        public TrafficAccident() => CarNumbers = new CarNumbers();
    }
}