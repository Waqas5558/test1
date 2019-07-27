using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ControlPanel.Model.Connection;
using ControlPanel.Model.Domain;

namespace ControlPanel.Pages.Source
{
    public class CreateModel : PageModel
    {
        private readonly ControlPanel.Model.Connection.GenericControlPanel_DBContext _context;

        public CreateModel(ControlPanel.Model.Connection.GenericControlPanel_DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ExceptionSource ExceptionSource { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ExceptionSource.Add(ExceptionSource);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}