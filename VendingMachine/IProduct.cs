using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        double Quantity { get; set; }
        int ProductCode { get; set; }

    }
}
