
/*
 * 
 *          FILE A PARTE  
using Class.Model;
using System.Data.SqlClient;

namespace Gestionale
{

     public class DataStudent
        {
            private readonly List<Student> BaseData;

            public DataStudent()
            {
              BaseData = new List<Student>();
            }

            public void Add(Student student)
            {
                BaseData.Add(student);
            }

            public List<Student> Search(string IdPerson, string IdStudente)
            {
                var listOutput = new List<Student>();

                foreach (var student in BaseData)
                {
                    if (student.IdPerson.Equals(IdPerson) && student.IdStudente.Equals(IdStudente))
                    {
                        listOutput.Add(student);
                    }
                }

                return listOutput;
            }


            public List<Student> SearchByLinq(string IdPerson, string IdStudente)
            {
                return BaseData.
                    Where(x =>
                    x.IdPerson.Equals(IdPerson)
                    && x.IdStudente.Equals(IdStudente))
                    .ToList();
            }

            public Student? SearchFirst(string IdPerson, string IdStudente)
            {
                return BaseData.
                    FirstOrDefault(x =>
                    x.IdPerson.Equals(IdPerson)
                    && x.IdStudente.Equals(IdStudente));
            }

 

            public List<string> GetAllIdStudente()
            {
                return BaseData.Select(x => x.IdStudente).ToList();
            }

          
            public bool CheckIfEmpty() => BaseData.Any();


     }
}           FINE ERRORE
*/                  
