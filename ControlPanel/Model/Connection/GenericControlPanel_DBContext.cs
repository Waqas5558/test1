using ControlPanel.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlPanel.Model.Connection
{
    public class GenericControlPanel_DBContext : DbContext
    {
        public GenericControlPanel_DBContext(DbContextOptions<GenericControlPanel_DBContext> options)
        : base(options)
        { }

        public DbSet<ExceptionSource> ExceptionSource { get; set; }

        //public override OnObjectCreating
    }
}
