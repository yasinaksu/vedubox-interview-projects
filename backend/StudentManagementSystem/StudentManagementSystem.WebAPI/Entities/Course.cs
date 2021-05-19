using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public int TeacherUserId { get; set; }
        public string CourseName { get; set; }
        public int CourseFees { get; set; }
        public string Duration { get; set; }
    }
}
