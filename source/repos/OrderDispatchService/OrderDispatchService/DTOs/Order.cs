using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDispatchService.DTOs
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //some form of reference back to the originating order; more than one dispatch per order is permitted.
        public int OrderRef { get; set; }
        // sufficiently unique for the dispatchers to identify the product to send, ideally a foreign key into another ThAmCo db, but it must not be a foreign key to the third party suppliers.
        public string ProductRef { get; set; }
        //number of the product to dispatch.
        public int Quantity { get; set; }
        // the postal address to which to deliver the products; should include the name of the person to which it is being delivered.
        public string Address { get; set; }
        // : the datetime the order was added to this dispatch database.
        public DateTime OrderDate { get; set; }
        //the datetime the dispatch was processed and completed; must be nullable; changes made to the row will be ignored by the dispatch process after this column has value.
        public DateTime DispatchDate { get; set; }
    }
}
