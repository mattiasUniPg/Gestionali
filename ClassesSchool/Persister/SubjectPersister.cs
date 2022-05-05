using Class.Model;
using System.Data.SqlClient;

namespace Class.Persister
{
    public class SubjectPersister
    {

        private readonly string ConnectionString;
        public SubjectPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public int Add(Subject subject)
        {
            var sql = @"INSERT INTO [dbo].[Subject]
                           ([Name]
                           ,[Description]
                           ,[Hours]
                           ,[Credits])
                     VALUES
                           (@Name
                           ,@Description
                           ,@Credits
                           ,@Hours);SELECT @@IDENTITY AS 'Identity'";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", subject.Name);
            command.Parameters.AddWithValue("@Description", subject.Description);
            command.Parameters.AddWithValue("@Hours", subject.Hours);
            command.Parameters.AddWithValue("@Credits", subject.Credits);
            return Convert.ToInt32(command.ExecuteScalar());
        }
        public bool Update(Subject subject)
        {
            var sql = @"UPDATE [dbo].[Subject]
                       SET [Name] = @Name
                          ,[Description] = @Description
                          ,[Credits] = @Credits
                          ,[Hours]=@Hours
                       WHERE @IdTeacher=IdSubject";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", subject.Name);
            command.Parameters.AddWithValue("@Date", subject.Description);
            command.Parameters.AddWithValue("@Credits", subject.Credits);
            command.Parameters.AddWithValue("@Hours", subject.Hours);
            return command.ExecuteNonQuery() > 0;
        }
        
        public IEnumerable<Subject> GetSubject(int IdSubject)
        {

            var sql = @"SELECT [IdSubject]
                              ,[Name]
                              ,[Description]
                              ,[Credits]
                              ,[Hours]
                          FROM [dbo].[Subject]
                      where IdSubject =@IdSubject";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSubject", IdSubject);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
               yield return new Subject
                {
                    Name = Convert.ToString(reader["Name"]),
                    IdSubject = Convert.ToInt32(reader["IdSubject"]),
                    Description = Convert.ToString(reader["Description"]),
                    Credits = Convert.ToString(reader["Credits"]),
                    Hours = Convert.ToInt32(reader["Hours"]),
                };

            }
        }



        public IEnumerable<Subject> GetSubjectById(int IdSubject)
        {

            var sql = @"SELECT [IdSubject]
                          ,[Name]
                          ,[Description]
                          ,[Credits]
                          ,[Hours]
                      FROM [dbo].[Subject]
                        where IdSubject =@IdSubject";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSubject", IdSubject);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Subject
                {
                    Name=Convert.ToString(reader["Name"]),
                    IdSubject = Convert.ToInt32(reader["IdSubject"]),
                    Credits = Convert.ToString(reader["Credits"]),
                    Hours= Convert.ToInt32(reader["Hours"]),
                    Description = Convert.ToString(reader["Description"]),
                };

            }
        }

    }
}
