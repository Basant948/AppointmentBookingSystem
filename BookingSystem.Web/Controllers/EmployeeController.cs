using BookingSystem.Application.DTOs.Employee;
using BookingSystem.Domain.Entities;
using BookingSystem.Infrastructure.Data; 
using BookingSystem.Infrastructure.Identity;
using BookingSystem.Web.Models;
using BookingSystem.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public EmployeeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            var employeeIds = employees.Select(e => e.Id).ToList();

            var employeeRecords = await _context.Employees
                .Where(e => employeeIds.Contains(e.UserId))
                .ToListAsync();

            var model = employees
                .Select(e =>
                {
                    var record = employeeRecords.FirstOrDefault(r => r.UserId == e.Id);
                    return new EmployeeListVm
                    {
                        Id = e.Id,
                        Name = $"{e.FName} {e.Lname}",
                        Email = e.Email!,
                        IsActive = record?.IsActive ?? true
                    };
                })
                .Where(e => e.IsActive) 
                .ToList();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View(new CreateEmployeeDto());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var employee = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FName = dto.Fname,
                Lname = dto.Lname
            };

            var result = await _userManager.CreateAsync(employee, dto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(dto);
            }

            await _userManager.AddToRoleAsync(employee, "Employee");


            _context.Employees.Add(new Employee
            {
                UserId = employee.Id,
                IsActive = true
            });
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Employee created successfully.";

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var record = await _context.Employees.FirstOrDefaultAsync(e => e.UserId == id);

            var model = new EmployeeDetailsVm
            {
                Id = employee.Id,
                Name = $"{employee.FName} {employee.Lname}",
                Email = employee.Email!,
                IsActive = record?.IsActive ?? true
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new EditEmployeeDto
            {
                Id = employee.Id,
                Fname = employee.FName,
                Lname = employee.Lname,
                Email = employee.Email!
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var employee = await _userManager.FindByIdAsync(dto.Id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.FName = dto.Fname;
            employee.Lname = dto.Lname;

            if (!string.Equals(employee.Email, dto.Email, StringComparison.OrdinalIgnoreCase))
            {
                employee.Email = dto.Email;
                employee.UserName = dto.Email;
                employee.NormalizedEmail = dto.Email.ToUpperInvariant();
                employee.NormalizedUserName = dto.Email.ToUpperInvariant();
            }

            var result = await _userManager.UpdateAsync(employee);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(dto);
            }

            TempData["SuccessMessage"] = "Employee updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var record = await _context.Employees.FirstOrDefaultAsync(e => e.UserId == id);

            if (record == null)
            {
                record = new Employee { UserId = id, IsActive = false };
                _context.Employees.Add(record);
            }
            else
            {
                record.IsActive = false;
            }

            await _userManager.SetLockoutEnabledAsync(employee, true);
            await _userManager.SetLockoutEndDateAsync(employee, DateTimeOffset.MaxValue);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Employee deactivated successfully.";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(new ChangeEmployeePasswordVm
            {
                EmployeeId = employee.Id
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangeEmployeePasswordVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var employee = await _userManager.FindByIdAsync(model.EmployeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(employee);

            var result = await _userManager.ResetPasswordAsync(
                employee,
                token,
                model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}