using CalculatorTest.Interfaces;

namespace CalculatorWebService.Services
{
    public class DummyDiagnostics : IDiagnostics
    {
        public void LogIntResult(int result) { }
    }
}
