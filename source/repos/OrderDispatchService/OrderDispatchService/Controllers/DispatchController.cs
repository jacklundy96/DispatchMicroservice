using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDispatchService.DTOs;

namespace OrderDispatchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        private readonly DispatchService _ds;

        public DispatchController(DispatchService ds)
        {
            _ds = ds;
        }

        // GET: api/Dispatch/{id}
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                var result = _ds.GetOrder(id);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound(new JsonResult("Unable to find error"));
            } catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        // POST: api/Dispatch
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                var res = _ds.SaveOrder(order);
                if (res)
                    return Ok();
                else
                    return new JsonResult("Unable to save the object at this time as a field is missing");
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete([FromBody]Order order)
        {
            try
            {
                var res = _ds.DeleteDispatch(order.OrderRef);
                if (res)
                    return Ok();
                else
                    return BadRequest("Cancellation not possible as some items have already been dispatched");
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
