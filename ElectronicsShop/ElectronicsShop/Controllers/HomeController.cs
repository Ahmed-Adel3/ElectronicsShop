using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using ElectronicsShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Linq;

namespace ElectronicsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public HomeController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IStringLocalizer<SharedResources> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
            _userManager = userManager;
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
            var homeViewModel = new GridViewModel<ProductCardViewModel>(productsViewModel, pageNum, pageNum == 1 , isLastPage, totalCount);
            return new JsonResult(homeViewModel);
        }

        [HttpGet]
        public IActionResult AddNewOrder()
        {
            return View("~/Views/Home/AddNewOrder.cshtml");
        }

        [HttpGet]
        public IActionResult GetProductDetails(int id)
        {
            var culture = Request.Query["culture"];
            var product = _unitOfWork.ProductRepository
                .FindBy(a => a.ProductId == id)
                .Include(a => a.ProductType)
                .FirstOrDefault();

            return Json(new ProductCardViewModel(product, culture));
        }

        [HttpPost]
        public IActionResult AddNewOrder(AddOrderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var availableItems = _unitOfWork.ProductRepository.GetQuantityInStock(model.ProductId);
            if(model.Quantity > availableItems)
            {
                ModelState.AddModelError("", _localizer["MaxQuantityExceeded"]);
                return View(model);
            }

            var product = _unitOfWork.ProductRepository.FindBy(a => a.ProductId == model.ProductId).FirstOrDefault();
            product.QuantityInStock -= model.Quantity;

            var newOrder = new ProductOrder
            {
                Product = product,
                QuantityOrdered = model.Quantity,
                Client = _userManager.FindByNameAsync(User.Identity.Name).Result
            };
            _unitOfWork.ProductOrderRepository.Add(newOrder);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
