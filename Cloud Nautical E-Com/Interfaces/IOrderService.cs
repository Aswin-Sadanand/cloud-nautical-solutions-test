using Cloud_Nautical_E_Com_.Models;

namespace Cloud_Nautical_E_Com_.Interfaces
{
    public interface IOrderService
    {
        OrderDetails GetRecentOrders(RecentReq req);
    }
}
