using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener.Validations
{
    public class Validation
    {
        private readonly URLShortenerContext _context;

        public Validation(URLShortenerContext context)
        {
            _context = context;
        }
        public bool masterUrlValidateDuplicate(Urlshortener obToAdd)
        {
            if (_context.Urlshorteners.Any(a => a.UrlShort == obToAdd.UrlShort))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool masterUrlcheckHttpsFormat(string url)
        {
            if (!Regex.IsMatch(url, @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
