using traffic_accident.Domain.Models;

namespace traffic_accident.DataBase
{
    internal interface ITrafficAccidentHandler
    {
        public static abstract int AddInDataBase(TrafficAccident trafficAccident);
        public static abstract TrafficAccident GetTrafficAccident(int id);
        public static abstract List<TrafficAccident> GetAllTrafficAccidents();
    }
}
