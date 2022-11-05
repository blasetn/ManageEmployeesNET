using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeesRepository Employee { get; }
    }
}
