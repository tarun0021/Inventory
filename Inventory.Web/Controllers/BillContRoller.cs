using Inventory.Repositary.BillTypeService;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class BillContRoller : Controller
    {
        private IBillTypeRepo _billTypeRepo;

        public BillContRoller(IBillTypeRepo billTypeRepo)
        {
            _billTypeRepo = billTypeRepo;
        }

        public async Task<IActionResult> Index(int pageSize=10, int pageNumber=1)
        {
            var billTypes = await _billTypeRepo.GetAll(pageSize, pageNumber);

            return View(billTypes);
        }
    }
}
