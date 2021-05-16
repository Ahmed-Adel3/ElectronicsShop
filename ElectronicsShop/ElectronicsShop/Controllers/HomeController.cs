using DataAccessLayer.Data;
using ElectronicsShop.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace ElectronicsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Home.cshtml");
        }

        public IActionResult Navigate(int pageNum)
        {
            var data = _unitOfWork.ProductRepository.GetProductsWithPaging(pageNum,5);
            var culture  = Request.Cookies[".AspNetCore.Culture"];
            var productsViewModel = data.Select(a => new ProductCardViewModel(a , culture)).ToList();
            var totalCount = _unitOfWork.ProductRepository.All.Count();
            var isLastPage = pageNum * 5 >= totalCount && (pageNum - 1)*5 < totalCount;
            var homeViewModel = new HomeViewModel(productsViewModel, pageNum, pageNum == 1 , isLastPage);
            return new JsonResult(homeViewModel);
        }
    }
}
