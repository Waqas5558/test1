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
    public class IndexModel : PageModel
    {
        private readonly ControlPanel.Model.Connection.GenericControlPanel_DBContext _context;

        public IndexModel(ControlPanel.Model.Connection.GenericControlPanel_DBContext context)
        {
            _context = context;
        }

        public IList<ExceptionSource> ExceptionSource { get;set; }

        public async Task OnGetAsync()
        {
            ExceptionSource = await _context.ExceptionSource.ToListAsync();
        }
    }
}
