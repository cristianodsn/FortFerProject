using ProjetoDto.Dtos;
using System.Net.Http.Json;

namespace ProjetoBlazor.Services
{
    public class ProdutoService : IProdutoService
    {
        public HttpClient _httpClient;
        public ILogger<ProdutoService> _logger;

            public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
            {
                _httpClient = httpClient;
                _logger = logger;       
            }

        public Task<ProdutoDto> GetProduto()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoDto>> GetProdutos()
        {
            try
            {
                var produtos = await _httpClient.
                    GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/produto");
                return produtos;
            }
            catch(Exception e)
            {               
                _logger.LogError("Erro ao acessar produtos: api/produtos");
                throw new Exception(e.Message);
            }
        }
    }
}
