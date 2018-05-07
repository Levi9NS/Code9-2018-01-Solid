namespace AspNetApp.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int a, int b) => a + b;

        public int Multiply(int a, int b) => a * b;
    }
}
