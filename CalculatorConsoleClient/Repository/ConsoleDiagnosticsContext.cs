using CalculatorConsoleClient.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.CalculatorConsoleClient
{
    class ConsoleDiagnosticsContext : DbContext
    {
        public ConsoleDiagnosticsContext(DbContextOptions<ConsoleDiagnosticsContext> options) : base(options)
        {
        }

        public DbSet<LogEntry> LogEntries {get; set;}
    }
}
