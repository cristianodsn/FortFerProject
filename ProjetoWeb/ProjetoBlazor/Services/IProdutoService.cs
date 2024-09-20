using ProjetoDto.Dtos;

namespace ProjetoBlazor.Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto> GetProduto();
        Task<IEnumerable<ProdutoDto>> GetProdutos();
    }
}
