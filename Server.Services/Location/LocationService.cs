using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Server.DataAccess.Location;
using Server.Dtos.Lga;
using Server.Dtos.State;
using Server.Models.Location;

namespace Server.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        public async Task CreateLgaAsync(RequestLgaDto dto)
        {
            var lga = new LgaModel{
                LgaId = Guid.NewGuid().ToString(),
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
                StateId = Guid.NewGuid().ToString(),
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

        public async Task<IEnumerable<ReadLgaDto>> GetAllLgasAsync(string stateId)
        {
            var lgas = await _locationRepository.GetAllLgasAsync(stateId);

            return _mapper.Map<IEnumerable<ReadLgaDto>>(lgas);
        }

        public async Task<IEnumerable<StateModel>> GetAllStatesAsync()
        {
            return await _locationRepository.GetAllStatesAsync();
        }

        public async Task<ReadLgaDto> GetLgaByIdAsync(string id)
        {
            var lga = await _locationRepository.GetLgaByIdAsync(id);
            return _mapper.Map<ReadLgaDto>(lga);
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