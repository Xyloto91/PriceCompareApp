using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Model
{
    public class ElkondAutoSearchData
    {
        public bool status { get; set; }
        public string msg { get; set; }
        public Products products { get; set; }
        public Categories categories { get; set; }
        public Tags tags { get; set; }
    }

    public class Products
    {
        public bool status { get; set; }
        public string msg { get; set; }
        public ElkondItem[] items { get; set; }
        public bool more { get; set; }
    }

    public class ElkondItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pic_1 { get; set; }
        public string cikkszam { get; set; }
        public string cikkszam_2 { get; set; }
        public string price_pdv { get; set; }
        public string keyword { get; set; }
        public string keywords { get; set; }
        public string keyword_ids { get; set; }
        public string status { get; set; }
        public string relevance { get; set; }
        public string cat_id { get; set; }
        public string cat_id_2 { get; set; }
        public string cat_id_3 { get; set; }
        public string old_price { get; set; }
        public string pdv { get; set; }
        public string quantity_discount { get; set; }
        public string picture { get; set; }
        public string pic_orig_1 { get; set; }
        public string pic_resized_1 { get; set; }
        public string url { get; set; }
        public int user_discount { get; set; }
    }

    public class Categories
    {
        public object status { get; set; }
        public string msg { get; set; }
        public object[] items { get; set; }
    }

    public class Tags
    {
        public object status { get; set; }
        public string msg { get; set; }
        public object[] items { get; set; }
    }
}
