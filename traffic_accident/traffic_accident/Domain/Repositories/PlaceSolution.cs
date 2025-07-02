using Npgsql;

namespace traffic_accident.Domain.Repositories
{
    internal class PlaceSolution
    {
        private static string connectPath = "Host=localhost;Port=5432;Database=practical_work;Username=postgres;Password=1234";
        private static NpgsqlConnection connection;

        public string Address { get; private set; }

        private List<int> MainTypesIdTrafficAccident;

        public readonly IReadOnlyList<string> MainTypesTrafficAccident;
        public readonly IReadOnlyList<string> PossibleSolutions;

        static PlaceSolution() => connection = new NpgsqlConnection(connectPath);

        public PlaceSolution(string address)
        {
            Address = address;

            List<string> mainTypesTrafficAccident = new();
            MainTypesIdTrafficAccident = GetTypeIdsOnDangerousPlaces();
            foreach (var typeId in MainTypesIdTrafficAccident)
            {
                mainTypesTrafficAccident.Add(TypeHandler.GetTypeNameToId(typeId));
            }
            MainTypesTrafficAccident = mainTypesTrafficAccident;

            List<int> possibleSolutionsId = new();
            AddSolutionsIdByType(possibleSolutionsId);
            AddSolutionsIdByCause(possibleSolutionsId);
            AddSolutionsIdBySubcause(possibleSolutionsId);
            List<string> possibleSolutions = new();
            foreach (var solutionId in possibleSolutionsId)
                possibleSolutions.Add(SolutionHandler.GetSolutionNameToId(solutionId));
            PossibleSolutions = possibleSolutions;
        }

        private List<int> GetTypeIdsOnDangerousPlaces()
        {
            List<int> typeIds = new();
            var sqlRequest = $"SELECT type_id FROM traffic_accidents ta " +
                $"WHERE ta.address_traffic_accident = '{Address}' " +
                $"GROUP BY type_id HAVING COUNT(*) >= 3;";

            connection.Open();

            using (var command = new NpgsqlCommand(sqlRequest, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        typeIds.Add(reader.GetInt32(0));
                }
            }

            connection.Close();
            return typeIds;
        }

        private void AddSolutionsIdByType(List<int> possibleSolutionsId)
        {
            foreach (var typeId in MainTypesIdTrafficAccident)
            {
                List<int> solutionsId = new();
                string sqlRequest = $"SELECT solution_id FROM types_solutions_table WHERE type_id = {typeId}";

                connection.Open();
                using (var command = new NpgsqlCommand(sqlRequest, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int solutionId = reader.GetInt32(0);
                            if (!possibleSolutionsId.Contains(solutionId))
                                possibleSolutionsId.Add(solutionId);
                        }
                    }
                }

                connection.Close();
            }
        }

        private void AddSolutionsIdByCause(List<int> possibleSolutionsId)
        {
            connection.Open();

            foreach (var typeId in MainTypesIdTrafficAccident)
            {
                string sqlRequest = $"SELECT cause_id FROM traffic_accidents ta " +
                    $"WHERE ta.address_traffic_accident = '{Address}' " +
                    $"AND ta.type_id = {typeId} " +
                    $"AND ta.subcause_id IS NULL";
                List<int> causesId = new();

                using (var command = new NpgsqlCommand(sqlRequest, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int causeId = reader.GetInt32(0);
                            if (!causesId.Contains(causeId))
                                causesId.Add(causeId);
                        }
                    }
                }

                foreach (var causeId in causesId)
                {
                    sqlRequest = $"SELECT solution_id FROM causes_solutions_table cst " +
                        $"WHERE cst.name_causes_table = 'causes_of_traffic_accidents' " +
                        $"AND cause_id = {causeId}";

                    using (var command = new NpgsqlCommand(sqlRequest, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int solution_id = reader.GetInt32(0);
                                if (!possibleSolutionsId.Contains(solution_id))
                                    possibleSolutionsId.Add(solution_id);
                            }
                        }
                    }

                }

            }

            connection.Close();
        }

        private void AddSolutionsIdBySubcause(List<int> possibleSolutionsId)
        {
            connection.Open();
            int countCause = 0;

            foreach (var typeId in MainTypesIdTrafficAccident)
            {
                string sqlRequest = $"SELECT cause_id, subcause_id FROM traffic_accidents ta " +
                    $"WHERE ta.address_traffic_accident = '{Address}' " +
                    $"AND ta.type_id = {typeId} " +
                    $"AND ta.subcause_id IS NOT NULL";
                List<int> causesId = new();
                List<int> subcausesId = new();

                using (var command = new NpgsqlCommand(sqlRequest, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int causeId = reader.GetInt32(0);
                            if (!causesId.Contains(causeId))
                                causesId.Add(causeId);

                            int subcauseId = reader.GetInt32(1);
                            if (!causesId.Contains(subcauseId))
                                subcausesId.Add(subcauseId);
                        }
                    }
                }

                foreach (var causeId in causesId)
                {
                    string nameSubcausesTable = string.Empty;
                    sqlRequest = $"SELECT name_of_subcauses_table FROM causes_of_traffic_accidents cota " +
                        $"WHERE cota.id = {causeId}";

                    using (var command = new NpgsqlCommand(sqlRequest, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result == null)
                            throw new NullReferenceException("Значение таблицы не найдено.");
                        nameSubcausesTable = result.ToString();
                    }


                    sqlRequest = $"SELECT solution_id FROM causes_solutions_table cst " +
                        $"WHERE cst.name_causes_table = '{nameSubcausesTable}' " +
                        $"AND cause_id = {subcausesId[countCause]}";

                    using (var command = new NpgsqlCommand(sqlRequest, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int solution_id = reader.GetInt32(0);
                                if (!possibleSolutionsId.Contains(solution_id))
                                    possibleSolutionsId.Add(solution_id);
                            }
                        }
                    }

                }

                countCause++;
            }

            connection.Close();
        }
    }
}
