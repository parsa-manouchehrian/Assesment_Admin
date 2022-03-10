#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Models;

namespace AdminPanel.Pages.Category
{
    public class IndexModel : PageModelBase
    {
        public IndexModel(AssessmentDBContext database) : base(database)
        {
        }

        public IList<AssessmentResultGroup> AssessmentResultGroup { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if(NotValid(out var result))
            {
                return result;
            }
            AssessmentResultGroup = await Database.AssessmentResultGroups.ToListAsync();

            return Page();
        }
    }
}
