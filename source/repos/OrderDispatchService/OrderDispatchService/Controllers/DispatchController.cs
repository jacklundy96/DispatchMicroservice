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

        // GET: api/Dispatch
        [HttpGet]
        public IActionResult Get([FromBody]Order order)
        {
            try
            {
                return new JsonResult(_ds.GetOrder(order.Id));
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: api/Dispatch
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                int count = order.GetAll().Where(x => String.IsNullOrWhiteSpace(x) || String.IsNullOrEmpty(x)).Count();

                if (count > 0)
                    return BadRequest();
                else
                {
                    var res = _ds.SaveOrder(order);
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete([FromBody]Order order)
        {
            try
            {
                var res = _ds.DeleteDispatch(order.OrderRef);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
