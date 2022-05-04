using Class.Model;
using Class.Persister;

namespace Gestionale
{
    public class Handler
    {

        private readonly string connectionString = "Server=ACADEMYNETPD04\\SQLEXPRESS;Database=Gestionale;Trusted_Connection=True;";
        //Server=myServerAddress;Database=myDataBase;User Id = myUsername; Password=myPassword;
        public bool InserisciUnoStudente()
        {
            var student = new Student
            {
                Id = 123,
                //IdStudente = 2243,
                Matricola = "333542",
                DataImmatricolazione = new DateTime(2018, 05, 01)               
            };

            var persisterStudente = new StudentPersister(connectionString);
            return persisterStudente.Add(student);
        }
        public bool InserisciEsame()
        {
            var exam = new Exam
            {
                IdExam = 24,
                IdTeacher = 2243,
                Date = new DateTime(2021, 05, 02),
                IdSubject=30
            };

            var persisterEsame = new ExamPersister(connectionString);
            return persisterEsame.Add(exam);
        }

        public bool UpdateStudente()
        {
            var studente = new Student
            {
                Id = 4,
                IdStudente = 4687,
                Matricola = "264876",
                DataImmatricolazione= new DateTime(2022-04-30)
            };

            var persisterStudenti = new StudentPersister("connectionString");
            return persisterStudenti.Update(studente);

        }

        public bool UpdateEsame()
        {
            var exam = new Exam
            {
                IdExam = 16,
                IdTeacher = 3878,
                Date = DateTime.Now,
                IdSubject=22


            };

            var persisterEsame = new ExamPersister(connectionString);
            return persisterEsame.Update(exam);

        }

        public List<Student> GetStudent()
        {
            var persisterStudente = new StudentPersister(connectionString);
            var listStudent = persisterStudente.GetStudent();
            return listStudent;
        }


        public IEnumerable<Student> GetStudent(int IdStudente)
        {
            var persisterStudente = new StudentPersister(connectionString);
            var listStudent = persisterStudente.GetStudent(IdStudente);
            return listStudent;
        }

        public List<Exam> GetExam(int idTeacher)
        {
            var persisterEsame = new ExamPersister(connectionString);
            var listEsame = persisterEsame.GetExam(idTeacher);
            return listEsame.ToList();
        }


        public IEnumerable<Exam> GetExamBySubject(int IdSubject)
        {
            var persisterEsame = new ExamPersister(connectionString);
            var listEsame = persisterEsame.GetExam(IdSubject);
            return listEsame;
        }
    }
}
