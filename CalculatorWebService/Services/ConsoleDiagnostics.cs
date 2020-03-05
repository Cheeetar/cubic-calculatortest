using CalculatorTest.Interfaces;
using System;

namespace CalculatorWebService.Services
{
    public class ConsoleDiagnostics : IDiagnostics
    {
        public void LogIntResult(int result)
        {
            Console.WriteLine("Int result was: " + result);
        }
    }
}
