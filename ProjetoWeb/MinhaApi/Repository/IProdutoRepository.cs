using MinhaApi.Entities;

namespace MinhaApi.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutos();
        Task<Produto> GetProduto(int id);
    }
}
