using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.DataAccess.Location;
using Server.Dtos.Lga;
using Server.Dtos.State;
using Server.Models.Location;

namespace Server.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task CreateLgaAsync(RequestLgaDto dto)
        {
            var lga = new LgaModel{
                Id = Guid.NewGuid().ToString(),
                StateId = dto.StateId,
                Name = dto.Name.ToUpper(),
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

           await _locationRepository.CreateLgaAsync(lga);
        }

        public async Task CreateStateAsync(RequestStateDto dto)
        {
            var state = new StateModel{
                Id = Guid.NewGuid().ToString(),
                Name = dto.Name.ToUpper(),
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _locationRepository.CreateStateAsync(state);
        }

        public async Task DeleteLgaAsync(string id)
        {
            await _locationRepository.DeleteLgaAsync(id);
        }

        public async Task DeleteStateAsync(string id)
        {
            await _locationRepository.DeleteStateAsync(id);
        }

        public async Task<IEnumerable<LgaModel>> GetAllLgasAsync(string stateId)
        {
            return await _locationRepository.GetAllLgasAsync(stateId);
        }

        public async Task<IEnumerable<StateModel>> GetAllStatesAsync()
        {
            return await _locationRepository.GetAllStatesAsync();
        }

        public async Task<LgaModel> GetLgaByIdAsync(string id)
        {
            return await _locationRepository.GetLgaByIdAsync(id);
        }

        public async Task<StateModel> GetStateByIdAsync(string id)
        {
            return await _locationRepository.GetStateByIdAsync(id);
        }

        public async Task<StateModel> GetStateByNameAsync(string stateName)
        {
            return await _locationRepository.GetStateByNameAsync(stateName.ToUpper());
        }
    }
}