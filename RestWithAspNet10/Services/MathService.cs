namespace RestWithAspNet10.Services
{
    public class MathService
    {
        public decimal Sum (decimal firstNumber, decimal secondNumber) => firstNumber + secondNumber;
        public decimal Subtraction (decimal firstNumber, decimal secondNumber) => firstNumber - secondNumber;
        public decimal Mean (decimal firstNumber, decimal secondNumber) => (firstNumber + secondNumber) / 2;
        public decimal Multiplication (decimal firstNumber, decimal secondNumber) => firstNumber * secondNumber;
        public decimal Division (decimal firstNumber, decimal secondNumber)
        {
            if (secondNumber > 0) return firstNumber / secondNumber;

            throw new DivideByZeroException("Não é possível dividir por zero");
        }
        public double SquareRoot (decimal number)
        {
            if (number > 0) return Math.Sqrt((double)number);

            throw new Exception("Não é possível fazer a raiz quadrada de um valor igual ou menor que zero");
        }
    }
}
