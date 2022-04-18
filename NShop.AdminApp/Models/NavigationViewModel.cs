﻿using NShop.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NShop.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageVm> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
        public string ReturnUrl { get; set; }
    }
}