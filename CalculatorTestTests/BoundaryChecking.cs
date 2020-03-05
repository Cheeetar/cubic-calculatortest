using CalculatorWebService.Services;
using System;
using Xunit;

namespace CalculatorTestTests
{
    public class BoundaryChecking
    {
        private readonly DiagnosticsMock _DiagnosticsService;
        private readonly CalculatorService _CalcService;

        public BoundaryChecking()
        {
            _DiagnosticsService = new DiagnosticsMock();
            _CalcService = new CalculatorService(_DiagnosticsService);
        }

        [Fact]
        public void IntOverflowWorksAsExpected()
        {
            Assert.Equal(int.MinValue, _CalcService.Add(int.MaxValue, 1));
            Assert.Equal(int.MinValue, _DiagnosticsService.Result);

            Assert.Equal(int.MaxValue, _CalcService.Subtract(int.MinValue, 1));
            Assert.Equal(int.MaxValue, _DiagnosticsService.Result);
        }

        [Fact]
        public void CantDivideByZero()
        {
            var threw = false;
            try
            {
                _CalcService.Divide(1, 0);
            }
            catch (DivideByZeroException)
            {
                threw = true;
            }
            catch (Exception exception)
            {
                throw new Exception("Unexpected exception", exception);
            }
            Assert.True(threw);
        }
    }
}
