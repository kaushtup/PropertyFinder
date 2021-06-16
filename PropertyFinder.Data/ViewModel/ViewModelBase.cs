using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyFinder.Data.ViewModel
{
    public abstract class ViewModelBase
    {
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
