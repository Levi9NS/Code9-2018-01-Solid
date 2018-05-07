using AspNetApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetApp.Api
{
    [Route("/api/[controller]/[action]")]
    public class CalculatorController: Controller
    {
        private readonly ICalculatorService _calcService;

        public CalculatorController(ICalculatorService calcService)
        {
            _calcService = calcService ?? throw new ArgumentNullException(nameof(calcService));
        }

        [HttpGet]
        public int Add(int a, int b) => _calcService.Add(a, b);

        [HttpGet]
        public int Multiply(int a, int b)
        {
            return _calcService.Add(a, b);
        }

    }
}
