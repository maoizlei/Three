﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreePage.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { set; get; }

        public string Location { get; set; }

        public int EmployeeCount { get; set; }
    }
}
