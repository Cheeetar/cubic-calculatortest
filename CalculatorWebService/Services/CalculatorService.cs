using CalculatorTest.Interfaces;

namespace CalculatorWebService.Services
{
    public class CalculatorService : ISimpleCalculator
    {
        private readonly IDiagnostics _DiagnosticsService;
        public CalculatorService(IDiagnostics diagnosticsService)
        {
            _DiagnosticsService = diagnosticsService;
        }

        public int Add(int start, int amount)
        {
            var result = start + amount;
            _DiagnosticsService.LogIntResult(result);
            return result;
        }

        public int Divide(int start, int by)
        {
            var result = start / by;
            _DiagnosticsService.LogIntResult(result);
            return result;
        }

        public int Multiply(int start, int by)
        {
            var result = start * by;
            _DiagnosticsService.LogIntResult(result);
            return result;
        }

        public int Subtract(int start, int amount)
        {
            var result = start - amount;
            _DiagnosticsService.LogIntResult(result);
            return result;
        }
    }
}
