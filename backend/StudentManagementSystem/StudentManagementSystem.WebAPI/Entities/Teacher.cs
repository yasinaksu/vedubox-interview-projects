using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Entities
{
    public class Teacher : User
    {
        public string Branch { get; set; }
    }
}
