using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Entities.DTOs
{
    public class TeacherForRegisterDto:UserForRegisterDto
    {
        public string Branch { get; set; }
    }
}
