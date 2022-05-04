using Class.Model;
using System.Data.SqlClient;

namespace Class.Persister
{
    public class TeacherPersister
    {

        private readonly string ConnectionString;
        public TeacherPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public int Add(Teacher teacher)
        {
            var sql = @"INSERT INTO[dbo].[Teacher]
                                ([IdPerson]
                              ,[Matricola]
                              ,[DataAssunzione])
                         VALUES
                               (@IdPerson
                               ,@Matricola
                               ,@DataAssunzione);SELECT @@IDENTITY AS 'Identity';  ";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", teacher.Id);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataIscrizione", teacher.DataAssunzione);
            return Convert.ToInt32(command.ExecuteNonQuery());
        }

        public List<Teacher> GetProf()
        {

            var sql = @"SELECT[IdTeacher]
                            ,[IdPerson]s
                            ,[Matricola]
                            ,[DataAssunzione]
                       FROM[dbo].[Teacher]";

            var listResult = new List<Teacher>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var teacher = new Teacher
                {
                    IdTeacher = Convert.ToInt32(reader["IdTeacher"]),
                    Id = Convert.ToInt32(reader["IdPerson"]),
                    DataAssunzione = Convert.ToDateTime(reader["DataAssunzione"]),
                    Matricola = reader["Matricola"].ToString()
                };
                listResult.Add(teacher);
            }
            return listResult;
        }

        public bool Update(Teacher teacher)
        {
            var sql = @"UPDATE[dbo].[Teacher]
                           SET[IdPerson] =@IdPerson
                              ,[Matricola] = @Matricola
                              ,[DataAssunzione] = @DataAssunzione
                          WHERE @IdPerson=IdPerson";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", teacher.Id);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataAssunzione", teacher.DataAssunzione); ;
            return command.ExecuteNonQuery() > 0;
        }

        public List<Teacher> GetProf(int idTeacher)
        {

            var sql = @"
                    SELECT [IdTeacher]
                          ,[IdPerson]
                          ,[Matricola]
                          ,[DataAssuznione]
                      FROM [dbo].[Teacher]
                      where IdTeacher = @IdTeacher";

            var listResult = new List<Teacher>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", idTeacher);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var teacher = new Teacher
                {
                    IdTeacher = Convert.ToInt32(reader["IdTeacher"]),
                    Id = Convert.ToInt32(reader["IdPerson"]),
                    DataAssunzione = Convert.ToDateTime(reader["DataAssunzione"]),
                    Matricola = reader["Matricola"].ToString()
                };
                listResult.Add(teacher);
            }
            return listResult;

        }
    }
}
