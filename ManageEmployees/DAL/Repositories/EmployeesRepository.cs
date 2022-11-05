using DAL.Database;
using DAL.Database.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ManageEmployeesDatabaseContext _context;
        public EmployeesRepository(ManageEmployeesDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Employees> GetAll()
        {
            return _context.Employees.AsEnumerable();
        }
        
        public string Create(Employees employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee.Id.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Delete(int employee)
        {
            try
            {
                Employees emp = _context.Employees.Find(employee);
                if (emp != null)
                {
                    _context.Employees.Remove(emp);
                    _context.SaveChanges();
                    return "Delete Success";
                }
                else
                {
                    return "Not Found";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckPhone(string Phone)
        {
            try
            {
                Employees emp = _context.Employees.Where(module => module.Phone.Equals(Phone)).FirstOrDefault();
                if (emp != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
        public bool CheckEmail(string Email)
        {
            try
            {
                Employees emp = _context.Employees.Where(module => module.Email.Equals(Email)).FirstOrDefault();
                if (emp != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
