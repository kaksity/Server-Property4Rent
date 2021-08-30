using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Server.Models.Agents;

namespace Server.DataAccess.Agent
{
    public class AgentRepository : IAgentRepository
    {
        private readonly IConfiguration _configuration;

        public AgentRepository(IConfiguration config)
        {
            _configuration = config;
        }
        private IDbConnection dbConnection{
            get{
               
                return new MySqlConnection(_configuration.GetConnectionString("default"));
            }
        }
        public async Task CreateAgent(AgentModel agentModel, AgentBioDetailModel agentBioDetailModel)
        {
            try
            {
                using(IDbConnection connection = dbConnection){
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    try
                    {
                        string query = "INSERT INTO `agents`(`Id`, `PhoneNumber`, `Password`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES (@Id,@PhoneNumber,@Password,@IsDeleted,@CreatedAt,@UpdatedAt)";
                        await connection.ExecuteAsync(query,agentModel,transaction);
                        
                        query = "INSERT INTO agentbiodetails(Id,AgentId,FullName,NIN,DateOfBirth,EmailAddress,ContactAddress,IsDeleted,CreatedAt,UpdatedAt) VALUES(@Id,@AgentId,@FullName,@NIN,@DateOfBirth,@EmailAddress,@ContactAddress,@IsDeleted,@CreatedAt,@UpdatedAt);";
                        await connection.ExecuteAsync(query,agentBioDetailModel,transaction);
                        transaction.Commit();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        connection.Close();
                        throw ex;
                    }


                }   
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        // public async Task<AgentModel> GetAgentById(string id)
        // {
        //     try
        //     {
        //         using(IDbConnection connection = dbConnection){
        //             string query = "SELECT * FROM `agents` WHERE `Id`=@Id AND `IsDeleted`=0";
        //             return await connection.QueryFirstOrDefaultAsync<AgentModel>(query,new {Id=id});
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }

        public async Task<AgentModel> GetAgentByPhoneNumber(string phoneNumber)
        {
            //try
            //{
                using(IDbConnection connection = dbConnection){
                    string query = @"SELECT `Id`, `PhoneNumber`, `Password`, `IsDeleted`, `CreatedAt`, `UpdatedAt` FROM `agents` WHERE `PhoneNumber`=@PhoneNumber AND `IsDeleted`=0";
                    return await connection.QueryFirstOrDefaultAsync<AgentModel>(query,new {PhoneNumber=phoneNumber});
                }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}