using Npgsql;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace traffic_accident.Domain.Repositories
{
    internal static class SolutionHandler
    {
        private static string connectPath = "Host=localhost;Port=5432;Database=practical_work;Username=postgres;Password=1234";
        private static NpgsqlConnection connection;

        static SolutionHandler() => connection = new NpgsqlConnection(connectPath);

        public static string GetSolutionNameToId(int solutionId)
        {
            string solutionName = string.Empty;
            string sqlRequest = $"SELECT solution FROM possible_solutions ps " +
                $"WHERE ps.id = {solutionId}";

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                var result = command.ExecuteScalar();
                if (result == null)
                    throw new NullReferenceException("Значение не найдено.");
                solutionName = result.ToString();
            }

            connection.Close();
            return solutionName;
        }
    }
}
