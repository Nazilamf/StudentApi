using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Service.Dtos.GroupDtos;
using StudentApp.Core.Repositories;
using StudentApp.Data;
using StudentApp.Service.Interfaces;
using StudentApp.Service.Implementations;
using StudentApp.Service.Exceptions;
using StudentApp.Core.Entities;




namespace StudentApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
           
            _groupService=groupService;
        }

        [HttpGet("all")]
        public ActionResult<List<GroupGetAllItemsDto>> GetAll()
        {
            var groups = _groupService.GetAll();

            return Ok(groups);
        }

        [HttpGet("{id}")]
        public ActionResult<GroupCreateDto> Get(int id)
        {

            var brand = _groupService.GetById(id);
            return Ok(brand);


        }


        [HttpPost]
        [Route("")]
       public IActionResult Create(GroupCreateDto groupDto)
        {
            try
            {
                var result = _groupService.Create(groupDto);

                return StatusCode(201, result);
            }
            catch (EntityDublicateException e)
            {
                ModelState.AddModelError("FullName", e.Message);
                return BadRequest(ModelState);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Edit(int id, GroupEditDto groupDto)
        {
            try
            {
                _groupService.Edit(id, groupDto);


            }
            catch (NotFoundException e)
            {
                return NotFound();
            }
            catch (EntityDublicateException e)
            {
                ModelState.AddModelError("FullName", "FullName is already taken");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _groupService.remove(id);
            }
            catch (NotFoundException e)
            {

                return NotFound();
            }

            return NoContent();
        }

    }
}
