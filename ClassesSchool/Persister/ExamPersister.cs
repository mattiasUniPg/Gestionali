using Class.Model;
using System.Data.SqlClient;

namespace Class.Persister

{
    public class ExamPersister
    {
        private readonly string ConnectionString;
        public ExamPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public int Add(Exam exam)
        {
            var sql = @"INSERT INTO [dbo].[Exam]
                           ([IdTeacher]
                           ,[Date]
                           ,[IdSubject])
                     VALUES
                           (@IdTeacher
                           ,@Date
                           ,@IdSubject)";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", exam.IdTeacher);
            command.Parameters.AddWithValue("@Date", exam.Date);
            command.Parameters.AddWithValue("@IdSubject", exam.IdSubject);
            return Convert.ToInt32(command.ExecuteScalar());
        }
        public bool Update(Exam exam)
        {
            var sql = @"UPDATE [dbo].[Exam]
                       SET [IdTeacher] = @IdTeacher
                          ,[Date] = @Date
                          ,[IdSubject] = @IdSubject
                      WHERE @IdTeacher=IdTeacher";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", exam.IdTeacher);
            command.Parameters.AddWithValue("@Date", exam.Date); ;
            return command.ExecuteNonQuery() > 0;
        }

        public IEnumerable<Exam> GetExam(int IdTeacher)
        {

            var sql = @"
                    SELECT  [IdExam]
                           ,[IdTeacher]
                          ,[Date]
                          ,[IdSubject]
                      FROM [dbo].[Exam]
                        where IdTeacher =@IdTeacher";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", IdTeacher);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Exam
                {
                    Date = Convert.ToDateTime(reader["Date"]),
                    IdTeacher = Convert.ToInt32(reader["IdTeacher"]),
                    IdExam = Convert.ToInt32(reader["IdExam"]),
                    IdSubject = Convert.ToInt32(reader["IdSubject"]),
                };

            }
        }



        public IEnumerable<Exam> GetExamBySubject(int idsubject)
        {

            var sql = @"
                    SELECT [IdExam]
                           ,[IdTeacher]
                          ,[Date]
                          ,[IdSubject]
                      FROM [dbo].[Exam]
                        where IdSubject =@IdSubject";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSubject", idsubject);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Exam
                {
                    Date = Convert.ToDateTime(reader["Date"]),
                    IdTeacher = Convert.ToInt32(reader["IdTeacher"]),
                    IdExam = Convert.ToInt32(reader["IdExam"]),
                    IdSubject = Convert.ToInt32(reader["IdSubject"]),
                };

            }
        }


    }
}