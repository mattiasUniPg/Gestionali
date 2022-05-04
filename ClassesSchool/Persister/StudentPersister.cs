using Class.Model;
using System.Data.SqlClient;

namespace Class.Persister
{
    public class StudentPersister
    {
        private readonly string ConnectionString;
        public StudentPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public bool Add(Student student)
        {
            var sql = @"INSERT INTO [dbo].[Student]
                       ([IdPerson]
                       ,[Matricola]
                       ,[DataIscrizione])
                 VALUES
                       (@IdPerson
                       ,@Matricola
                       ,@DataIscrizione)";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", student.Id);
            command.Parameters.AddWithValue("@Matricola", student.Matricola);
            command.Parameters.AddWithValue("@DataIscrizione", student.DataImmatricolazione);
            return command.ExecuteNonQuery() > 0;
        }

        public List<Student> GetStudent()
        {

            var sql = @"
                    SELECT [IdStudente]
                          ,[IdPerson]
                          ,[Matricola]
                          ,[DataIscrizione]
                      FROM [dbo].[Student]";

            var listResult = new List<Student>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var student = new Student
                {
                    IdStudente = Convert.ToInt32(reader["IdStudente"]),
                    Id = Convert.ToInt32(reader["IdPerson"]),
                    DataImmatricolazione = Convert.ToDateTime(reader["DataIscrizione"]),
                    Matricola = reader["Matricola"].ToString()
                };
                listResult.Add(student);
            }
            return listResult;
        }
    
        public bool Update(Student student)
        {
            var sql = @"UPDATE[dbo].[Student]
                           SET[IdPerson] =@IdPerson
                              ,[Matricola] = @Matricola
                              ,[DataIscrizione] = @DataIscrizione
                          WHERE @IdPerson=IdPerson";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", student.Id);
            command.Parameters.AddWithValue("@Matricola", student.Matricola); 
            command.Parameters.AddWithValue("@DataIscrizione", student.DataImmatricolazione); ;
            return command.ExecuteNonQuery() > 0;
        }

        public List<Student> GetStudent(int idStudente)
        {

            var sql = @"
                    SELECT [IdStudente]
                          ,[IdPerson]
                          ,[Matricola]
                          ,[DataIscrizione]
                      FROM [dbo].[Student]
                      where IdStudente = @IdStudente";

            var listResult = new List<Student>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdStudente", idStudente);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var student = new Student
                {
                    IdStudente = Convert.ToInt32(reader["IdStudente"]),
                    Id = Convert.ToInt32(reader["IdPerson"]),
                    DataImmatricolazione = Convert.ToDateTime(reader["DataIscrizione"]),
                    Matricola = reader["Matricola"].ToString()
                };
                listResult.Add(student);
            }
            return listResult;
        }
    }
}
