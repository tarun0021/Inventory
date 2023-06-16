﻿using Inventory.Repositary;
using Inventory.Repositary.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductService
{
    public class ProductRepo : IProductRepo
    {
        private ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ProductListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var productList = _context.Products;
            var vm = productList.ModelToVM().AsQueryable();
            return await PaginatedList<ProductListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }
    }
}
