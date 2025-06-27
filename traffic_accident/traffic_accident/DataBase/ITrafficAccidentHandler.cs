using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_accident.models;

namespace traffic_accident.DataBase
{
    internal interface ITrafficAccidentHandler
    {
        public static abstract int AddInDataBase(TrafficAccident trafficAccident);
        public static abstract TrafficAccident GetTrafficAccident(int id);
        public static abstract List<TrafficAccident> GetAllTrafficAccidents();
    }
}
