using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Models
{
        public class ViewModel
        {
            public Employee employee { get; set; }
            public Department department { get; set; }
            public Person people { get; set; }
            public EmployeeDepartmentHistory histories { get; set; }
        }
}