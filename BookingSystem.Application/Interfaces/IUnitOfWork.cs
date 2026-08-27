using BookingSystem.Application.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace BookingSystem.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IServiceRepository Services { get; }

        Task<int> SaveChangesAsync();
    }
}