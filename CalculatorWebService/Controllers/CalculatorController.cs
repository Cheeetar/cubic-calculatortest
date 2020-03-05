using CalculatorTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ISimpleCalculator _CalculatorService;

        public CalculatorController(ISimpleCalculator calculatorService)
        {
            _CalculatorService = calculatorService;
        }

        [HttpGet]
        [Route("add")]
        public int Add(int left, int right)
        {
            return _CalculatorService.Add(left, right);
        }

        [HttpGet]
        [Route("subtract")]
        public int Subtract(int left, int right)
        {
            return _CalculatorService.Subtract(left, right);
        }

        [HttpGet]
        [Route("multiply")]
        public int Multiply(int left, int right)
        {
            return _CalculatorService.Multiply(left, right);
        }

        [HttpGet]
        [Route("divide")]
        public int Divide(int left, int right)
        {
            return _CalculatorService.Divide(left, right);
        }
    }
}
