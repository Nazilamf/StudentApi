using StudentApp.Service.Dtos.GroupDtos;
using StudentApp.Service.Dtos.StudentDtos;
using StudentApp.Service.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Service.Interfaces
{
    public interface IStudentService
    {
        CreatedResultDto Create(StudentCreateDto dto);
        StudentGetDto GetById(int id);

        void Edit(int id, StudentEditDto editDto);

        void Remove(int id);

        List<StudentGetAllItemDto> GetAll();
    }
}
