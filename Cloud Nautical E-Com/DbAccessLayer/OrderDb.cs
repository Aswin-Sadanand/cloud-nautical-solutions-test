using Azure.Core;
using Cloud_Nautical_E_Com_.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace Cloud_Nautical_E_Com_.DbAccessLayer
{
    public class OrderDb
    {
        private readonly IConfiguration _config;
        public OrderDb(IConfiguration config) { 
            _config = config;
        }

        public OrderDetails GetRecentOrdersByCustomer(RecentReq req)
        {
            try
            {
                string connectionString = _config.GetValue<string>("ConnectionString");
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var jsonResult = connection.QuerySingle<string>(
                    "[GetRecentOrdersByCustomer]",
                        new { CustomerId = req.customerId, Email = req.user },
                        commandType: CommandType.StoredProcedure
                    );

                    var orderDetails = JsonConvert.DeserializeObject<OrderDetails>(jsonResult);
                    return orderDetails;                    
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
