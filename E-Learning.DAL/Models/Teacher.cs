using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String ImageName { get; set; }

        public string Field { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool StillWorked { get; set; }
    }
}
