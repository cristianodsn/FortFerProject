using MinhaApi.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi.Entities
{
    public class Produto
    {
        [Key]
        [Column("cd_produto")]
        public int Id { get; set; }

        [Column("no_produto")]
        public string Nome { get; set; }

        [Column("vl_a_vista")]
        public decimal Preco { get; set; }

        public double QuantidadeEstoque { get; set; }
        public double Peso { get; set; }
        string? Tipo { get; set; }
        bool Promoção { get; set; } = false;
        bool Esgotado { get; set; } = false;
        FormatoDeVenda FormatoDeVendaDoProduto { get; set; }
    }
}
