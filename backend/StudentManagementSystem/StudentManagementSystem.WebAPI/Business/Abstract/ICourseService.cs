using StudentManagementSystem.WebAPI.Core.Utilities.Results;
using StudentManagementSystem.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Business.Abstract
{
    public interface ICourseService
    {
        Task<IResult> AddAsync(Course course);
        Task<IResult> DeleteAsync(Course course);
        Task<IResult> UpdateAsync(Course course);
        Task<IDataResult<Course>> GetByIdAsync(int id);
        Task<IDataResult<List<Course>>> GetAllAsync();
    }
}
