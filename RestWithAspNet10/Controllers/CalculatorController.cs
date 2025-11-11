using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Services;
using RestWithAspNet10.ValueHelper;

namespace RestWithAspNet10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly MathService _service;

        public CalculatorController (MathService service)
        {
            _service = service;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
                return Ok(_service.Sum(Convertions.ConvertToDecimal(firstNumber), Convertions.ConvertToDecimal(secondNumber)));

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
                return Ok(_service.Subtraction(Convertions.ConvertToDecimal(firstNumber), Convertions.ConvertToDecimal(secondNumber)));

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult GetMean (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
                return Ok(_service.Mean(Convertions.ConvertToDecimal(firstNumber), Convertions.ConvertToDecimal(secondNumber)));

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMult (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
                return Ok(_service.Multiplication(Convertions.ConvertToDecimal(firstNumber), Convertions.ConvertToDecimal(secondNumber)));

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv (string firstNumber, string secondNumber)
        {
            if (Verifications.IsNumeric(firstNumber) && Verifications.IsNumeric(secondNumber))
                return Ok(_service.Division(Convertions.ConvertToDecimal(firstNumber), Convertions.ConvertToDecimal(secondNumber)));

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult GetSquareRoot (string number)
        {
            if (Verifications.IsNumeric(number))
                return Ok(_service.SquareRoot(Convertions.ConvertToDecimal(number)));

            return BadRequest("Valor(es) fornecido(s) inválido(s)");
        }
    }
}
