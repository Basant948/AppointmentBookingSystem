using BookingSystem.Application.Interfaces;
using BookingSystem.Application.Interfaces.Repositories;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IServiceRepository? _services;
        private bool _disposed;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IServiceRepository Services =>
            _services ??= new ServiceRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}