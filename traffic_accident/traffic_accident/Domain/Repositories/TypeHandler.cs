using Npgsql;
using traffic_accident.Domain.Models;

namespace traffic_accident.Domain.Repositories
{
    internal static class TypeHandler
    {
        private static string connectPath = "Host=localhost;Port=5432;Database=practical_work;Username=postgres;Password=1234";
        private static NpgsqlConnection connection;

        static TypeHandler() => connection = new NpgsqlConnection(connectPath);

        public static string GetTypeName(TrafficAccident trafficAccident)
        {
            var typeId = trafficAccident.TypeId;
            var sqlRequest = $"SELECT name FROM types_of_traffic_accident WHERE id = {typeId}";
            string typeName = string.Empty;

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                var result = command.ExecuteScalar();
                if (result == null)
                    throw new NullReferenceException("Значение не найдено.");
                typeName = result.ToString();
            }

            connection.Close();
            return typeName;
        }

        public static string GetTypeNameToId(int id)
        {
            var sqlRequest = $"SELECT name FROM types_of_traffic_accident WHERE id = {id}";
            string typeName = string.Empty;

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                var result = command.ExecuteScalar();
                if (result == null)
                    throw new NullReferenceException("Значение не найдено.");
                typeName = result.ToString();
            }

            connection.Close();
            return typeName;
        }
    }
}
