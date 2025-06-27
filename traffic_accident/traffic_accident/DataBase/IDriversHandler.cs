using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_accident.models;

namespace traffic_accident.DataBase
{
    internal interface IDriversHandler
    {
        public static abstract int AddInDataBase(Driver driver);
        public static abstract Driver GetDriverById(int id);
        public static abstract Driver GetDriverByDrivingLicense(int series, int number);
    }
}
