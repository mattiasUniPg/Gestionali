using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Model
{
    public class Subject : Person
    {

        public int IdSubject { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public string Credits { get; set; }
    }
}
