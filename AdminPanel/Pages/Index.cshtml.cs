using AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class IndexModel : PageModelBase
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(AssessmentDBContext database) : base(database)
        {
        }

        public IActionResult OnGet()
        {
            if(NotValid(out var action))
            {
                return action;
            }

            return Page();
        }
    }
}