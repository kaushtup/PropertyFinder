using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyFinder.Data.ViewModel
{
    public class PhotoViewModel
    {
        public string Name { get; set; }

        public bool DelStatus { get; set; }

        public string File { get; set; }

    }
}
