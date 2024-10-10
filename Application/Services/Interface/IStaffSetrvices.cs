using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IStaffSetrvices
    {

        Task<StaffDto> GetByIdAsync(int id);
        Task<IEnumerable<StaffDto>> GetAllAsync();
        Task<StaffDto> CreateAsync(CreateStaffDto createStaffDto);
        Task DeleteAsync(int id);

        Task UpdateAsync(UpdateStaffDto updateStaffDto);
    }
}
