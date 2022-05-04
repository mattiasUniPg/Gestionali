using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Model
{
    public class Teacher : Person
    {
        public int IdTeacher { get; set; }
        public string Matricola { get; set; }
        public string Subject { get; set; }
        public DateTime DataAssunzione { get; set; }
    }
}