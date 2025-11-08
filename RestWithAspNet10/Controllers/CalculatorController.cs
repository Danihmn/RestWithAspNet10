using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get (string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum);
            }

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        private decimal ConvertToDecimal (string stringValue)
        {
            bool decimalValue = decimal.TryParse(stringValue, out decimal decimalValueConverted);

            if (decimalValue) return decimalValueConverted;
            else throw new Exception();
        }

        private bool IsNumeric (string value)
        {
            bool isNumeric = decimal.TryParse(value, out _);
            return isNumeric;
        }
    }
}
