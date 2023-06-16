﻿using Inventory.Models;
using Inventory.Repositary.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositary.BillService
{
    public class BillRepo : IBillRepo
    {
        private ApplicationDbContext _context;

        public BillRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<BillListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var bills = _context.Bills;
            var vm = bills.ModelToVM().AsQueryable();
            return await PaginatedList<BillListViewModel>.CreateAsync( vm, pageNumber, pageSize);
        }
    }
}
