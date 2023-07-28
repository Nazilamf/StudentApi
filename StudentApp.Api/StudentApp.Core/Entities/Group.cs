using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Core.Entities
{
    public class Group:BaseEntity
    {
        public string GroupNo { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
