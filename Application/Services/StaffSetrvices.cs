using Application.DTO;
using Application.Services.Interface;
using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StaffSetrvices : IStaffSetrvices
    {

        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;

        public StaffSetrvices(IStaffRepository StaffRepository, IMapper mapper)
        {
            _staffRepository = StaffRepository;
            _mapper = mapper;
        }

        public async Task<StaffDto> CreateAsync(CreateStaffDto createStaffDto)
        {
            var Product = _mapper.Map<Staff>(createStaffDto);
            var CreatedEntity = await _staffRepository.CreateAsync(Product);
            var entity = _mapper.Map<StaffDto>(CreatedEntity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var Product = await _staffRepository.GetByIdAsync(x => x.Id == id);
            await _staffRepository.DeleteAsync(Product);
        }

        public async Task<IEnumerable<StaffDto>> GetAllAsync()
        {
            var Staffs = await _staffRepository.GetAllAsync();
            return _mapper.Map<List<StaffDto>>(Staffs);
        }

        public async Task<StaffDto> GetByIdAsync(int id)
        {
            var getstaff = await _staffRepository.GetByIdAsync(x => x.Id == id);
            return _mapper.Map<StaffDto>(getstaff);
        }

        public async Task UpdateAsync(UpdateStaffDto updateStaffDto)
        {
            var updatesfaff = _mapper.Map<Staff>(updateStaffDto);
            await _staffRepository.UpdateAsync(updatesfaff);
        }
    }
}
