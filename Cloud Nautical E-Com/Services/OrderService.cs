using Cloud_Nautical_E_Com_.DbAccessLayer;
using Cloud_Nautical_E_Com_.Interfaces;
using Cloud_Nautical_E_Com_.Models;

namespace Cloud_Nautical_E_Com_.Services
{
    public class OrderService: IOrderService
    {
        private readonly IConfiguration _config;
        public OrderService(IConfiguration config)
        {
            _config = config;
        }
        public OrderDetails GetRecentOrders(RecentReq req)
        {
            try
            {
                OrderDb objDb = new OrderDb(_config);
                var recentOrders = objDb.GetRecentOrdersByCustomer(req);
                return recentOrders;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
