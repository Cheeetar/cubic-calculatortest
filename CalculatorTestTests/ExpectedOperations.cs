using CalculatorWebService.Services;
using Xunit;

namespace CalculatorTestTests
{
    public class CalculatorTests
    {
        private readonly DiagnosticsMock _DiagnosticsService;
        private readonly CalculatorService _CalcService;

        public CalculatorTests()
        {
            _DiagnosticsService = new DiagnosticsMock();
            _CalcService = new CalculatorService(_DiagnosticsService);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(24, 18, 42)]
        [InlineData(15, -20, -5)]
        [InlineData(15, -10, 5)]
        [InlineData(-5, -2, -7)]
        [InlineData(-5, 12, 7)]
        [InlineData(-5, 2, -3)]
        public void AdditionTests(int left, int right, int expectedResult)
        {
            Assert.Equal(expectedResult, _CalcService.Add(left, right));
            Assert.Equal(expectedResult, _DiagnosticsService.Result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 0)]
        [InlineData(24, 18, 6)]
        [InlineData(15, -20, 35)]
        [InlineData(-5, -2, -3)]
        [InlineData(-5, -12, 7)]
        [InlineData(-5, 12, -17)]
        [InlineData(-5, 2, -7)]
        public void SubtractionTests(int left, int right, int expectedResult)
        {
            Assert.Equal(expectedResult, _CalcService.Subtract(left, right));
            Assert.Equal(expectedResult, _DiagnosticsService.Result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 0)]
        [InlineData(2, 2, 4)]
        [InlineData(2, -2, -4)]
        [InlineData(-2, -2, 4)]
        public void MultiplicationTests(int left, int right, int expectedResult)
        {
            Assert.Equal(expectedResult, _CalcService.Multiply(left, right));
            Assert.Equal(expectedResult, _DiagnosticsService.Result);
        }

        [Theory]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 1)]
        [InlineData(2, -2, -1)]
        [InlineData(-2, -2, 1)]
        [InlineData(5, 2, 2)] // check division rounds down appropriately
        public void DivisionTests(int left, int right, int expectedResult)
        {
            Assert.Equal(expectedResult, _CalcService.Divide(left, right));
            Assert.Equal(expectedResult, _DiagnosticsService.Result);
        }
    }
}
