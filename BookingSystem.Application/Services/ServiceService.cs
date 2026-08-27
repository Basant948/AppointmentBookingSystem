using BookingSystem.Application.DTOs;
using BookingSystem.Application.DTOs.Service;
using BookingSystem.Application.Interfaces;
using BookingSystem.Application.Interfaces.Services;
using BookingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceDto?> GetByIdAsync(int id)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(id);
            return service is null ? null : MapToDto(service);
        }

        public async Task<IEnumerable<ServiceDto>> GetAllAsync()
        {
            var services = await _unitOfWork.Services.GetAllAsync();
            return services.Select(MapToDto);
        }

        public async Task<IEnumerable<ServiceDto>> GetActiveServicesAsync()
        {
            var services = await _unitOfWork.Services.GetActiveServicesAsync();
            return services.Select(MapToDto);
        }

        public async Task<ServiceDto> CreateAsync(CreateServiceDto dto)
        {
            var service = new Service
            {
                Name = dto.Name,
                Price = dto.Price,
                Duration = dto.Duration,
                Description = dto.Description,
                IsActive = true
            };

            await _unitOfWork.Services.AddAsync(service);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(service);
        }

        public async Task<bool> UpdateAsync(int id, UpdateServiceDto dto)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(id);
            if (service is null)
                return false;

            service.Name = dto.Name;
            service.Price = dto.Price;
            service.Duration = dto.Duration;
            service.Description = dto.Description;
            service.IsActive = dto.IsActive;

            _unitOfWork.Services.Update(service);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(id);
            if (service is null)
                return false;

            _unitOfWork.Services.Delete(service);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static ServiceDto MapToDto(Service service)
        {
            return new ServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                Duration = service.Duration,
                Description = service.Description,
                IsActive = service.IsActive
            };
        }
    }
}