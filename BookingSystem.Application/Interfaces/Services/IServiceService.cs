using BookingSystem.Application.DTOs;
using BookingSystem.Application.DTOs.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Application.Interfaces.Services
{
    public interface IServiceService
    {
        Task<ServiceDto?> GetByIdAsync(int id);
        Task<IEnumerable<ServiceDto>> GetAllAsync();
        Task<IEnumerable<ServiceDto>> GetActiveServicesAsync();
        Task<ServiceDto> CreateAsync(CreateServiceDto dto);
        Task<bool> UpdateAsync(int id, UpdateServiceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}