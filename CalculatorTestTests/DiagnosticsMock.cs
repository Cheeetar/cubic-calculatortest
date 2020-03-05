using CalculatorTest.Interfaces;

namespace CalculatorTestTests
{
    class DiagnosticsMock : IDiagnostics
    {
        public int Result { get; set; }

        public void LogIntResult(int result)
        {
            Result = result;
        }
    }
}
