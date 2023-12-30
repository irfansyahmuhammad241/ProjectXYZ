using System.Net;
using Microsoft.AspNetCore.Mvc;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Technical_Test.DTOs.Authorization;
using Microsoft.AspNetCore.Authentication;
using Technical_Test.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/Auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationServices _authService;

        public AuthController(AuthenticationServices authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterDTO registerDto)
        {
            var createRegister = _authService.Register(registerDto);
            if (createRegister == null)
            {
                return BadRequest(new ResponseHandler<RegisterDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new ResponseHandler<RegisterDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createRegister
            });
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginDTO loginDto)
        {
            var loginResult = _authService.Login(loginDto);
            if (loginResult == "USER_NOT_FOUND")
            {
                return NotFound(new ResponseHandler<LoginDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email is incorrect"
                });
            }

            if (loginResult == "INVALID_PASSWORD")
            {
                return BadRequest(new ResponseHandler<LoginDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Password is incorrect"
                });
            }

            if (loginResult == "Error")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<LoginDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Error retrieving when creating token"
                });
            }

            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "You are now logged in",
                Data = loginResult
            });
        }
    }
}
