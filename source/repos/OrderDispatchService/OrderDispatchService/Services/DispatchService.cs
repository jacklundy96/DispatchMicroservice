using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderDispatchService.DB;
using OrderDispatchService.DTOs;
using OrderDispatchService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDispatchService
{
    public class DispatchService : IDispatchService

    {
        private readonly DBService _DBService;

         public DispatchService(DBService DBService)
        {
            _DBService = DBService; 
        }

        /// <summary>
        /// Returns the first order reccord matching the OrderId provided 
        /// </summary>
        /// <param name="OrderId"> unique identification number for the order</param>
        /// <returns></returns>
        public JsonResult GetOrder(int OrderId)
        {
            var result = _DBService.GetOrder(OrderId);
            if (result != null)

                return new JsonResult(result);
            else
                return new JsonResult("No records found");
        }

        /// <summary>
        /// Saves an new order to be dispatched into the database 
        /// </summary>
        /// <param name="order">The order object in question</param>
        /// <returns>IActionResult denoting request status</returns>
        public IActionResult SaveOrder(Order order)
        {
            int count = order.GetAll().Where(x => String.IsNullOrWhiteSpace(x) || String.IsNullOrEmpty(x)).Count();

            if (count > 0)
                return new BadRequestResult();
            else
                _DBService.SaveOrder(order);
            
            return new OkResult();
        }

        /// <summary>
        /// Deletes all of the order
        /// </summary>
        /// <param name="Order">The order object in question</param>
        /// <returns>IActionResult denoting request status</returns>
        public IActionResult DeleteDispatch(string OrderRef)
        {
            //check too see that all orders under the order reference haven't been dispatched if they have not we can delete them 
            var result = _DBService.GetOrders().Where(x => x.OrderRef.Equals(OrderRef));
            int noDispatched = result.Count() - result.Where(x => x.DispatchDate.Equals(Convert.ToDateTime("0001-01-01 00:00:00.0000000"))).Count();
            if (noDispatched == 0)
                _DBService.DeleteDispatch(OrderRef);
            else
                return new JsonResult("Cancellation not possible as some items have already been dispatched");
           
            return new OkResult();
        }
    }
}
