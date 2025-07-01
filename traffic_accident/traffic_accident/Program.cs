using traffic_accident.Forms;

namespace traffic_accident
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StartFrom());
        }
        /*static void Main()
        {
            *//*TrafficAccident traffic = new TrafficAccident();
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
            int id = TrafficAccidentHandler.AddInDataBase(traffic);*//*

            var trafficAccidents = TrafficAccidentHandler.GetAllTrafficAccidents();

            Console.WriteLine();
        }*/
    }
}
