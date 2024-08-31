using Microsoft.Extensions.WebEncoders.Testing;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoDto;
using ProjetoDto.Dtos;

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

        [Column("qt_peso_liquido")]
        public double Peso { get; set; }

        public string? Fornecedor { get; set; }
        public bool Promocao { get; set; } = false;
        public bool Esgotado { get; set; } = false;
        public string? FormatoDeVenda { get; set; }

        public string? TipoDeProduto { get; set; }

    }
}
