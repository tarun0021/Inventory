﻿using Inventory.Repositary.Paging;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositary.CustomerType
{
    public interface ICustomerTypeRepo
    {
        Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageSize, int pageNumber);
    }
}
