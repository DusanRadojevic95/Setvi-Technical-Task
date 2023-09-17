using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
    public interface IUserDataAccess
    {
        List<User> getUsersForCompany(int companyId);
        User createUserForCompany(string firstName, string lastName, string email, string companyId);
    }
}
