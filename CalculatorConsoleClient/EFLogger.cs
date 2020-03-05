using CalculatorConsoleClient.Models;
using CalculatorTest.Interfaces;
using Repository.CalculatorConsoleClient;
using System;

namespace CalculatorConsoleClient
{
    class EFLogger : IDiagnostics
    {
        private readonly ConsoleDiagnosticsContext _DiagnosticsContext;

        public EFLogger(ConsoleDiagnosticsContext diagnosticsContext)
        {
            _DiagnosticsContext = diagnosticsContext;
        }

        public void LogIntResult(int result)
        {
            Console.WriteLine("Your result is: " + result);
            _DiagnosticsContext.LogEntries.Add(new LogEntry
            {
                Result = result
            });
            _DiagnosticsContext.SaveChanges();
        }
    }
}
