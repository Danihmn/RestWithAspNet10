using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Services;

namespace RestWithAspNet10.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController (IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ProductDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetAll ()
        {
            _logger.LogInformation("Buscando todos os produtos");

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return Ok(_productService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetById (long id)
        {
            _logger.LogInformation($"Buscando produto pelo Id {id}");

            ProductDTO product = _productService.FindById(id);

            if (product == null)
            {
                _logger.LogWarning($"Produto com ID {id} não encontrado");
                return NotFound();
            }

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create ([FromBody] ProductDTO product)
        {
            _logger.LogInformation($"Criando novo produto: {product.Name}");

            ProductDTO createdProduct = _productService.Create(product);

            if (createdProduct == null)
            {
                _logger.LogError("Erro ao tentar criar novo produto");
                return BadRequest();
            }

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update (long id, [FromBody] ProductDTO product)
        {
            _logger.LogInformation($"Alterando produto ID {id}: {product.Name}");

            ProductDTO updatedProduct = _productService.Update(product);

            if (updatedProduct == null)
            {
                _logger.LogError($"Erro ao tentar alterar produto ID {id}: {product.Name}");
                return NotFound();
            }

            _logger.LogDebug($"Produto atualizado com sucesso: {updatedProduct.Name}");

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(ProductDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete (long id)
        {
            ProductDTO product = _productService.FindById(id);

            if (product == null)
            {
                _logger.LogWarning($"Produto com ID {id} não encontrado para exclusão");
                return NotFound();
            }

            _logger.LogInformation($"Removendo produto pelo Id {id}");
            _productService.Delete(id);

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(204, Type = typeof(ProductDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Disable (long id)
        {
            ProductDTO product = _productService.FindById(id);

            if (product == null)
            {
                _logger.LogWarning($"Produto com ID {id} não encontrado para desativação");
                return NotFound();
            }

            _logger.LogInformation("Desativando produto com Id" + product.Id);
            var disabledProduct = _productService.Disable(product.Id);

            return Ok(disabledProduct);
        }
    }
}