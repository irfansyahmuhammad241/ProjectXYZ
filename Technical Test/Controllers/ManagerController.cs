using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Technical_Test.DTOs.Company;
using Technical_Test.Services;

namespace Technical_Test.Controllers
{
    [ApiController]
    [Route("Api/Manager")]
    public class ManagerController: ControllerBase
    {
        private readonly ManagerLogisticsServices _services;

        public ManagerController(ManagerLogisticsServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _services.GetAllManager();

            if (entities == null)
            {
                return NotFound(new ResponseHandler<GetManagerLogisticsDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<GetManagerLogisticsDTO>>
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
            var manager = _services.GetManagerId(id);
            if (manager is null)
            {
                return NotFound(new ResponseHandler<GetManagerLogisticsDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseHandler<GetManagerLogisticsDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = manager
            });
        }

        [HttpPost]
        public IActionResult Create(NewManagerLogisticsDTO newManager)
        {
            var createNewManager = _services.CreateNewManager(newManager);
            if (createNewManager is null)
            {
                return BadRequest(new ResponseHandler<GetManagerLogisticsDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new ResponseHandler<GetManagerLogisticsDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createNewManager
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateManagerLogisticsDTO updateManagerLogisticsDTO)
        {
            var update = _services.UpdateManager(updateManagerLogisticsDTO);
            if (update is -1)
            {
                return NotFound(new ResponseHandler<UpdateManagerLogisticsDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new ResponseHandler<UpdateManagerLogisticsDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new ResponseHandler<UpdateManagerLogisticsDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _services.DeleteManager(id);

            if (delete is -1)
            {
                return NotFound(new ResponseHandler<GetManagerLogisticsDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (delete is 0)
            {
                return BadRequest(new ResponseHandler<GetManagerLogisticsDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new ResponseHandler<GetManagerLogisticsDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully deleted"
            });
        }
    }
}
