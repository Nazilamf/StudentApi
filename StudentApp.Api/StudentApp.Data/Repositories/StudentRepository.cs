using StudentApp.Core.Entities;
using StudentApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context) : base(context)
        {

        }
    }
}
