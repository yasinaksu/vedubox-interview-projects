﻿using StudentManagementSystem.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
    }
}
