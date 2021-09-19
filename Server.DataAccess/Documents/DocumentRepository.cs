using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Server.Models.Document;
using FirebirdSql.Data.FirebirdClient;
using System;
using Dapper;

namespace Server.DataAccess.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IConfiguration _configuration;
        
        public DocumentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        IDbConnection dbConnection{
            get{
                return new FbConnection(_configuration.GetConnectionString("firebird"));
            }
        }

        public async Task CreateDocumentAsync(DocumentModel model)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = "INSERT INTO documents(DocumentId,Name,IsDeleted,CreatedAt,UpdatedAt) VALUES (@DocumentId,@Name,@IsDeleted,@CreatedAt,@UpdatedAt)";
                    await connection.ExecuteAsync(query,model);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task DeleteDocumentAsync(string id)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = "UPDATE documents SET IsDeleted=true WHERE DocumentId = @Id AND IsDeleted = false";
                    await connection.ExecuteAsync(query,new { Id = id});
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<DocumentModel>> GetAllDocumentsAsync()
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = "SELECT DocumentId,Name FROM documents WHERE IsDeleted=false ORDER BY Name ASC";
                    return await connection.QueryAsync<DocumentModel>(query);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<DocumentModel> GetDocumentByIdAsync(string id)
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string query = "SELECT DocumentId,Name FROM documents WHERE DocumentId=@Id AND IsDeleted=false";
                    return await connection.QueryFirstOrDefaultAsync<DocumentModel>(query,new {Id=id});
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}