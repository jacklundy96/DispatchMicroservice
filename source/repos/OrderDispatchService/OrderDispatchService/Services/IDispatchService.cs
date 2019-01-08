using Microsoft.AspNetCore.Mvc;
using OrderDispatchService.DTOs;

namespace OrderDispatchService
{
    public interface IDispatchService
    {
        Order GetOrder(int OrderId);

        bool SaveOrder(Order order);

        bool DeleteDispatch(string OrderRef);
    }
}