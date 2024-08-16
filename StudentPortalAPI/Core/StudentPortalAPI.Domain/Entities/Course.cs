using StudentPortalAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Domain.Entities
{
    public class Course : BaseEntity
    {
        public Course() => Students = new HashSet<Student>();
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
