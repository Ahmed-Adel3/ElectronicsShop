using DataAccessLayer.Data;
using ElectronicsShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ElectronicsShop.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminPanelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var culture = Request.Cookies[".AspNetCore.Culture"];
            ViewBag.ProductTypes = _unitOfWork.ProductTypeRepository.All.Select(a => new ProductTypesViewModel(a, culture));
            return View("~/Views/AdminPanel/AdminPanel.cshtml");
        }
        public IActionResult GetGridData(int pageNum)
        {
            var data = _unitOfWork.ProductRepository.GetHomePageProducts(pageNum, 10);
            var culture = Request.Cookies[".AspNetCore.Culture"];
            var productsRowViewModel = data.Select(a => new ProductRowViewModel(a, culture)).ToList();
            var totalCount = _unitOfWork.ProductRepository.All.Count();
            var isLastPage = pageNum * 5 >= totalCount && (pageNum - 1) * 5 < totalCount;
            var gridViewModel = new ProductGridViewModel(productsRowViewModel, pageNum, pageNum == 1, isLastPage);
            return new JsonResult(gridViewModel);
        }
    }
}
