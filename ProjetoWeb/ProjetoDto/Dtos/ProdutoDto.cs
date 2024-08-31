using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoDto.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public double Quantidade { get; set; }
        public double Peso { get; set; }
        public string? Fornecedor { get; set; }
        public bool Promocao { get; set; } = false;
        public bool Esgotado { get; set; } = false;
        public string? FormatoDeVenda { get; set; }

        public string? TipoDeProduto { get; set; }
    }
}
