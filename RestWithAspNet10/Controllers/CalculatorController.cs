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
            decimal decimalValue;
            bool decimalValueConverted = decimal.TryParse(stringValue, out decimalValue);

            if (decimalValueConverted) return decimalValue;
            else throw new Exception();
        }

        private bool IsNumeric (object firstNumber)
        {
            throw new NotImplementedException();
        }
    }
}
