﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Reviefy.API.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Name { get; set; }
        public int? Age { get; set; }
        public bool IsCorrect { get; set; } = true;
       
        public void OnGet(string name, int? age)
        {
            if (age is null or < 1 or > 110 || string.IsNullOrEmpty(name))
            {
                IsCorrect = false;
                return;
            }
            Age = age;
            Name = name;
        }
    }
}