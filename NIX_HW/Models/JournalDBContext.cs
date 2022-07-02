using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace NIX_HW.Models
{
    public class JournalDBContext :DbContext
    {
        public JournalDBContext(DbContextOptions<JournalDBContext> options)
            : base(options)
        {
    
        }
        public JournalDBContext() 
        {
            Database.IsInMemory();
        }
        public DbSet<Journals> JournalDBContexts { get; set; } = null!;

    }
}
