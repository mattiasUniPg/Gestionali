using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Model
{
    public class Exam
    {
        public int IdExam { get; set; }
        public int IdTeacher { get; set; }
        public DateTime Date { get; set; }
        public int IdSubject { get; set; }
    }
}