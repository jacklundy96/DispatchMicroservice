﻿using OrderDispatchService.DB;
using OrderDispatchService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDispatchService.Services
{
    public interface IDBService 
    {
        Order GetOrder(int OrderId);
        List<Order> GetOrders();
        void SaveOrder(Order order);
        void DeleteDispatch(string OrderRef);
    }

    public class DBService
    {
        private readonly OrderContext _context; 

        public DBService(OrderContext context)
        {
            _context = context; 
        }

        public Order GetOrder(int OrderId)
        {
            if (0 == _context.Orders.Count())
                return null;
                var first =  _context.Orders.FirstOrDefault(x => x.Id == OrderId);
                //if (first == default(someType)) // null for reference types.
               return first;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.Where(x => x.Id != -1).ToList();
        }

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteDispatch(string OrderRef)
        {
            _context.Orders.RemoveRange(_context.Orders.Where(x => x.OrderRef == OrderRef));
            _context.SaveChanges();
        }
    }
}