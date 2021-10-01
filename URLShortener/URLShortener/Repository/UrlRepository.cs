using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;
using URLShortener.Validations;

namespace URLShortener.Repository
{
    public class UrlRepository : IUrlRepository
    {

        private readonly URLShortenerContext _context;
        private readonly RandomURl _urlrand;
        private readonly Validation _validate;

        public UrlRepository(URLShortenerContext context, RandomURl urlrand)
        {
            _context = context;
            _urlrand = urlrand;
            _validate = new Validation(new URLShortenerContext());
        }

        public Urlshortener addUrl(string url)
        {
            if (!_validate.masterUrlcheckHttpsFormat(url))
            {
                return null;
            }
            var obToAdd = new Urlshortener { UrlMaster = url, UrlShort = _urlrand.getShortUrl() };
            if (_validate.masterUrlValidateDuplicate(obToAdd))
            {
                return null;
            }
            _context.Add(obToAdd);
            _context.SaveChanges();
            return obToAdd;
        }

        public Urlshortener getUrlMaster(string url)
        {
            var URLobject = _context.Urlshorteners.Where(a => a.UrlShort == url).FirstOrDefault();
            return URLobject;
        }

    }
}
