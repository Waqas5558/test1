using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlPanel.Model.Connection;
using ControlPanel.Model.Domain;

namespace ControlPanel.Pages.Source
{
    public class EditModel : PageModel
    {
        private readonly ControlPanel.Model.Connection.GenericControlPanel_DBContext _context;

        public EditModel(ControlPanel.Model.Connection.GenericControlPanel_DBContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExceptionSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExceptionSourceExists(ExceptionSource.ID))
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

        private bool ExceptionSourceExists(int id)
        {
            return _context.ExceptionSource.Any(e => e.ID == id);
        }
    }
}
