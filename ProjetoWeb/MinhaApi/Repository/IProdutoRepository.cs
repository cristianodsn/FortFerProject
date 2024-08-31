using MinhaApi.Entities;

namespace MinhaApi.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetItens();
        Task<Produto> GetItem(int id);
    }
}
