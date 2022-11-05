using DAL.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employees> GetAll();
        string Create(Employees employee);
        string Delete(int employee);
        bool CheckPhone(string Phone);
        bool CheckEmail(string Email);
    }
}
