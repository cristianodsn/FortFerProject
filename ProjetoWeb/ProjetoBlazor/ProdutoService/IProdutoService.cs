using ProjetoDto.Dtos;

namespace ProjetoBlazor.ProdutoService
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> GetItens();
    }
}
