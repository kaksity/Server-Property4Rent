using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using Server.Models.Location;

namespace Server.DataAccess.Location
{
    public class LocationRepository : ILocationRepository
    {

        private readonly IConfiguration _configuration;
        public LocationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        IDbConnection dbConnection
        {
            get{
                return new FbConnection(_configuration.GetConnectionString("firebird"));
            }
        }

        public async Task CreateLgaAsync(LgaModel model)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"INSERT INTO lgas (Id,StateId, Name, IsDeleted, CreatedAt, UpdatedAt) VALUES (@Id,@StateId,@Name,@IsDeleted,@CreatedAt,@UpdatedAt)";
                    await connection.ExecuteAsync(query,model);                   
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task CreateStateAsync(StateModel model)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"INSERT INTO states (Id, Name, IsDeleted, CreatedAt, UpdatedAt) VALUES (@Id,@Name,@IsDeleted,@CreatedAt,@UpdatedAt)";
                    await connection.ExecuteAsync(query,model);                   
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task DeleteLgaAsync(string id)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"UPDATE lgas SET IsDeleted = true WHERE Id=@Id AND IsDeleted=false";
                    await connection.ExecuteAsync(query,new {
                        Id = id
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteStateAsync(string id)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"UPDATE states SET IsDeleted = true WHERE Id=@Id AND IsDeleted=false";
                    await connection.ExecuteAsync(query,new {
                        Id = id
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<LgaModel>> GetAllLgasAsync(string stateId)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = "SELECT Id, Name FROM lgas WHERE StateId = @StateId AND IsDeleted=false ORDER BY Name ASC";
                    return await connection.QueryAsync<LgaModel>(query, new {StateId = stateId});
                }                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<StateModel>> GetAllStatesAsync()
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = "SELECT Id, Name FROM states WHERE IsDeleted=false ORDER BY Name ASC";
                    return await connection.QueryAsync<StateModel>(query);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<LgaModel> GetLgaByIdAsync(string id)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"SELECT Id,StateId, Name,IsDeleted FROM lgas WHERE Id=@Id AND IsDeleted=false";
                    return await connection.QueryFirstOrDefaultAsync<LgaModel>(query,new {
                        Id = id
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StateModel> GetStateByIdAsync(string id)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"SELECT Id, Name,IsDeleted FROM states WHERE Id=@Id AND IsDeleted=false";
                    return await connection.QueryFirstOrDefaultAsync<StateModel>(query,new {
                        Id = id
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StateModel> GetStateByNameAsync(string stateName)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"SELECT Id, Name,IsDeleted FROM states WHERE Name=@Name AND IsDeleted=false";
                    
                    return await connection.QueryFirstOrDefaultAsync<StateModel>(query,new {
                        Name = stateName
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}