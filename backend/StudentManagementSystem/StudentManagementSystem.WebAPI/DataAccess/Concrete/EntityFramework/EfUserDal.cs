using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.WebAPI.DataAccess.Abstract;
using StudentManagementSystem.WebAPI.DataAccess.Concrete.EntityFramework.Contexts;
using StudentManagementSystem.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,StudentManagementSystemContext>,IUserDal
    {
        public async Task<List<OperationClaim>> GetOperationClaimsAsync(User user)
        {
            using (var context = new StudentManagementSystemContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return await result.ToListAsync();
            }
        }
    }
}
