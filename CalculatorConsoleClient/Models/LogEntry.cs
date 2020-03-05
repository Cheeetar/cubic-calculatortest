using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorConsoleClient.Models
{
    class LogEntry
    {
        [Key]
        public Guid Id { get; set;  } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public int Result { get; set; }
    }
}
