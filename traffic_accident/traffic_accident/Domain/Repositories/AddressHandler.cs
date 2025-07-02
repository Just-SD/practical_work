using Npgsql;

namespace traffic_accident.Domain.Repositories
{
    internal static class AddressHandler
    {
        private static string connectPath = "Host=localhost;Port=5432;Database=practical_work;Username=postgres;Password=1234";
        private static NpgsqlConnection connection;

        static AddressHandler() => connection = new NpgsqlConnection(connectPath);

        public static List<string> GetDangerousPlacesInYear(int year)
        {
            List<string> dangerousPlaces = new();
            var sqlRequest = $"SELECT address_traffic_accident FROM get_accident_count_on_place_in_year({year});";

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dangerousPlaces.Add(reader.GetString(0));
                    }
                }
            }

            connection.Close();
            return dangerousPlaces;
        }
    }
}
