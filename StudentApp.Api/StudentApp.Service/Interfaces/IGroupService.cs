using StudentApp.Service.Dtos.GroupDtos;
using StudentApp.Service.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Service.Interfaces
{
    public interface IGroupService
    {
        CreatedResultDto Create(GroupCreateDto createDto);

        void Edit(int id, GroupEditDto editDto);
        GroupGetDto GetById(int id);
        List<GroupGetAllItemsDto> GetAll();
        void remove(int id);
    }
}
