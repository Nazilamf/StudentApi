using StudentApp.Core.Entities;
using StudentApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentApp.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private readonly StudentDbContext _context;

        public GroupRepository(StudentDbContext context) : base(context)
        {
            _context=context;
        }
    }
}
