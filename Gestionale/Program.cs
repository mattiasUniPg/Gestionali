using Class.Model;
using Class.Persister;


//var stringconnection = "Server=ACADEMYNETPD04\\SQLEXPRESS;Database=Gestionale;Trusted_Connection=True;";
var stringconnection = "Server=.;Database=Gestionale;Trusted_Connection=True;";

var persisterPerson = new PersonPersister(stringconnection);
var studentPersister = new StudentPersister(stringconnection);


var person = new Person
{
    Address = " via dei tigli 51",
    Birthday = new DateTime(1982, 5, 5),
    Gender ="Male",
    Name = "Fulvio",
    Surname ="Biondo"
};

var idPerson = persisterPerson.Add(person);

var student = new Student
{
    Address = person.Address,
    Birthday =person.Birthday,
    Gender = person.Gender,
    Name = person.Name,
    Surname = person.Surname,
    Id = person.Id,
    DataImmatricolazione = DateTime.Now,
    Matricola ="ABC12345"
};


var idstudent = studentPersister.Add(student);

student.IdStudente = idstudent;


Console.WriteLine($"{student.Name} {student.Surname} {student.Id} {student.Address} {student.Birthday.ToShortDateString()} {student.Matricola} {student.DataImmatricolazione.ToLongDateString()} {student.IdStudente} {student.Gender}");


Console.ReadLine();