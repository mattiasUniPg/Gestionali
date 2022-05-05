﻿using Class.Model;
using Class.Model;
using System.Data.SqlClient;

namespace Class.Persister
{
    public class PersonPersister
        {
            private readonly string ConnectionString;
            public PersonPersister(string connectionString)=>  ConnectionString = connectionString;
         
            public int Add(Person person)
            {
                var sql = @"
                        INSERT INTO [dbo].[Person]
                                   ([Name]
                                   ,[Surname]
                                   ,[BirthDay]
                                   ,[Gender])
                             VALUES
                                   (@Name
                                   ,@Surname
                                   ,@BirthDay
                                   ,@Gender); SELECT @@IDENTITY AS 'Identity';  ";
             
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@BirthDay", person.Birthday);
                command.Parameters.AddWithValue("@Gender", person.Gender);
                return Convert.ToInt32(command.ExecuteScalar());
            }


            public bool Delete(int IdPerson)
            {
                var sql = @"DELETE FROM [dbo].[Person]
                        WHERE Id=@Id ";
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", 1);
                return command.ExecuteNonQuery() > 0;
            }


            public bool Update(Person person)
            {
                var sql = @"UPDATE [dbo].[Person]
                       SET [Name] = @Name
                          ,[Surname] = @Surname
                          ,[BirthDay] = @BirthDay
                          ,[Gender] = @Gender
                     WHERE @Id=Id";

                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@BirthDay", person.Birthday);
                command.Parameters.AddWithValue("@Gender", person.Gender);
                command.Parameters.AddWithValue("@Id", person.Id);
                return command.ExecuteNonQuery() > 0;
            }

            public List<Person> GetPeople()
            {

                var sql = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Surname]
                          ,[BirthDay]
                          ,[Gender]
                          ,[Address]
                      FROM [dbo].[Person]";

                var listResult = new List<Person>();

                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(sql, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var person = new Person
                    {
                        Birthday = Convert.ToDateTime(reader["Birthday"]),
                        Gender = reader["Gender"].ToString(),
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Address = reader["Address"].ToString(),
                    };
                    listResult.Add(person);
                }
                return listResult;
            }


            public IEnumerable<Person> GetPeople(string surname)
            {

                var sql = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Surname]
                          ,[BirthDay]
                          ,[Gender]
                          ,[Address]
                      FROM [dbo].[Person]
                        where Surname =@surname";


                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@surname", surname);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Person
                    {
                        Birthday = Convert.ToDateTime(reader["Birthday"]),
                        Gender = reader["Gender"].ToString(),
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Address = reader["Address"].ToString(),
                    };

                }

            }


        }
}
