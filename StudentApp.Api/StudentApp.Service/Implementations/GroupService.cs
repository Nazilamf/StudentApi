using StudentApp.Service.Dtos.GroupDtos;
using StudentApp.Core.Repositories;
using StudentApp.Service.Dtos.Common;
using StudentApp.Service.Exceptions;
using StudentApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StudentApp.Core.Entities;
using Group = StudentApp.Core.Entities.Group;
using AutoMapper;

namespace StudentApp.Service.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository,IMapper mapper)
        {
            _groupRepository=groupRepository;
            _mapper=mapper;
        }
        public CreatedResultDto Create(GroupCreateDto createDto)
        {
            if (_groupRepository.IsExist(x => x.GroupNo == createDto.GroupNo))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "GroupNo", "GroupNo already taken");

            }

            //var entity = new Group
            //{
            //    GroupNo= createDto.GroupNo
            //};

            var entity = _mapper.Map<Group>(createDto);


            _groupRepository.Add(entity);
            _groupRepository.Commit();

            return new CreatedResultDto { Id = entity.Id };
        }

        public void Edit(int id, GroupEditDto editDto)
        {
            var entity = _groupRepository.Get(x => x.Id == id);
            if (entity == null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Group not found by id{id}");

            }

            if (entity.GroupNo != editDto.GroupNo && _groupRepository.IsExist(x => x.GroupNo==editDto.GroupNo))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "GroupNo", "GroupNo already taken");

            }

            entity.GroupNo = editDto.GroupNo;
            _groupRepository.Commit();
        }

        public List<GroupGetAllItemsDto> GetAll()
        {
            var dtos = _groupRepository.GetQueryable(x => true).Select(x => new GroupGetAllItemsDto
            {
                Id= x.Id,
                GroupNo = x.GroupNo,
            }).ToList();
            return dtos;
        }

        public GroupGetDto GetById(int id)
        {
            var entity = _groupRepository.Get(x => x.Id == id, "Students");
            if (entity == null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Group not found by id{id}");

            }

            //var dto = new GroupGetDto
            //{
            //    GroupNo= entity.GroupNo,
            //    StudentsCount = entity.Students.Count,
            //};


            //return dto;

            return _mapper.Map<GroupGetDto>(entity);
        }

        public void remove(int id)
        {
            var entity = _groupRepository.Get(x => x.Id == id, "Students");
            if (entity == null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Group not found by id{id}");

            }
            _groupRepository.Remove(entity);
            _groupRepository.Commit();
        }
    }
}
