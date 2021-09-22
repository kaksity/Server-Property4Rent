using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Server.DataAccess.House;
using Server.Dtos.House;
using Server.Models.House;

namespace Server.Services.House
{
    public class HouseTypeService : IHouseTypeService
    {
        private readonly IHouseTypeRepository _houseTypeRepository;
        private readonly IMapper _mapper;
        public HouseTypeService(IHouseTypeRepository houseTypeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _houseTypeRepository = houseTypeRepository;
        }
        public async Task CreateHouseTypeAsync(CreateHouseTypeDto dto)
        {
            var houseType = new HouseTypeModel {
                HouseTypeId = Guid.NewGuid().ToString(),
                Name = dto.Name.ToUpper(),
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _houseTypeRepository.CreateHouseTypeAsync(houseType);
        }

        public async Task DeleteHouseTypeAsync(string id)
        {
            await _houseTypeRepository.DeleteHouseTypeAsync(id);
        }

        public async Task<IEnumerable<ReadHouseTypeDto>> GetAllHouseTypesAsync()
        {
            var houseTypes = await _houseTypeRepository.GetAllHouseTypesAsync();
            return _mapper.Map<IEnumerable<ReadHouseTypeDto>>(houseTypes);
        }

        public async Task<ReadHouseTypeDto> GetHouseTypeByIdAsync(string id)
        {
            var houseType = await _houseTypeRepository.GetHouseTypeByIdAsync(id);
            return _mapper.Map<ReadHouseTypeDto>(houseType);
        }
    }
}