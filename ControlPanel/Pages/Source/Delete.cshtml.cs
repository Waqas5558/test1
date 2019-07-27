using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlPanel.Model.Connection;
using ControlPanel.Model.Domain;

namespace ControlPanel.Pages.Source
{
    public class DeleteModel : PageModel
    {
        private readonly ControlPanel.Model.Connection.GenericControlPanel_DBContext _context;

        public DeleteModel(ControlPanel.Model.Connection.GenericControlPanel_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExceptionSource ExceptionSource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExceptionSource = await _context.ExceptionSource.FirstOrDefaultAsync(m => m.ID == id);

            if (ExceptionSource == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExceptionSource = await _context.ExceptionSource.FindAsync(id);

            if (ExceptionSource != null)
            {
                _context.ExceptionSource.Remove(ExceptionSource);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
