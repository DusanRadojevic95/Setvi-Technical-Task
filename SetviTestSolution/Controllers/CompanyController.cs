using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SetviTestSolution.Controllers.Requests;
using SetviTestSolution.Services.Interfaces;

namespace SetviTestSolution.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly IUserService userService;

        public CompanyController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        [Route("{companyId}/users")]
        // [Authorization] -- Not currently implemented
        public IActionResult GetUsers(int companyId)
        {
            if(companyId <= 0) { return BadRequest(); }
            return Ok(userService.getUsersForCompany(companyId));
        }

        [HttpPost]
        [Route("{companyId}/user")]
        // [Authorization] -- Not currently implemented

        public IActionResult CreateUser(int companyId, CreateUserRequest user)
        {
            if (companyId <= 0) { return BadRequest(); }
            return Ok(userService.createUserForCompany(user, companyId));
        }
    }
}
