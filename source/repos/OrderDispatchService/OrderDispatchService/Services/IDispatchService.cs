using Microsoft.AspNetCore.Mvc;
using OrderDispatchService.DTOs;

namespace OrderDispatchService
{
    public interface IDispatchService
    {
        JsonResult GetOrder(int OrderId);

        IActionResult SaveOrder(Order order);

        IActionResult DeleteDispatch(string OrderRef);
    }
}