using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using URLShortener.Models;
using URLShortener.Validations;
using URLShortener.Repository;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IUrlRepository _urlrepo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _urlrepo = new UrlRepository(new URLShortenerContext(), new RandomURl());
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult getURlShortened(Urlshortener url)
        {
            try
            {
                // Model validation 
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }
                var urlshort = _urlrepo.addUrl(url.UrlMaster);
                if (urlshort == null)
                {
                    ModelState.AddModelError("UrlMaster", "Maybe the Url has taken by another Url, Try again!");
                    return View("Index");
                }
                ViewBag.shortlink = urlshort.UrlShort;
                return View("Success");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Some error have been occur";
                return View("Index");
            }
        }

        [HttpGet]
        [Route("/{url}")]
        public IActionResult getURl([FromRoute] string url)
        {
            try
            {
                var URLobject = _urlrepo.getUrlMaster(url);
                if (URLobject == null)
                {
                    return View("NotFound");
                }
                ViewBag.URLMaster = URLobject.UrlMaster;
                return View("Link");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Some error have been occur";
                return View("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
