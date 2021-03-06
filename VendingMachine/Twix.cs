﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Twix : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public int ProductCode { get; set; }

        public Twix(string name, double price, double quantity, int code)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            ProductCode = code;
        }

        public override string ToString()
        {
            return string.Format($"       {Name:15}          {Quantity}g         {Price:C2}           {ProductCode:00}\n");
        }
    }
}
