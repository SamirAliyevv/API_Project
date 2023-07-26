using ApiTask.core.Repositories;
using ApiTask.Service.Dtos.GroupDtos;
using ApiTask.Service.Dtos.StudentDtos;
using ApiTask.Service.Implementations;
using ApiTask.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupServices _groupServices;


        public GroupController(IGroupRepository groupRepository, IStudentRepository studentRepository, IGroupServices groupServices)
        {

            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
            _groupServices = groupServices;
        }


        [HttpGet]
        [Route("all")]

        public ActionResult<List<GroupGetAllDto>> getAll()
        {
            return Ok(_groupServices.GetAll());

        }


        [HttpGet]
        [Route("{id}")]

        public ActionResult<GroupGetDto> Get(int id)
        {

            return Ok(_groupServices.GetById(id));
        }


        [HttpPost]
        [Route("")]
        public IActionResult Create([FromForm] GroupCreatDto dto)
        {
            return StatusCode(201, _groupServices.Create(dto));


        }




        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult Edit(int id, [FromForm] GroupEditDto dto)
        {

            _groupServices.Update(id, dto);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]


        public IActionResult Delete(int id)
        {
            _groupServices.Delete(id);
            return NoContent();
        }





    }
}