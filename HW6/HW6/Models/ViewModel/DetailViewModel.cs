using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using HW6.Models;

namespace HW6.Models.ViewModel
{
    public class DetailViewModel
    {

        public class OrderCount
        {
            public int Count { get; set; }
            public string CompanyName { get; set; }
        }
        //...
        public IEnumerable<OrderCount> TopCustomers { get; private set; }

        private Regex pattern = new Regex("\"[A-Za-z]+\"");
        public DetailViewModel(StockItem stockItem)
        {
            StockItemID = stockItem.StockItemID;
            Name = stockItem.StockItemName;
            Size = stockItem.Size;
            Price = stockItem.RecommendedRetailPrice;
            Weight = stockItem.TypicalWeightPerUnit;
            LeadTimeDays = stockItem.LeadTimeDays;
            ValidFrom = stockItem.ValidFrom.ToString("MM/yyyy");
            Origin = pattern.Match(stockItem.CustomFields).NextMatch().ToString().Replace("\"","");
            Tags = stockItem.Tags.Replace("\"","").Replace("[", "").Replace("]", "");
            SupplierID = stockItem.SupplierID;
            Company = stockItem.Supplier.SupplierName;
            Phone = stockItem.Supplier.PhoneNumber;
            Fax = stockItem.Supplier.FaxNumber;
            Website = stockItem.Supplier.WebsiteURL;
            Contact = stockItem.Supplier.Person.FullName;
            Orders = stockItem.InvoiceLines.Count();
            GrossSales = stockItem.InvoiceLines.Sum(s => s.ExtendedPrice);
            GrossProfit = stockItem.InvoiceLines.Sum(s => s.LineProfit);
            TopCustomers = stockItem.InvoiceLines.Select(il => new OrderCount { Count = il.Quantity, CompanyName = il.Invoice.Customer.CustomerName })
                        .GroupBy(oc => oc.CompanyName)
                        .Select(a => new OrderCount { Count = a.Sum(b => b.Count), CompanyName = a.Key })
                        .OrderByDescending(a => a.Count)
                        .Take(10)
                        .ToList();
        }
        public int StockItemID { get; private set; }

        public string Name { get; private set; }

        public string Size { get; private set; }

        public decimal? Price { get; private set; }

        public decimal Weight { get; private set; }

        public int LeadTimeDays { get; private set; }

        public string ValidFrom { get; private set; }

        public string Origin { get; private set; }

        public string Tags { get; private set; }

        public int SupplierID { get; private set; }

        public string Company { get; private set; }

        public string Phone { get; private set; }

        public string Fax { get; private set; }

        public string Website { get; private set; }

        public string Contact { get; private set; }

        public int Orders { get; private set; }

        public decimal GrossSales { get; private set; }

        public decimal GrossProfit { get; private set; }
    }
}