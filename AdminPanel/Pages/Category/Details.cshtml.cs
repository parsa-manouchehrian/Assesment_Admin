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
    public class DetailsModel : PageModelBase
    {
        public DetailsModel(AssessmentDBContext database) : base(database)
        {
        }

        public AssessmentResultGroup AssessmentResultGroup { get; set; }

        [BindProperty]
        public ResultTip NewHint { get; set; } = new ResultTip();

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

            AssessmentResultGroup = await Database.AssessmentResultGroups.Where(m => m.Id == id)
                .Include(s=>s.ResultTips).FirstOrDefaultAsync();

            if (AssessmentResultGroup == null)
            {
                return NotFound();
            }
            return Page();
        }


        public IActionResult OnPostHint()
        {
            try
            {
                if (NotValid(out var result))
                {
                    return result;
                }

                if (NewHint == null)
                {
                    throw new Exception("Value should not be null");
                }

                if (string.IsNullOrWhiteSpace(NewHint.Content))
                {
                    throw new Exception("Value should not be null");
                }

                AssessmentResultGroup.ResultTips.Add(NewHint);

                Database.SaveChanges();

                NewHint = new ResultTip();

                Message = "Submitted";

                return Page();
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }
    }
}
