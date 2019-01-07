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
        public IActionResult Get([FromBody]int OrderRef)
        {
            try
            {
                return new OkObjectResult(_ds.GetOrder(OrderRef));
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: api/Dispatch
        [HttpPost]
        public IActionResult Post([FromBody] Order Order)
        {
            try
            {
                var res = _ds.SaveOrder(Order);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int OrderRef)
        {
            try
            {
                var res = _ds.DeleteDispatch(OrderRef);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
