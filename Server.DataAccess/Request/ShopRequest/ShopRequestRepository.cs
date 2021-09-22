using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using Server.Models.Request;

namespace Server.DataAccess.Request.ShopRequest
{
    public class ShopRequestRepository : IShopRequestRepository
    {
        private readonly IConfiguration _configuration;
        public ShopRequestRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        IDbConnection dbConnection{
            get{
                return new FbConnection(_configuration.GetConnectionString("firebird"));
            }
        }
        public async Task AddShopRequestAsync(ShopRequestModel model)
        {
            try
            {
                using(IDbConnection connection = dbConnection)
                {
                    string sqlQuery = @"
                        INSERT INTO 
                            SHOPREQUESTS (SHOPREQUESTID, FULLNAME, PHONENUMBER, SHOPNEARESTLANDMARK, STATEID, LGAID, DESCRIPTION, MINPRICE, MAXPRICE,ISDELETED, CREATEDAT, UPDATEDAT)
                        VALUES (
                            @ShopRequestId, 
                            @FullName, 
                            @PhoneNumber, 
                            @ShopNearestLandMark, 
                            @StateId, 
                            @LgaId, 
                            @Description, 
                            @MinPrice, 
                            @MaxPrice, 
                            @IsDeleted, 
                            @CreatedAt, 
                            @UpdatedAt
                        );
                    ";
                    await connection.ExecuteAsync(sqlQuery,model);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ShopRequestModel>> GetAllShopRequestsAsync()
        {
            try
            {
                using (IDbConnection connection = dbConnection)
                {
                    string sqlQuery = @"
                        SELECT 
                            SHOPREQUESTID,FULLNAME,PHONENUMBER,SHOPNEARESTLANDMARK,STATEID,LGAID,DESCRIPTION,MINPRICE,MAXPRICE,ISDELETED,CREATEDAT,UPDATEDAT
                        FROM
                            SHOPREQUESTS 
                        WHERE
                            IsDeleted = false ;
                        ";
                    return await connection.QueryAsync<ShopRequestModel>(sqlQuery);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ShopRequestModel> GetShopRequestAsync(string shopRequestId)
        {
            try
            {
                using(IDbConnection connection = dbConnection)
                {
                     string sqlQuery = @"
                        SELECT 
                            SHOPREQUESTID,FULLNAME,PHONENUMBER,SHOPNEARESTLANDMARK,STATEID,LGAID,DESCRIPTION,MINPRICE,MAXPRICE,ISDELETED,CREATEDAT,UPDATEDAT
                        FROM
                            SHOPREQUESTS 
                        WHERE
                            ShopRequestId = @ShopRequestId AND IsDeleted = false;
                        ";
                   
                    return await connection.QueryFirstOrDefaultAsync<ShopRequestModel>(sqlQuery,new { shopRequestId = shopRequestId});
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}