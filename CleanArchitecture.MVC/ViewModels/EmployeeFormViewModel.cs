using CleanArchitecture.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanArchitecture.MVC.ViewModels
{
    public class EmployeeFormViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public Employee Employee { get; set; }
    }
}