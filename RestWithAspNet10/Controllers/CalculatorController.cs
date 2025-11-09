using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Handlers;

namespace RestWithAspNet10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
            {
                decimal sum = Convertions.ConvertToDecimal(firstNumber) + Convertions.ConvertToDecimal(secondNumber);
                return Ok(sum);
            }

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
            {
                decimal sub = Convertions.ConvertToDecimal(firstNumber) - Convertions.ConvertToDecimal(secondNumber);
                return Ok(sub);
            }

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMult (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
            {
                decimal mult = Convertions.ConvertToDecimal(firstNumber) * Convertions.ConvertToDecimal(secondNumber);
                return Ok(mult);
            }

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
            {
                if (Convertions.ConvertToDecimal(secondNumber) > 0)
                {
                    decimal div = Convertions.ConvertToDecimal(firstNumber) / Convertions.ConvertToDecimal(secondNumber);
                    return Ok(div);
                }

                return BadRequest("Divisão inválida");
            }

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult GetSquareRoot (string number)
        {
            if (Verifications.IsNumeric(number))
            {
                decimal numberFormated = Convertions.ConvertToDecimal(number);

                if (numberFormated > 0) return Ok(Math.Sqrt((double)numberFormated));

                return BadRequest("Operação inválida");
            }

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }
    }
}
