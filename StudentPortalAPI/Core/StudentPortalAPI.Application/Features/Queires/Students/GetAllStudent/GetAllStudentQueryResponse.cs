﻿using StudentPortalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Queires.Students.GetAllStudent
{
    public class GetAllStudentQueryResponse
    {
        public IQueryable<Student> Students { get; set; }
    }
}
