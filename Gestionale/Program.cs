﻿using Class.Model;
using Gestionale;

var handler = new Handler();
var exams = handler.GetExam();

var persisterStudent = new StudentPersister("");
var students = persisterStudent.GetStudent();


IEnumerable<Student> nuovematricole = students.Where(x => DateTime.Now.Year - x.DataImmatricolazione.Year <2 );

foreach (var item in nuovematricole)
{
    Console.WriteLine($"{item.IdStudente} {item.Matricola} {item.DataImmatricolazione.Year} => {DateTime.Now.Year - item.DataImmatricolazione.Year}");
}

IEnumerable<Exam> sessioneinvernale = exams.Where(x => DateTime.Now.Month - x.DataImmatricolazione.Month >4);

foreach (var item in sessioneinvernale)
{
    Console.WriteLine($"{item.IdExam} {item.Subject} {item.IdTeacher} {item.Date.Year} => {DateTime.Now.Month - item.Date.Month}");
}



Console.ReadLine();