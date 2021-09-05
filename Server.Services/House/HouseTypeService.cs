using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.DataAccess.House;
using Server.Dtos.House;
using Server.Models.House;

namespace Server.Services.House
{
    public class HouseTypeService : IHouseTypeService
    {
        private readonly IHouseTypeRepository _houseTypeRepository;
        public HouseTypeService(IHouseTypeRepository houseTypeRepository)
        {
            _houseTypeRepository = houseTypeRepository;
        }
        public async Task CreateHouseTypeAsync(RequestHouseTypeDto dto)
        {
            var houseType = new HouseTypeModel {
                Id = Guid.NewGuid().ToString(),
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

        public async Task<IEnumerable<HouseTypeModel>> GetAllHouseTypesAsync()
        {
            return await _houseTypeRepository.GetAllHouseTypesAsync();
        }

        public async Task<HouseTypeModel> GetHouseTypeByIdAsync(string id)
        {
            return await _houseTypeRepository.GetHouseTypeByIdAsync(id);
        }
    }
}