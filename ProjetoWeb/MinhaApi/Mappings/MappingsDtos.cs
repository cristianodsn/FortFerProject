using ProjetoDto.Dtos;
using MinhaApi.Entities;

namespace MinhaApi.Mappings
{
    public static class MappingsDtos
    {

        public static bool testettt (this string s)
        {
            if(s == "cristiano")
            {
                return true;
            }
            return false;
        }
        public static IEnumerable<ProdutoDto> ConverterProdutosParaDto(this IEnumerable<Produto> produtos)
        {
            return (from produto in produtos
                    select new ProdutoDto
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Preco = produto.Preco,
                        Quantidade = produto.QuantidadeEstoque,
                        Peso = produto.Peso,
                        Fornecedor = produto.Fornecedor,
                        Esgotado = produto.Esgotado,
                        FormatoDeVenda = produto.FormatoDeVenda,
                        Promocao = produto.Promocao,
                        TipoDeProduto = produto.TipoDeProduto

                    }).ToList();
        }

        public static ProdutoDto ConverterProdutoParaDto(this Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.QuantidadeEstoque,
                Peso = produto.Peso,
                Fornecedor = produto.Fornecedor,
                Esgotado = produto.Esgotado,
                FormatoDeVenda = produto.FormatoDeVenda,
                Promocao = produto.Promocao,
                TipoDeProduto = produto.TipoDeProduto
            };
        }
    }
}
