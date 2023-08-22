using System;
using Microsoft.AspNetCore.Mvc;
using MyFace.Models.Request;
using MyFace.Models.Response;
using MyFace.Repositories;

namespace MyFace.Controllers
{
    [ApiController]
    [Route("/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("")]
        public ActionResult VerifyCredentials([FromBody] LoginRequest loginRequest)
        {
            Console.WriteLine(loginRequest.Username);

            if (!_authService.VerifyCredentials(loginRequest.Username, loginRequest.Password))
            {
                return Unauthorized();
            }

            return Ok();
        }

    }
}
