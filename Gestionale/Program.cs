using Class.Model;
using Gestionale;
using Class.Persister;

var handler = new Handler();
var exams = handler.GetExam(10);

//var persisterStudent = new StudentPersister("Server=ACADEMYNETPD04\\SQLEXPRESS;Database=Gestionale;Trusted_Connection=True;");
var persisterStudent = new StudentPersister("Server=.;Database=Gestionale;Trusted_Connection=True;");
var students = persisterStudent.GetStudent();


IEnumerable<Student> nuovematricole = students.Where(x => DateTime.Now.Year - x.DataImmatricolazione.Year <2 );

foreach (var item in nuovematricole)
{
    Console.WriteLine($"{item.IdStudente} {item.Matricola} {item.DataImmatricolazione.Year} => {DateTime.Now.Year - item.DataImmatricolazione.Year}");
}

IEnumerable<Exam> sessioneinvernale = exams.Where(x => DateTime.Now.Month - x.Date.Month >4);

foreach (var item in sessioneinvernale)
{
    Console.WriteLine($"{item.IdExam} {item.IdSubject} {item.IdTeacher} {item.Date.Year} => {DateTime.Now.Month - item.Date.Month}");
}



Console.ReadLine();