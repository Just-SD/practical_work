using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace traffic_accident.models
{
    class CarNumbers : IEnumerable
    {
        private List<string> carNumbers;

        public CarNumbers() => carNumbers = new List<string>();

        string this[int index]
        {
            get => carNumbers[index];
        }

        public void Add(string value)
        {
            if (!Regex.IsMatch(value, @"^[АВЕКМНОРСТУХ]{1}\d{3}[АВЕКМНОРСТУХ]{2}\d{2,3}$"))
                throw new ArgumentException("Получен неверный номер автомобиля.");
            carNumbers.Add(value);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (string number in carNumbers)
                yield return number;
        }
    }
}
