using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Core.Entities;
using StudentApp.Service.Dtos.StudentDtos;
using StudentApp.Service.Interfaces;

namespace StudentApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService=studentService;
        }



        [HttpPost("")]
        public IActionResult Create(StudentCreateDto studentDto)
        {
            return StatusCode(201, _studentService.Create(studentDto));

        }

        [HttpGet("{id}")]
        public ActionResult<StudentGetDto> Get(int id)
        {
            return Ok(_studentService.GetById(id));

        }

        [HttpGet("all")]
        public ActionResult<List<StudentGetAllItemDto>> GetAll()
        {
            return Ok(_studentService.GetAll());
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            _studentService.Remove(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, StudentEditDto studentDto)
        {
            _studentService.Edit(id, studentDto);

            return NoContent();
        }
    }
}
