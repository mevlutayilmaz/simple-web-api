using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.ViewModels.Courses
{
    public class VM_Update_Course
    {
        public string Id { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
    }
}
