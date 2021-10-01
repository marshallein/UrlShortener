using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener.Repository
{
    public interface IUrlRepository
    {
        Urlshortener addUrl(string url);
        Urlshortener getUrlMaster(string url);
    }
}
