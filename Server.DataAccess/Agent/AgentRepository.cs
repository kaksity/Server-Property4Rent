using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
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
                return new FbConnection(_configuration.GetConnectionString("firebird"));
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
                        string query = "INSERT INTO agents(AgentId, PhoneNumber, Password, IsDeleted, CreatedAt, UpdatedAt) VALUES (@AgentId,@PhoneNumber,@Password,@IsDeleted,@CreatedAt,@UpdatedAt)";
                        await connection.ExecuteAsync(query,agentModel,transaction);
                        
                        query = "INSERT INTO agentbiodetails(AgentBioDetailId,AgentId,FullName,NIN,DateOfBirth,EmailAddress,ContactAddress,IsDeleted,CreatedAt,UpdatedAt) VALUES(@AgentBioDetailId,@AgentId,@FullName,@NIN,@DateOfBirth,@EmailAddress,@ContactAddress,@IsDeleted,@CreatedAt,@UpdatedAt)";
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
            try
            {
                using(IDbConnection connection = dbConnection){
                    connection.Open();
                    string query = @"SELECT AgentId, PhoneNumber,Password, IsDeleted, CreatedAt, UpdatedAt FROM agents WHERE PhoneNumber=@PhoneNumber AND IsDeleted=false";
                    var result = await connection.QueryFirstOrDefaultAsync<AgentModel>(query,new {PhoneNumber=phoneNumber});
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}