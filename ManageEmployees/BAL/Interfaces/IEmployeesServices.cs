using BLL.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeesServices
    {
        IEnumerable<EmployeeViewModel> GetAll();
        string Create(EmployeeCreateModel employeeCreate);
        string Delete(int id);
        bool CheckInput(EmployeeCreateModel employeeCreate);
    }
}
