using AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Pages
{
    public class LoginModel : PageModelBase
    {
        public LoginModel(AssessmentDBContext database) : base(database)
        {
        }

        [EmailAddress]
        [Required(ErrorMessage = "you need to fill all the required field")]
        [BindProperty]
        public string Email { get; set; }


        [Required(ErrorMessage = "you need to fill all the required field")]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPostLogin()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password)) {
                Message = "All fields are required";
                return Page();
            }

            var op = Database.Operators.FirstOrDefault(s=>s.Email.Equals(Email)
            && s.Password == Password);

            if(op == null)
            {
                Message = "User not founded in the system";
                return Page();
            }

            HttpContext.Session.SetInt32("ID", op.Id);

            return RedirectToPage("/index");
        }

    }
}
