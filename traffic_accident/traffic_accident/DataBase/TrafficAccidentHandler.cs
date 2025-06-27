using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_accident.models;
using Npgsql;
using NpgsqlTypes;
using System.Dynamic;
using System.Net.Http.Headers;

namespace traffic_accident.DataBase
{
    internal class TrafficAccidentHandler : ITrafficAccidentHandler
    {
        private static string connectPath = "Host=localhost;Port=5432;Database=practical_work;Username=postgres;Password=1234";
        private static NpgsqlConnection connection;

        static TrafficAccidentHandler() => connection = new NpgsqlConnection(connectPath);

        public static int AddInDataBase(TrafficAccident trafficAccident)
        {
            StringBuilder sb = new StringBuilder();
            int outputId;

            sb.Append("INSERT INTO traffic_accidents" +
                "(type_id, type_description, date, car_number," +
                "series_driving_license, number_driving_license, " +
                "is_multiple_participants, car_numbers, cause_id, " +
                "subcause_id, cause_description, address_traffic_accident, " +
                "outside_locality, at_crossroads, on_street) VALUES (");

            sb.Append(trafficAccident.TypeId + ",");
            if (trafficAccident.TypeDescription == null)
                sb.Append("NULL,");
            else
                sb.Append($"'{trafficAccident.TypeDescription}',");
            sb.Append($"'{trafficAccident.Date}',");
            sb.Append($"'{trafficAccident.CarNumber}',");
            sb.Append(trafficAccident.SeriesDrivingLicense + ",");
            sb.Append(trafficAccident.NumberDrivingLicense + ",");
            sb.Append(trafficAccident.IsMultipleParticipants.ToString() + ",");
            if (trafficAccident.IsMultipleParticipants)
            {
                sb.Append("ARRAY[");
                foreach (string carNumber in trafficAccident.CarNumbers)
                {
                    sb.Append($"'{carNumber}',");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("],");
            }
            else
                sb.Append("NULL,");
            sb.Append(trafficAccident.CauseId + ",");
            sb.Append(trafficAccident.SubcauseId + ",");
            if (trafficAccident.CauseDescription == null)
                sb.Append("NULL,");
            else
                sb.Append($"'{trafficAccident.CauseDescription}',");
            sb.Append($"'{trafficAccident.AddressTrafficAccident}',");

            var flags = new[] { trafficAccident.OutsideLocality, trafficAccident.AtCrossroads, trafficAccident.OnStreet };
            foreach (var flag in flags)
                sb.Append(flag.ToString().ToUpper() + ",");
            sb.Remove(sb.Length - 1, 1);

            sb.Append(") RETURNING id;");

            string sqlRequest = sb.ToString();
            sb.Clear();

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                var result = command.ExecuteScalar();
                if (result == null)
                    throw new NullReferenceException("Не удалось сохранить объект.");
                outputId = int.Parse(result.ToString());
            }

            connection.Close();
            return outputId;
        }

        // не реализован, так как пока не используется
        public static TrafficAccident GetTrafficAccident(int id)
        {
            connection.Open();

            /*using (var command = new NpgsqlCommand($"SELECT * FROM traffic_accidents WHERE id = {id}", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);

                        int cityId = reader.GetInt32(1);
                        City city = new City(cityId, GetNameToId("citys", cityId));

                        int brandId = reader.GetInt32(2);
                        Brand brand = new Brand(brandId, GetNameToId("brands", brandId));

                        int modelId = reader.GetInt32(3);
                        Domain.Model model = new Domain.Model(modelId, brand, GetNameToId("models", modelId));

                        var temp = reader.GetFieldValue<NpgsqlRange<int>>(4);
                        NpgsqlRange<int> releaseYearRange = new NpgsqlRange<int>(temp.LowerBound, temp.UpperBound - 1);

                        temp = reader.GetFieldValue<NpgsqlRange<int>>(5);
                        NpgsqlRange<int> enginePowerRange = new NpgsqlRange<int>(temp.LowerBound, temp.UpperBound - 1);

                        string gearShiftBoxType = reader.GetString(6);
                        string condition = reader.GetString(7);

                        temp = reader.GetFieldValue<NpgsqlRange<int>>(8);
                        NpgsqlRange<int> priceRange = new NpgsqlRange<int>(temp.LowerBound, temp.UpperBound - 1);

                        yield return new Client(city, brand, model, releaseYearRange,
                            enginePowerRange, gearShiftBoxType, condition, priceRange, true, id);
                    }
                }
            }*/

            throw new NotImplementedException();
        }

        public static List<TrafficAccident> GetAllTrafficAccidents()
        {
            List<TrafficAccident> trafficAccidents = new List<TrafficAccident>();
            connection.Open();

            using (var command = new NpgsqlCommand($"SELECT * FROM traffic_accidents", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TrafficAccident trafficAccident = new TrafficAccident();

                        trafficAccident.Id = reader.GetInt32(0);
                        trafficAccident.TypeId = reader.GetInt32(1);
                        trafficAccident.TypeDescription = reader.GetValue(2) as string;
                        trafficAccident.Date = reader.GetValue(3).ToString().Split(' ')[0];
                        trafficAccident.CarNumber = reader.GetString(4);
                        trafficAccident.SeriesDrivingLicense = reader.GetInt32(5);
                        trafficAccident.NumberDrivingLicense = reader.GetInt32(6);

                        trafficAccident.IsMultipleParticipants = reader.GetBoolean(7);
                        if (trafficAccident.IsMultipleParticipants)
                        {
                            string[] numbers = (string[])reader.GetValue(8);
                            foreach (string number in numbers)
                                trafficAccident.CarNumbers.Add(number);
                        }

                        trafficAccident.CauseId = reader.GetInt32(9);
                        trafficAccident.SubcauseId = reader.GetInt32(10) as Int32?;
                        trafficAccident.CauseDescription = reader.GetValue(11) as string;
                        trafficAccident.AddressTrafficAccident = reader.GetString(12);
                        trafficAccident.OutsideLocality = reader.GetBoolean(13);
                        trafficAccident.AtCrossroads = reader.GetBoolean(14);
                        trafficAccident.OnStreet= reader.GetBoolean(15);

                        trafficAccidents.Add(trafficAccident);
                    }
                }
            }

            connection.Close();

            return trafficAccidents;
        }
    }
}
