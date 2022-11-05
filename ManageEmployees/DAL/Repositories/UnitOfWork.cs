using DAL.Database;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ManageEmployeesDatabaseContext _context;

        private IEmployeesRepository _employeeRepository;

        public UnitOfWork(ManageEmployeesDatabaseContext context)
        {
            _context = context;
        }

        public IEmployeesRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeesRepository(_context);
                }
                return _employeeRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
