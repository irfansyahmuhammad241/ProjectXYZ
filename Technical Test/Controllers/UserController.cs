using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Technical_Test.DTOs.Company;
using Technical_Test.Services;

namespace Technical_Test.Controllers
{
    [ApiController]
    [Route("Api/User")]
    public class UserController : ControllerBase
    {
        private readonly UserServices _services;

        public UserController(UserServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _services.GetAllUser();

            if (entities == null)
            {
                return NotFound(new ResponseHandler<GetUserDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<GetUserDTO>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = entities
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _services.GetUserId(id);
            if (company is null)
            {
                return NotFound(new ResponseHandler<GetUserDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseHandler<GetUserDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = company
            });
        }

        [HttpPost]
        public IActionResult Create(NewUserDTO newUser)
        {
            var createNewUser = _services.CreateNewUser(newUser);
            if (createNewUser is null)
            {
                return BadRequest(new ResponseHandler<GetUserDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new ResponseHandler<GetUserDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createNewUser
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateUserDTO updateUserDTO)
        {
            var update = _services.UpdateUser(updateUserDTO);
            if (update is -1)
            {
                return NotFound(new ResponseHandler<UpdateUserDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new ResponseHandler<UpdateUserDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new ResponseHandler<UpdateUserDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _services.DeleteUser(id);

            if (delete is -1)
            {
                return NotFound(new ResponseHandler<GetUserDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (delete is 0)
            {
                return BadRequest(new ResponseHandler<GetUserDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new ResponseHandler<GetUserDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully deleted"
            });
        }
    }
}
