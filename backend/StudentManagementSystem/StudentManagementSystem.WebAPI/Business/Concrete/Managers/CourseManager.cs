using StudentManagementSystem.WebAPI.Business.Abstract;
using StudentManagementSystem.WebAPI.Business.Constants;
using StudentManagementSystem.WebAPI.Core.Utilities.Results;
using StudentManagementSystem.WebAPI.DataAccess.Abstract;
using StudentManagementSystem.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Business.Concrete.Managers
{
    public class CourseManager:ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public async Task<IResult> AddAsync(Course course)
        {
            await _courseDal.AddAsync(course);
            return new SuccessResult(Messages.CourseAdded);
        }

        public async Task<IResult> DeleteAsync(Course course)
        {
            await _courseDal.DeleteAsync(course);
            return new SuccessResult(Messages.CourseDeleted);
        }

        public async Task<IDataResult<List<Course>>> GetAllAsync()
        {
            var courses = await _courseDal.GetAllAsync();
            return new SuccessDataResult<List<Course>>(courses);
        }

        public async Task<IDataResult<Course>> GetByIdAsync(int id)
        {
            var course = await _courseDal.GetAsync(x => x.Id == id);
            return new SuccessDataResult<Course>(course);
        }

        public async Task<IResult> UpdateAsync(Course course)
        {
            await _courseDal.UpdateAsync(course);
            return new SuccessResult(Messages.CourseUpdated);
        }
    }
}
