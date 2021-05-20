using StudentManagementSystem.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.DataAccess.Abstract
{
    public interface IUserHelper 
    {
        Task<List<OperationClaim>> GetOperationClaimsAsync(User user);
    }
}
