using DataAccess.Entities;
using DataAccess.Services;
using DataAccess.Services.Interfaces;
using SetviTestSolution.Controllers.Requests;
using SetviTestSolution.Services.Interfaces;

namespace SetviTestSolution.Services
{
    public class UserService : IUserService
    {
        IUserDataAccess userDataAccess;
        public UserService(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public List<User> getUsersForCompany(int companyId) 
        {
            return userDataAccess.getUsersForCompany(companyId).OrderBy(u => u.FirstName).ToList();
        }

        public User createUserForCompany(CreateUserRequest user, int companyId)
        {
            return userDataAccess.createUserForCompany(user.FirstName, user.LastName, user.Email, companyId.ToString());
        }
    }
}
