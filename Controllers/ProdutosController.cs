using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static readonly List<Produto> produtos = new()
        {
            new Produto { Id = 1, Nome = "Notebook", Preco = 3500 },
            new Produto { Id = 2, Nome = "Mouse", Preco = 120 },
            new Produto { Id = 3, Nome = "Teclado", Preco = 250 }
        };

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            produto.Id = produtos.Any()
                ? produtos.Max(p => p.Id) + 1
                : 1;

            produtos.Add(produto);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = produto.Id },
                produto
            );
        }
    }
}