using System;
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
    }
}