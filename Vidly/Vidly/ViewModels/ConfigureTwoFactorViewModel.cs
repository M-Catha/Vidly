﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace Vidly.ViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}