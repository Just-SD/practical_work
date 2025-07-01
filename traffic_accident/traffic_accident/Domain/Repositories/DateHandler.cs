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
    }
}
