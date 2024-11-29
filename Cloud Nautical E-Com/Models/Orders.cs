using System.ComponentModel.DataAnnotations;

namespace Cloud_Nautical_E_Com_.Models
{
    public class RecentReq
    {
        /// <summary>
        /// Email Address of the customer
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength =1)]
        public string user { get; set; }

        /// <summary>
        /// Id of the customer
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string customerId { get; set; }
    }

    public class RecentOrders
    {
        public customer customer { get; set; }
        public order order { get; set; }
    }

    public class customer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class order
    {
        public string orderNumber { get; set; }
        public string orderDate { get; set; }
        public string deliveryAddress { get; set; }
        public orderItems[] orderItems { get; set; }
        public string deliveryExpected { get; set; }
    }


    public class orderItems
    {
        public string product { get; set; }
        public int quantity { get; set; }
        public decimal priceEach { get; set; }
    }

    public class OrderDetails
    {
        public RecentOrders[] orderDetails { get; set; }  
        public string errorMessage { get; set; }
    }

}
