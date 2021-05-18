using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Entities
{
    public class Student : User
    {
        public string Education { get; set; }
    }
}
