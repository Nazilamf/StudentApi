using StudentApp.Service.Dtos.StudentDtos;
using StudentApp.Core.Entities;
using StudentApp.Core.Repositories;
using StudentApp.Service.Dtos.Common;
using StudentApp.Service.Exceptions;
using StudentApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace StudentApp.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IGroupRepository groupRepository,IMapper mapper)
        {
            _studentRepository=studentRepository;
             _groupRepository=groupRepository;
            _mapper=mapper;
        }
        public CreatedResultDto Create(StudentCreateDto dto)
        {
            if (!_groupRepository.IsExist(x => x.Id == dto.GroupId))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "GroupId", $"Group not found by id{dto.GroupId}");
            }
            if (_studentRepository.IsExist(x => x.FullName== dto.FullName))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "FullName", $"FullName already taken");
            }

            //var entity = new Student
            //{
            //    GroupId = dto.GroupId,
            //    FullName = dto.FullName,
            //    Point=dto.Point

            //};

            var entity = _mapper.Map<Student>(dto);

            _studentRepository.Add(entity);
            _studentRepository.Commit();

            return new CreatedResultDto { Id=entity.Id };
        }

        public void Edit(int id, StudentEditDto editDto)
        {
            var entity = _studentRepository.Get(x => x.Id == id);

            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Student not found by id: {id}");

            if (entity.GroupId != editDto.GroupId && !_groupRepository.IsExist(x => x.Id == editDto.GroupId))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "GroupId", "GroupId not found");

            if (entity.FullName != editDto.FullName && _studentRepository.IsExist(x => x.FullName == editDto.FullName))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "FullName", "FullName already taken");

            entity.FullName = editDto.FullName;
            entity.GroupId = editDto.GroupId;
            entity.Point = editDto.Point;

            _studentRepository.Commit();

        }

        public List<StudentGetAllItemDto> GetAll()
        {
            var dtos = _studentRepository.GetQueryable(x => true, "Group").Select(x => new StudentGetAllItemDto
            {
                Id= x.Id,
                FullName= x.FullName,
                GroupNo=x.Group.GroupNo
            }).ToList();
            return dtos;
        }

        public StudentGetDto GetById(int id)
        {
            var entity = _studentRepository.Get(x => x.Id == id, "Group");
            if (entity== null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Student not found by id{id}");
            }

            //return new StudentGetDto
            //{
            //    FullName= entity.FullName,
            //    Point=entity.Point,
            //    Group = new StudentinGroupDto
            //    {
            //        Id = entity.Group.Id,
            //        GroupNo= entity.Group.GroupNo,
            //    }
            //};

            return _mapper.Map<StudentGetDto>(entity);
        }

        public void Remove(int id)
        {
            var entity = _studentRepository.Get(x => x.Id == id);

            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Student not found by id: {id}");

            _studentRepository.Remove(entity);
            _studentRepository.Commit();
        }
    }
}
