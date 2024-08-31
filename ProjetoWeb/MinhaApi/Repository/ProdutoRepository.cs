using MinhaApi.Context;
using MinhaApi.Entities;
using System.Data;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Context;

namespace MinhaApi.Repository
{    
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MyDbContext _context;

        public ProdutoRepository(MyDbContext context) 
        {
            _context = context;
        }       

        public async Task<IEnumerable<Produto>> GetItens()
        {
            try
            {
                var produtos = await _context.produtos
                    .Select(p => new Produto
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Preco = p.Preco
                    }).ToListAsync();              
                return produtos;
            }
          catch(Exception ex)
            {
                throw new Exception("Erro no servis: " + ex.Message);
            }
        }



        public async Task<Produto> GetItem(int id)
        {
            var produto = await _context.produtos.Where(p => p.Id == id)
           .Select(p => new Produto
           {
               Id = p.Id,
               Nome = p.Nome,
               Preco = p.Preco,
               QuantidadeEstoque = 0

           }).FirstOrDefaultAsync();

            double quantidade = await GetQuantidade(id);
            produto.QuantidadeEstoque = quantidade;

            return produto;
        }

        private async Task<double> GetQuantidade(int id)
        {
            // BLOCO PARA FAZER UM TESTE COM CONSULTAS BRUTAS - DBSET DE qt_saldo_produto É MAIS ADEQUALDO

            // Defina a consulta SQL 
            var sql = "SELECT qt_saldo_produto FROM estoque_saldo_deposito WHERE cd_produto = @Id";

            // Crie e configure o comando
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                // Adicione o parâmetro
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@Id";
                parameter.DbType = DbType.Int32;
                parameter.Value = id;
                command.Parameters.Add(parameter);

                // Abra a conexão se ainda não estiver aberta
                if (command.Connection.State != ConnectionState.Open)
                {
                    await command.Connection.OpenAsync();
                }

                //Execute o comando e leia os resultados
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        // Supondo que você está retornando uma string para simplicidade
                        // Adapte conforme necessário para seu caso
                        double quantidade = (double)reader["qt_saldo_produto"];                        
                    }

                }
            }
            return default;
        }

        
        
    }
}
