using Cloud_Nautical_E_Com_.Interfaces;
using Cloud_Nautical_E_Com_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_Nautical_E_Com_.Controllers
{

    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [Authorize]
        [HttpPost]
        [Route("api/orders")]
        public async Task<IActionResult> Post([FromBody] RecentReq req)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var orderResponse = _orderService.GetRecentOrders(req);
                //if that order contais a gift the product name replace as gift is handled in procedure
                // if customerid and email is not in customer table it also return as a messege  from the procedure
                //if the entered req is correct it will provide the output correclty


                if (orderResponse != null)
                {
                    if (!string.IsNullOrEmpty(orderResponse.errorMessage))
                    {
                        return NotFound(orderResponse.errorMessage);
                    }
                    else
                    {
                        return Ok(orderResponse.orderDetails[0]);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
