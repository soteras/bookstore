using Bookstore.Core.Authentication;
using Bookstore.Core.Entities;
using Bookstore.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controller.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class SignupController: ControllerBase
    {
        public SignupController(ISignupService service)
        {
            _service = service;
        }

        private readonly ISignupService _service;

        public ActionResult<User> Create([FromBody] SignupRequest request)
        {
            try
            {
                var user = _service.CreateUser(request.Email, request.Password);
                return Ok(user);
            } catch
            {
                return UnprocessableEntity("Error to create user");
            }
        }
    }
}
