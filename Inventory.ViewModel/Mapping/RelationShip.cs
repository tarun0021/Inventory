using Inventory.Models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Mapping
{
    public static class Relationship
    {
       public static IEnumerable<CustomerTypeListViewModel> ModelToVM(this IEnumerable<CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> list = new List<CustomerTypeListViewModel>();
            foreach (var ct in customerType)
            {
                list.Add(new CustomerTypeListViewModel()
                {
                    CustomerTypeId = ct.CustomerTypeId,
                    CustomerTypeName = ct.CustomerTypeName,
                    Description = ct.Description

                });
            }
            return list;

        }

        public static IEnumerable<CustomerListViewModel> ModelToVM(this IEnumerable<Models.Customer> customers)
        {
            List<CustomerListViewModel> list = new List<CustomerListViewModel>();
            foreach (var ct in customers)
            {
                list.Add(new CustomerListViewModel()
                {
                    CustomerId = ct.CustomerId,
                    CustomerName = ct.CustomerName,
                    City = ct.City,
                    ContactPerson = ct.ContactPerson,
                    CustomerTypeId = ct.CustomerTypeId,
                    PinCode = ct.PinCode,
                    Address = ct.Address,
                    Phone = ct.Phone,
                    Email = ct.Email,
                    Country = ct.Country,
                    State = ct.State

                });
            }
            return list;

        }

        public static IEnumerable<Inventory.ViewModel.Bill.BillTypeListViewModel> ModelToVM(this IEnumerable<BillType> billTypes)
        {
            List<BillTypeListViewModel> list = new List<BillTypeListViewModel>();
            foreach (var ct in billTypes)
            {
                list.Add(new BillTypeListViewModel()
                {
                    BillTypeId = ct.BillTypeId,
                    BillTypeName = ct.BillTypeName,
                    Description = ct.Description
                });

            }
            return list;
        }

        public static IEnumerable<Inventory.ViewModel.Bill.BillListViewModel> ModelToVM(this IEnumerable<Inventory.Models.Bill> bills)
        {
            List<BillListViewModel> list = new List<BillListViewModel>();
            foreach (var ct in bills)
            {
                list.Add(new BillListViewModel()
                {
                    BillId = ct.BillId,
                    BillDate = ct.BillDate,
                    BillDueDate = ct.BillDueDate,
                    GoodsReceivedNoteId = ct.GoodsReceivedNoteId,
                    BillName = ct.BillName,
                    BillTypeId=ct.BillTypeId,
                    VendorDoNumber=ct.VendorDoNumber,
                    VendorInvoiceNumber=ct.VendorInvoiceNumber
                    
                   
                });

            }
            return list;
        }

        public static IEnumerable<ProductListViewModel> ModelToVM(this IEnumerable<Inventory.Models.Product> products)
        {
            List<ProductListViewModel> list = new List<ProductListViewModel>();
            foreach (var ct in products)
            {
                list.Add(new ProductListViewModel()
                {
                    ProductId = ct.ProductId,
                    ProductName = ct.ProductName,
                    ProductCode = ct.ProductCode,
                    ProductImage = ct.ProductImage,
                    BuyingPrice = ct.BuyingPrice,
                    SellingPrice = ct.SellingPrice,
                    BarCode = ct.BarCode,
                    BranchId = ct.BranchId,
                    CurrencyId = ct.CurrencyId,
                    Description = ct.Description,
                    MeasureUnitId = ct.MeasureUnitId
                   
                });
            }
            return list;

        }
        public static IEnumerable<ProductTypeListViewModel> ModelToVM(this IEnumerable<Inventory.Models.ProductType> productTypes)
        {
            List<ProductTypeListViewModel> list = new List<ProductTypeListViewModel>();
            foreach (var ct in productTypes)
            {
                list.Add(new ProductTypeListViewModel()
                {
                    ProductTypeId = ct.ProductTypeId,
                    ProductTypeName = ct.ProductTypeName,
                    ProductDescription = ct.ProductDescription
                    
                });
            }
            return list;

        }
    }
}
