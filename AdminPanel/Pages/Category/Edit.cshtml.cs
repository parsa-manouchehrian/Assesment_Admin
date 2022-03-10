#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Models;

namespace AdminPanel.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly AdminPanel.Models.AssessmentDBContext _context;

        public EditModel(AdminPanel.Models.AssessmentDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentResultGroup AssessmentResultGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssessmentResultGroup = await _context.AssessmentResultGroups.FirstOrDefaultAsync(m => m.Id == id);

            if (AssessmentResultGroup == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AssessmentResultGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentResultGroupExists(AssessmentResultGroup.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AssessmentResultGroupExists(int id)
        {
            return _context.AssessmentResultGroups.Any(e => e.Id == id);
        }
    }
}
