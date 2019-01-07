using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDispatchService.DB
{
    public static class DBInitializer
    {
        public static void Initialize(OrderContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
