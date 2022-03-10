using AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class PageModelBase : PageModel
    {
        public AssessmentDBContext Database { get; set; }
        public int? ID { get; set; }
        public Operator CurrentOperator { get; set; }
        public string Message { get; set; }


        public PageModelBase(AssessmentDBContext database)
        {
            Database = database;
        }

        public void SetMessage(string message)
        {
            ViewData["Message"] = message;
        }

        public bool NotValid(out RedirectToPageResult result)
        {
            ID = HttpContext.Session.GetInt32("ID");
            if (ID != null)
            {
                CurrentOperator = Database.Operators.FirstOrDefault(s => s.Id == ID);
            }
            if (CurrentOperator == null)
            {
                result = RedirectToPage("/auth/login");
                return true;
            }
            result = null;
            return false;
        }
    }
}


//Scaffold-DbContext "Server=142.44.243.3;Database=AssessmentDB;User=sa;password=SA123!@#asd" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models -Force
// 16 * 12 inch maziat nesbi chon kare dast mibare we need a design !


