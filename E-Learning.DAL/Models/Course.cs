using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public String ImageName { get; set; }
        public int NumOfHour { get; set; }
        public bool IsFinished { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NumOfStudents { get; set; }
    }
}
