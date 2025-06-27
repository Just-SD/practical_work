using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace traffic_accident.models
{
    class Categories
    {
        private static string[] availableCategories;

        private List<string> categories;

        static Categories()
        {
            availableCategories = new[]
            {
                "A", "A1", "B", "B1", "C", "C1", "D", "D1",
                "BE", "CE", "C1E", "DE", "D1E", "M", "Tm", "Tb"
            };
        }

        public Categories() => categories = new List<string>();

        string this[int index]
        {
            get => categories[index];

            set
            {
                if (!availableCategories.Contains(value))
                    throw new Exception();
                categories[index] = value;
            }
        }

        public void Add(string value)
        {
            if (!availableCategories.Contains(value))
                throw new Exception();
            categories.Add(value);
        }
    }
}
