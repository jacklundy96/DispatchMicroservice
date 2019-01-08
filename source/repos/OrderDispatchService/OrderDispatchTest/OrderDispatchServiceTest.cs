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

namespace OrderDispatchTest
{
    public class OrderDispatchServiceTest
    {
        List<Order> orders; 

        public OrderDispatchServiceTest ()
        {
            var now = DateTime.Now;
            orders = new List<Order>()
            {
                new Order
                {
                    Id = 1,
                    OrderRef = "4",
                    ProductRef = "3",
                    Quantity = 1,
                    OrderDate = now,
                    DispatchDate = Convert.ToDateTime("0001-01-01 00:00:00.0000000")
                },
                new Order
                {
                    Id = 2,
                    OrderRef = "4",
                    ProductRef = "7",
                    Quantity = 6,
                    OrderDate = now,
                    DispatchDate = Convert.ToDateTime("0001-01-01 00:00:00.0000000")
                },
                new Order
                {
                    Id = 3,
                    OrderRef = "5",
                    ProductRef = "9",
                    Quantity = 5,
                    OrderDate = now,
                    DispatchDate = now
                },
                new Order
                {
                    Id = 4,
                    OrderRef = "5",
                    ProductRef = "10",
                    Quantity = 5,
                    OrderDate = now,
                    DispatchDate = Convert.ToDateTime("0001-01-01 00:00:00.0000000")
                },
                new Order
                {
                    Id = 5,
                    OrderRef = "6",
                    ProductRef = "2",
                    Quantity = 3,
                    OrderDate = now,
                    DispatchDate = now
                },
                new Order
                {
                    Id = 6,
                    OrderRef = "6",
                    ProductRef = "6",
                    Quantity = 3,
                    OrderDate = now,
                    DispatchDate = now
                }
            };
        }

        [Fact]
        public void GetOrder_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDBService>()
                    .Setup(x => x.GetOrder(1))
                    .Returns(orders[1 -1 ]);

                var cls = mock.Create<DispatchService>();

                var expected = orders[0];
                var actual = cls.GetOrder(1);
        
                //Assert.True(actual. != null);
            }
        }

        [Fact]
        public void GetOrder_InvalidCall()
        {
            //using (var mock = GetLoose())
        }
    }
}
