using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using OrderDispatchService;
using OrderDispatchService.DTOs;

namespace OrderDipatchTest
{
    class FakeDispatchService : IDispatchService
    {

        public FakeDispatchService (DispatchService ds)
        {
        }

        IActionResult IDispatchService.DeleteDispatch(string OrderRef)
        {
            throw new NotImplementedException();
        }

        JsonResult IDispatchService.GetOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        IActionResult IDispatchService.SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

