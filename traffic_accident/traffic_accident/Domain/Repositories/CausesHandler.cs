using Npgsql;
using traffic_accident.Domain.Models;

namespace traffic_accident.Domain.Repositories
{
    internal static class CausesHandler
    {
        private static string connectPath = "Host=localhost;Port=5432;Database=practical_work;Username=postgres;Password=1234";
        private static NpgsqlConnection connection;

        static CausesHandler() => connection = new NpgsqlConnection(connectPath);

        public static string GetCauseName(TrafficAccident trafficAccident)
        {
            var causeId = trafficAccident.CauseId;
            var subcauseId = trafficAccident.SubcauseId;
            var sqlRequest = $"SELECT * FROM causes_of_traffic_accidents WHERE id = {causeId}";
            string causeName = string.Empty;

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();

                    causeName = reader.GetString(1);

                    if (subcauseId != null)
                    {
                        string tableSubcauseName = reader.GetString(3);
                        causeName += $".\r\n{GetSubcauseName(tableSubcauseName, (int)subcauseId)}";
                    }
                }
            }

            connection.Close();
            return causeName;
        }

        private static string GetSubcauseName(string tableSubcauseName, int subcauseId)
        {
            NpgsqlConnection localConnection = new NpgsqlConnection(connectPath);
            string subcauseName = string.Empty;
            string sqlRequest = $"SELECT name FROM {tableSubcauseName} WHERE id = {subcauseId}";
            localConnection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, localConnection))
            {
                var result = command.ExecuteScalar();
                if (result == null)
                    throw new NullReferenceException("Значение не найдено.");
                subcauseName = result.ToString();
            }

            connection.Close();
            return subcauseName;
        }
    }
}
