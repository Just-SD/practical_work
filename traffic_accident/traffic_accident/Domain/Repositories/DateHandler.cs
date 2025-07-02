using Npgsql;

namespace traffic_accident.Domain.Repositories
{
    internal static class DateHandler
    {
        private static string connectPath = "Host=localhost;Port=5432;Database=practical_work;Username=postgres;Password=1234";
        private static NpgsqlConnection connection;

        static DateHandler() => connection = new NpgsqlConnection(connectPath);

        public static DateTime GetEarliestDateTrafficAccident()
        {
            var sqlRequest = "SELECT date FROM traffic_accidents ta ORDER BY date LIMIT 1";
            DateTime date;

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                var result = command.ExecuteScalar();
                if (result == null)
                    throw new NullReferenceException("Значение не найдено.");
                DateTime.TryParse(result.ToString(), out date);
            }

            connection.Close();
            return date;
        }

        public static List<int> GetAvailableYears()
        {
            List<int> availableYears = new();

            string sqlRequest = "SELECT date_part('year', date) FROM traffic_accidents " +
                "GROUP BY date_part('year', date) " +
                "ORDER BY date_part('year', date)";

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        availableYears.Add((int)reader.GetDouble(0));
                    }
                }
            }

            connection.Close();
            return availableYears;
        }
    }
}
