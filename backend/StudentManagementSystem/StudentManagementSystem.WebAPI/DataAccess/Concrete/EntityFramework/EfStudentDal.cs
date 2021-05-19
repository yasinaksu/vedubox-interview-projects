using StudentManagementSystem.WebAPI.DataAccess.Abstract;
using StudentManagementSystem.WebAPI.DataAccess.Concrete.EntityFramework.Contexts;
using StudentManagementSystem.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student,StudentManagementSystemContext>, IStudentDal
    {

    }
}
