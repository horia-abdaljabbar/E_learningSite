using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String ImageName { get; set; }

        public string NumOfCourses { get; set; }
        public bool IsFinished { get; set; }
    }
}
