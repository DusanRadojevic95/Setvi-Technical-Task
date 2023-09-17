using DataAccess.Entities;
using SetviTestSolution.Controllers.Requests;

namespace SetviTestSolution.Services.Interfaces
{
    public interface IUserService
    {
        List<User> getUsersForCompany(int companyId);
        User createUserForCompany(CreateUserRequest user, int companyId);
    }
}
