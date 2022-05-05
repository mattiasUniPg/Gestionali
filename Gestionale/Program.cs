using Class.Model;
using Class.Persister;


var stringconnection = "Server=ACADEMYNETPD04\\SQLEXPRESS;Database=Gestionale;Trusted_Connection=True;";
//Gino var stringconnection = "Server=.;Database=Gestionale;Trusted_Connection=True;";

var persisterPerson = new PersonPersister(stringconnection);
var studentPersister = new StudentPersister(stringconnection);
var teacherPersister = new TeacherPersister(stringconnection);
var subjectPersister = new SubjectPersister(stringconnection);
var examPersister = new ExamPersister(stringconnection);

var person = new Person
{
    Address = " via Girandola 967",
    Birthday = new DateTime(1998, 8, 14),
    Gender ="Female",
    Name = "Stefania",
    Surname ="Nicoletta"
};

var idPerson = persisterPerson.Add(person);
person.Id = idPerson;

Console.WriteLine("Inserisci un intero da 1.. per Idpersona da eliminare nel DB\n (0  per proseguire)");
int idDaCancellare = Convert.ToInt32(Console.ReadLine());
persisterPerson.Delete(idDaCancellare);

Console.WriteLine($"Numero di persone totali presenti nel gestionale:");
var CountPersons= persisterPerson.GetPeople();

List<Person> stampaPerson = (CountPersons);
Console.WriteLine(stampaPerson.Count);

Console.WriteLine($"Inserisci ID persona da ricercare");
var GetPerson = Convert.ToString(Console.ReadLine());
persisterPerson.GetPeople(GetPerson);

Console.WriteLine($"***********************************\n");
/*   Console.WriteLine($"Persona associata all'ID {person.Id}, {person.Name}," +
     $" {person.Surname}, {person.Gender}, {person.Address} nata il {person.Birthday} ");
*/

var student = new Student
{
    Address = person.Address,
    Birthday =person.Birthday,
    Gender = person.Gender,
    Name = person.Name,
    Surname = person.Surname,
    Id = person.Id,
    DataImmatricolazione =new DateTime(2019, 9, 30),
    Matricola ="TI8686"
};

var idStudent = studentPersister.Add(student);
student.IdStudente= idStudent;


var teacher = new Teacher
{
    Address = person.Address,
    Birthday = person.Birthday,
    Gender = person.Gender,
    Name = person.Name,
    Surname = person.Surname,
    Id = person.Id,
    DataAssunzione = new DateTime(1976, 5, 30),
    Matricola = "DJ4689",
    Subject= "Biology"
};
var idteacher = teacherPersister.Add(teacher);
teacher.IdTeacher= idteacher;

var subject = new Subject
{
    //prof= person.Surname
    //per mettere nome cognome?
    Name = "Biology",
    Id = teacher.Id,
    Hours = 6,
    Description = "Base cours to introduce the source of pathologies ",
    Credits = "12"
};

var idsubject = subjectPersister.Add(subject);
subject.IdSubject = idsubject;

var exam = new Exam
{
    IdTeacher = teacher.IdTeacher,
    IdSubject = subject.IdSubject,
    Date = new DateTime(2019, 12, 4)

};
var idexam = examPersister.Add(exam);
exam.IdExam = idexam;

var persone = persisterPerson.GetPeople();
IEnumerable<Person> persone89 = persone.Where(x => DateTime.Now.Year - x.Birthday.Year < 33);

Console.WriteLine("\nOperazione inserimento avvenuta conn successo!");
Console.WriteLine($"***********************************\n");

Console.WriteLine($"persona: {person.Name}, {person.Surname}, residenza {person.Address}, nata il {person.Birthday}, genere: {person.Gender} aggiunta! ");

Console.WriteLine($"***********************************\n");
Console.WriteLine($"studente: {student.Name}, {student.Surname},residenza {student.Address},nata il {student.Birthday},genere {student.Gender},matricola {student.Matricola},inizio corso di laurea {student.DataImmatricolazione} ");

Console.WriteLine($"***********************************\n");
Console.WriteLine($"teacher: {teacher.Name}, {teacher.Surname}, id: {teacher.Id}, genere: {teacher.Gender},matricola {teacher.Matricola},nata il {teacher.Birthday},materia {teacher.Subject}, inizio lavoro {teacher.DataAssunzione}");

Console.WriteLine($"***********************************\n");
Console.WriteLine($"subject: {subject.Name},id {subject.Id}, durata {subject.Hours}, descrizione {subject.Description},crediti formativi {subject.Credits}");

Console.WriteLine($"***********************************\n");
Console.WriteLine($"esame con prof: {exam.IdTeacher}, materia {exam.IdSubject}, giorno {exam.Date}");


Console.WriteLine($"***********************************\n");
Console.WriteLine($"Persone miste che sono entrate in facoltà dopo l'anno 1989\n");
foreach (var item in persone89)
{
    Console.WriteLine($"{item.Name} {item.Surname} {item.Birthday.Year} => {DateTime.Now.Year - item.Birthday.Year}");
}



Console.ReadLine();