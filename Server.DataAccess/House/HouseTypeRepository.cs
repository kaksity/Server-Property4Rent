using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using Server.Models.House;

namespace Server.DataAccess.House
{
    public class HouseTypeRepository : IHouseTypeRepository
    {
        private readonly IConfiguration _configuration;
        public HouseTypeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        IDbConnection dbConnection
        {
            get
            {
                return new FbConnection(_configuration.GetConnectionString("firebird"));
            }
        }

        public async Task CreateHouseTypeAsync(HouseTypeModel model)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"INSERT INTO HouseTypes(Id,Name,IsDeleted,CreatedAt,UpdatedAt) VALUES (@Id,@Name,@IsDeleted,@CreatedAt,@UpdatedAt)";
                    await connection.ExecuteAsync(query,model);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task DeleteHouseTypeAsync(string id)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = @"UPDATE housetypes SET Isdeleted = true WHERE Id = @Id AND IsDeleted=false";    
                    await connection.ExecuteAsync(query,new { Id = id});
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<HouseTypeModel>> GetAllHouseTypesAsync()
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = "SELECT Id,Name,CreatedAt,UpdatedAt FROM housetypes WHERE isDeleted=false ORDER BY Name ASC"; 
                    return await connection.QueryAsync<HouseTypeModel>(query);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<HouseTypeModel> GetHouseTypeByIdAsync(string id)
        {
            try
            {
                using (IDbConnection connection = dbConnection) 
                {
                    string query = "SELECT Id,Name,CreatedAt,UpdatedAt FROM housetypes WHERE Id = @Id AND IsDeleted=false";
                    return await connection.QueryFirstOrDefaultAsync<HouseTypeModel>(query,new {Id = id});
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}