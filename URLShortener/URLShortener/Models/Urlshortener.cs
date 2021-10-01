using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace URLShortener.Models
{
    public partial class Urlshortener
    {
        public int UrlId { get; set; }
        //[Url(ErrorMessage = "That not even a URL bro?")]
        [Required(ErrorMessage = "Empty URl ? seriously bro ?")]
        public string UrlMaster { get; set; }
        public string UrlShort { get; set; }
    }
}
