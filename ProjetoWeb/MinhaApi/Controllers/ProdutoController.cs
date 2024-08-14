using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Entities;
using MinhaApi.Repository;

namespace MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Produto>> GetItens()
        {
           return null;
        }
       
    }
}
