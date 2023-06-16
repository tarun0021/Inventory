﻿using Inventory.Repositary.Paging;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositary.CustomerService
{
    public interface ICustomerRepo
    {
        Task<PaginatedList<CustomerListViewModel>> GetAll(int pageSize, int pageNumber);
    }
}
