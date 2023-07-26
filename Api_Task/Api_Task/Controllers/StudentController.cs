using ApiTask.Service.Dtos.StudentDtos;
using ApiTask.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;


        public StudentController(IStudentServices studentServices)
        {
            
            _studentServices = studentServices;
        }


        [HttpPost]
        [Route("")]
        public IActionResult Create([FromForm] StudentCreatDto dto)
        {
            return StatusCode(201, _studentServices.Create(dto));

        }
        [HttpGet]
        [Route("{id}")]

        public ActionResult<StudentGetDto> Get(int id)
        {
            return Ok(_studentServices.GetById(id));
        }
        [HttpGet]
        [Route("all")]

        public ActionResult<List<StudentGetAllDto>> getAll()
        {
            return Ok(_studentServices.GetAll());
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult Edit (int id , [FromForm] StudentEditDto dto)
        {

            _studentServices.Edit(id, dto);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]


        public IActionResult Delete(int id)
        {
            _studentServices.Delete(id);
            return NoContent();
        }
    }
}
