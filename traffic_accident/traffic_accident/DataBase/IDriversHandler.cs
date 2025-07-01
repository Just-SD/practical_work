using traffic_accident.Domain.Models;

namespace traffic_accident.DataBase
{
    internal interface IDriversHandler
    {
        public static abstract int AddInDataBase(Driver driver);
        public static abstract Driver GetDriverById(int id);
        public static abstract Driver GetDriverByDrivingLicense(int series, int number);
    }
}
