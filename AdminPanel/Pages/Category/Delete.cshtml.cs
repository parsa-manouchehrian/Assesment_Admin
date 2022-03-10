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
    public class DeleteModel : PageModelBase
    {
        public DeleteModel(AssessmentDBContext database) : base(database)
        {
        }

        [BindProperty]
        public AssessmentResultGroup AssessmentResultGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (NotValid(out var result))
            {
                return result;
            }

            if (id == null)
            {
                return NotFound();
            }

            AssessmentResultGroup = await Database.AssessmentResultGroups.FirstOrDefaultAsync(m => m.Id == id);

            if (AssessmentResultGroup == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (NotValid(out var result))
            {
                return result;
            }

            if (id == null)
            {
                return NotFound();
            }

            AssessmentResultGroup = await Database.AssessmentResultGroups.FindAsync(id);

            if (AssessmentResultGroup != null)
            {
                //Database.AssessmentResultGroups.Remove(AssessmentResultGroup);
                AssessmentResultGroup.IsActive = false;

                await Database.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
