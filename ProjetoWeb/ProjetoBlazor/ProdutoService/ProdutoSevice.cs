using ProjetoDto.Dtos;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections;

namespace ProjetoBlazor.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        public HttpClient _httpClient { get; set; }
        public ILogger<ProdutoService> _logger { get; set; }

        public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        public async Task<IEnumerable<ProdutoDto>> GetItens()
        {
            var produtos = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/Produto");
            return produtos;
        }
    }
}
