using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class HomeEmployeeDetailModel
    {
        public string PageTitle { get; set; }
        public Employee Employee { get; set; }
    }
}
