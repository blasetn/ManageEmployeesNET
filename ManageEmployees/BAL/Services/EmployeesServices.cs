using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Employee;
using DAL.Database.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public EmployeesServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.GetAll());
        }
        public string Create(EmployeeCreateModel employee)
        {
            if (CheckInput(employee))
            {
                Employees emp = _mapper.Map<Employees>(employee);
                return _unitOfWork.Employee.CheckPhone(emp.Phone) == false || _unitOfWork.Employee.CheckEmail(emp.Email) == false ? "0" : _unitOfWork.Employee.Create(emp);
            }
            else
            {
                return "00";
            }
        }
        public string Delete(int id)
        {
            return _unitOfWork.Employee.Delete(id).ToString();
        }

        public bool CheckInput(EmployeeCreateModel employee)
        {
            string patternName = @"^.{5,50}$";
            string patternEmail = @"^[\w-\.]+@([\w-\.])+[\w-]$";
            string patternAddress = @"^.{5,255}$";
            string patternPhone = @"^\d{10}$";
            // Create a Regex  
            Regex regxName = new Regex(patternName);
            Regex regxEmail = new Regex(patternEmail);
            Regex regxAddress = new Regex(patternAddress);
            Regex regxPhone = new Regex(patternPhone);

            if (string.IsNullOrEmpty(employee.Name) || (!regxName.IsMatch(employee.Name))) return false;
            if (string.IsNullOrEmpty(employee.Email) || (!regxEmail.IsMatch(employee.Email))) return false;
            if (string.IsNullOrEmpty(employee.Address) || (!regxAddress.IsMatch(employee.Address))) return false;
            if (string.IsNullOrEmpty(employee.Phone) || (!regxPhone.IsMatch(employee.Phone))) return false;
            return true;
        }
    }
}
