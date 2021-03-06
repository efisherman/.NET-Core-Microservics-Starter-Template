using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models.Store;

namespace Server.Controllers
{
    [Route("api/v1/admin/orders")]
    public class ManageOrdersController : Controller
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            var response = new List<ManageOrderItemViewModel>
                {
                    new ManageOrderItemViewModel
                    {
                         Id = Guid.NewGuid(),
                         Shipping = "AHA",
                         ShippingLastName = "Alala",
                         Subtotal = 4
                    }
                };
            return Ok(response);
        }

        [HttpGet("statuses")]
        public IActionResult GetOrderStatuses()
        {
            var response = new List<ManageOrderItemViewModel>
                {
                    new ManageOrderItemViewModel
                    {
                         Id= Guid.NewGuid(),
                         Subtotal = 5,
                         ShippingLastName = "AAAA",
                         Shipping = "qqqqq"
                    }
                };
            return Ok(response);

        }

        [HttpGet("statuses/{statusId:guid}")]
        public IActionResult FindOrderStatus(Guid statusId)
        {
            var response = new EditOrderStatusViewModel
            {
                Id = Guid.NewGuid(),
                AddedBy = "aa",
                Title = "wwwww wwwww"
            };

            return Ok(response);
        }


        //TODO: Will be implemented later:
        /*
        [HttpGet]
        [Route("{orderId:guid}")]
        public IActionResult DeleteOrder(Guid orderId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{orderId:guid}")]
        public IActionResult OrderDetails(Guid orderId)
        {
            return Ok();
        }

        [HttpPost]
        //[HttpPut]
        [Route("{orderId:guid}")]
        public IActionResult UpdateOrderStatusId(Guid orderId, [FromBody]Guid statusId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("statuses/{statusId:guid}")]
        public IActionResult DeleteOrderStatus(Guid statusId)
        {
            return Ok();
        }
        [HttpPut]
        [Route("statuses/{statusId:guid}")]
        public IActionResult UpdateOrderStatus(Guid statusId, EditOrderStatusViewModel model)
        {
            return Ok();
        }

        [HttpPut]
        [Route("statuses")]
        public IActionResult InsertOrderStatus(AddOrderStatusViewModel model)
        {
            return Ok();
        }
        */
    }
}
