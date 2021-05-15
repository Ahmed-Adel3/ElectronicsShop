using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ElectronicsShop.ViewComponents
{
    public class CulturePicker : ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> localizationOptions;

        public CulturePicker(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            this.localizationOptions = localizationOptions;
        }

        public IViewComponentResult Invoke()
        {
            var cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var model = new CulturePickerModel
            {
                SupportedCultures = localizationOptions.Value.SupportedUICultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.UICulture
            };
            HttpContext.Response.Cookies.Append(".AspNetCore.Culture", cultureFeature.RequestCulture.UICulture.Name, new Microsoft.AspNetCore.Http.CookieOptions());
            return View(model);
        }
    }
    public class CulturePickerModel
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
