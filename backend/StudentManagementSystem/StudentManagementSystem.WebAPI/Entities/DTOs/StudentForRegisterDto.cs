using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Entities.DTOs
{
    public class StudentForRegisterDto : UserForRegisterDto
    {
        public string Education { get; set; }
    }
}
