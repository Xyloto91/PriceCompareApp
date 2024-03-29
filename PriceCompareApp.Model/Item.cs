﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Model
{
    public class Item
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public bool Processed { get; set; }

        public bool HasData => !string.IsNullOrEmpty(Name);

        public override string ToString()
        {
            return $"Code: {Code}, Name: {Name}, Price: {Price}, HasData: {HasData}";
        }

    }
}
