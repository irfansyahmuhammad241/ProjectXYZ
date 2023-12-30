using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Net;
using Technical_Test.DTOs.Company;
using Technical_Test.Services;

namespace Technical_Test.Controllers
{
    [ApiController]
    [Route("Api/Company")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyServices _services;

        public CompanyController(CompanyServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _services.GetCompany();

            if (entities == null)
            {
                return NotFound(new ResponseHandler<GetCompanyDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<GetCompanyDTO>>
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
            var company = _services.GetCompanyID(id);
            if (company is null)
            {
                return NotFound(new ResponseHandler<GetCompanyDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseHandler<GetCompanyDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = company
            });
        }

        [HttpPost]
        public IActionResult Create(NewCompanyDTO newCompany)
        {
            var createNewCompany = _services.CreateCompany(newCompany);
            if (createNewCompany is null)
            {
                return BadRequest(new ResponseHandler<GetUserDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new ResponseHandler<GetCompanyDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createNewCompany
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateCompanyDTO updateCompanyDTO)
        {
            var update = _services.UpdateCompany(updateCompanyDTO);
            if (update is -1)
            {
                return NotFound(new ResponseHandler<UpdateCompanyDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new ResponseHandler<UpdateCompanyDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new ResponseHandler<UpdateCompanyDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _services.DeleteCompany(id);

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
