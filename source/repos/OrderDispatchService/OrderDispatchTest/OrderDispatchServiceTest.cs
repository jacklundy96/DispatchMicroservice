using System;
using Xunit;
using Moq;
using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using OrderDispatchService.DB;
using OrderDispatchService;
using Microsoft.AspNetCore.Mvc;
using OrderDispatchService.DTOs;
using System.Collections.Generic;
using System.Collections;
using OrderDispatchService.Services;
using System.Linq;

namespace OrderDispatchTest
{
    public class OrderDispatchServiceTest
    {
        private List<Order> orders;
        private static int DbIndex = 1;

        private static DbContextOptions<OrderContext> options;

        public OrderDispatchServiceTest()
        {
            var now = DateTime.Now;
            orders = new List<Order>()
            {
                new Order
                {
                    OrderRef = "4",
                    ProductRef = "3",
                    Address = "23 new street", 
                    Quantity = 1,
                    OrderDate = now,
                    DispatchDate = Convert.ToDateTime("0001-01-01 00:00:00.0000000")
                },
                new Order
                {
                    OrderRef = "4",
                    ProductRef = "7",
                    Address = "23 new street",
                    Quantity = 6,
                    OrderDate = now,
                    DispatchDate = Convert.ToDateTime("0001-01-01 00:00:00.0000000")
                },
                new Order
                {
                    OrderRef = "5",
                    ProductRef = "9",
                    Address = "23 new street",
                    Quantity = 5,
                    OrderDate = now,
                    DispatchDate = Convert.ToDateTime("0001-01-01 00:00:00.0000000")
                },
                new Order
                {
                    OrderRef = "5",
                    ProductRef = "10",
                    Address = "23 new street",
                    Quantity = 5,
                    OrderDate = now,
                    DispatchDate = Convert.ToDateTime("0001-01-01 00:00:00.0000000")
                },
                new Order
                {
                    OrderRef = "6",
                    ProductRef = "2",
                    Address = "23 new street",
                    Quantity = 3,
                    OrderDate = now,
                    DispatchDate = now
                },
                new Order
                {
                    OrderRef = "6",
                    ProductRef = "6",
                    Address = "23 new street",
                    Quantity = 3,
                    OrderDate = now,
                    DispatchDate = now
                }
            };
            options = new DbContextOptionsBuilder<OrderContext>()
               .UseInMemoryDatabase(databaseName: "In memory Test database")
               .Options;
        }

        [Fact]
        public void GetOrder_InvalidCall()
        {
            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new OrderContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);
                var _ds = new DispatchService(_dbs);
                context.Orders.Add(orders[0]);
                context.SaveChanges();
                //Act
                var order = _ds.GetOrder(-1);
                //Assert 
                Assert.Null(order);
            }
        }

        [Fact]
        public void GetOrder_ValidCall()
        {
            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new OrderContext(options))
            {
                //Arrange
                var DBService = new DBService(context);
                var _ds = new DispatchService(DBService);

                context.Orders.Add(orders[0]);
                context.SaveChanges();
                DbIndex++;
                //Act
                var order = _ds.GetOrder(DbIndex);
                //Assert 
                Assert.NotNull(order);
                Assert.Equal(orders[0], order);
            }
        }

        [Fact]
        public void SaveOrder_ValidCall()
        {
            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new OrderContext(options))
            {
                //Arrange
                var DBService = new DBService(context);
                var _ds = new DispatchService(DBService);
                var first = context.Orders.FirstOrDefault(x => x.Id == DbIndex);
                //Act
                _ds.SaveOrder(orders[0]);
                DbIndex++;
                //Assert
                var order = _ds.GetOrder(DbIndex);
                Assert.Equal(orders[0], order);
            }
        }

        [Fact]
        public void SaveOrder_InCompleteData()
        {
            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new OrderContext(options))
            {
                //Arrange
                var DBService = new DBService(context);
                var _ds = new DispatchService(DBService);

                var o = orders[0];
                o.Address = null;
                o.OrderRef = "";
                //Act
                _ds.SaveOrder(o);
                //Assert
                var first = context.Orders.FirstOrDefault(x => x.Id == (DbIndex + 1));
                Assert.Null(first);
            }
        }

        [Fact]
        public void DeleteOrder_InvalidData()
        {
            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new OrderContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);
                var _ds = new DispatchService(_dbs);
                //Act
                var result = _ds.DeleteDispatch("kjfgkdfjg");
                //Assert 
                Assert.False(result);
            }
        }

        [Fact]
        public void DeleteOrder_AlreadyDispatched()
        {
            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new OrderContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);
                var _ds = new DispatchService(_dbs);
             
                _ds.SaveOrder(orders[4]);
                _ds.SaveOrder(orders[5]);
                DbIndex += 2;
                //Act
                var result = _ds.DeleteDispatch("6");
                //Assert 
                Assert.False(result);
            }
        }

        [Fact]
        public void DeleteOrder_NotDispatchedDelete()
        {
            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new OrderContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);
                var _ds = new DispatchService(_dbs);

                _ds.SaveOrder(orders[2]);
                _ds.SaveOrder(orders[3]);
                DbIndex += 2;
                //Act
                var result = _ds.DeleteDispatch("5");
                //Assert 
                Assert.True(result);
            }
        }
    }
}
