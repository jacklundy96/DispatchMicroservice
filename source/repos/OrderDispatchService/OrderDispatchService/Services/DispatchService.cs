using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderDispatchService.DB;
using OrderDispatchService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDispatchService
{
    public class DispatchService
    {
        //private readonly OrderContext _context;

         public DispatchService()
        {
            //OrderContext context
            //_context = context; 
        }

        /// <summary>
        /// Returns the first order reccord matching the OrderId provided 
        /// </summary>
        /// <param name="OrderId"> unique identification number for the order</param>
        /// <returns></returns>
        public IActionResult GetOrder(int OrderId)
        {
            //var result = _context.Orders.First(x => x.Id == OrderId);
            //if (result != null)
            //    return new OkObjectResult(result);
            //else
                return new NotFoundResult();
        }

        /// <summary>
        /// Updates an order providing the legacy dispatch database has not already picked it up
        /// </summary>
        /// <param name="OrderId"> unique identification number for the order </param>
        /// <returns>IActionResult denoting request status</returns>
        public IActionResult UpdateOrder(int OrderId)
        {
            //_context.Orders.Find();
            return new OkResult();
        }

        /// <summary>
        /// Saves an new order to be dispatched into the database 
        /// </summary>
        /// <param name="order">The order object in question</param>
        /// <returns>IActionResult denoting request status</returns>
        public IActionResult SaveOrder([FromBody] Order order)
        {
           // _context.Orders.Add(order);
           // _context.SaveChanges();

            return new OkResult();
        }

        /// <summary>
        /// Deletes all of the order
        /// </summary>
        /// <param name="Order">The order object in question</param>
        /// <returns>IActionResult denoting request status</returns>
        public IActionResult DeleteDispatch(int id)
        {
            //_context.Orders.RemoveRange(_context.Orders.Where(x => x.OrderRef == id));
            //_context.SaveChanges();
            return new OkResult();
        }

    }
}
