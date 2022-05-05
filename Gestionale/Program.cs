using Class.Model;
using Class.Persister;


var stringconnection = "Server=ACADEMYNETPD04\\SQLEXPRESS;Database=Gestionale;Trusted_Connection=True;";
//var stringconnection = "Server=.;Database=Gestionale;Trusted_Connection=True;";

var persisterPerson = new PersonPersister(stringconnection);
var studentPersister = new StudentPersister(stringconnection);
var teacherPersister = new TeacherPersister(stringconnection);
var subjectPersister = new SubjectPersister(stringconnection);
var examPersister = new ExamPersister(stringconnection);

var person = new Person
{
    Address = " via dei tigli 51",
    Birthday = new DateTime(1982, 5, 5),
    Gender ="Male",
    Name = "Fulvio",
    Surname ="Biondo"
};

var idPerson = persisterPerson.Add(person);
person.Id = idPerson;

var student = new Student
{
    Address = person.Address,
    Birthday =person.Birthday,
    Gender = person.Gender,
    Name = person.Name,
    Surname = person.Surname,
    Id = person.Id,
    DataImmatricolazione =new DateTime(1987, 7, 12),
    Matricola ="ABC12345"
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
    DataAssunzione = new DateTime(1980, 9, 30),
    Matricola = "P49769",
    Subject= "Math"
};
var idteacher = teacherPersister.Add(teacher);
teacher.IdTeacher= idteacher;

var subject = new Subject
{
    //prof= person.Surname
    //per mettere nome cognome?
    Name = "Math",
    Id = teacher.Id,
    Hours = new DateTime(3),
    Description = "Base cours to introduce the linear operations Algebra",
    Credits = "9"
};

var idsubject = subjectPersister.Add(subject);
subject.IdSubject = idsubject;

var exam = new Exam
{
    IdTeacher = teacher.IdTeacher,
    IdSubject = subject.IdSubject,
    Date = new DateTime(1980, 2, 15)

};
var idexam = examPersister.Add(exam);
exam.IdExam = idexam;

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"persona: {Name}, {Surname}, residenza { Address}, nata il {Birthday}, genere: {Gender} aggiunta! ");

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"studente{Name}, {Surname},residenza { Address},nata il {Birthday},genere {Gender},matricola {Matricola},inizio corso di laurea {DataImmatricolazione} ");

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"teacher: {Name}, {Surname}, id: { Id}, genere: {Gender},matricola {Matricola},nata il {Birthday},materia {Subject}, inizio lavoro {DataAssunzione}");

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"subject: {Name},id { Id}, durata {Hours}, descrizione {Description},crediti formativi {Credits}");

Console.WriteLine(@"***********************************\n");
Console.WriteLine(@"exam del prof {IdTeacher}, materia {IdSubject}, giorno {Date}");

Console.WriteLine("Operazione inserimento avvenuta conn successo!");
Console.ReadLine();