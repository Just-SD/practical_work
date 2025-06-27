using traffic_accident.DataBase;
using traffic_accident.models;

namespace traffic_accident
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*TrafficAccident traffic = new TrafficAccident();
            traffic.TypeId = 1;
            traffic.TypeDescription = null;
            traffic.Date = "2025.05.30";
            traffic.CarNumber = "Н715СО18";
            traffic.SeriesDrivingLicense = 9541;
            traffic.NumberDrivingLicense = 573174;
            traffic.IsMultipleParticipants = true;
            traffic.CarNumbers.Add("Р888РР18");
            traffic.CauseId = 1;
            traffic.SubcauseId = 11;
            traffic.CauseDescription = "Водитель не уступил дорогу";
            traffic.AddressTrafficAccident = "г. Ижевск; ул. 30 лет Победы; ул. 6-я Подлесная";
            traffic.OutsideLocality = false;
            traffic.AtCrossroads = true;
            traffic.OnStreet = false;
            int id = TrafficAccidentHandler.AddInDataBase(traffic);*/

            var trafficAccidents = TrafficAccidentHandler.GetAllTrafficAccidents();

            Console.WriteLine();
        }
    }
}
