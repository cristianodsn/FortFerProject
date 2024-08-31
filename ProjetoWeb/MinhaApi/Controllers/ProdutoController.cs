using Microsoft.AspNetCore.Mvc;
using MinhaApi.Mappings;
using MinhaApi.Repository;
using ProjetoDto.Dtos;

namespace MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }



        //        public async Task<ProdutoDto> GetItem(int id)
        //        {

        //            var produto = await _produtoRepository.GetItem(id);            


        //            // BLOCO PARA FAZER UM TESTE COM CONSULTAS BRUTAS - DBSET DE qt_saldo_produto É MAIS ADEQUALDO
        //            // Defina a consulta SQL 
        //            var sql = "SELECT qt_saldo_produto FROM estoque_saldo_deposito WHERE cd_produto = @Id";

        //            // Crie e configure o comando
        //            using (var command = _context.Database.GetDbConnection().CreateCommand())
        //            {
        //                command.CommandText = sql;
        //                command.CommandType = CommandType.Text;

        //                // Adicione o parâmetro
        //                var parameter = command.CreateParameter();
        //                parameter.ParameterName = "@Id";
        //                parameter.DbType = DbType.Int32;
        //                parameter.Value = id;
        //                command.Parameters.Add(parameter);

        //                // Abra a conexão se ainda não estiver aberta
        //                if (command.Connection.State != ConnectionState.Open)
        //                {
        //                    await command.Connection.OpenAsync();
        //                }

        //                //Execute o comando e leia os resultados
        //                using (var reader = await command.ExecuteReaderAsync())
        //                {
        //                    if (await reader.ReadAsync())
        //                    {
        //                        // Supondo que você está retornando uma string para simplicidade
        //                        // Adapte conforme necessário para seu caso
        //                        double quantidade = (double)reader["qt_saldo_produto"];
        //                        produto.QuantidadeEstoque = quantidade;
        //                    }

        //                }
        //            }
        //9
        //            return null;


        //        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItens()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();
                var produtosDto = produtos.ConverterProdutosParaDto().ToList();

                return Ok(produtosDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos {ex.Message}");
                return StatusCode(500, $"Ocorreu um erro interno no servidor. Entrou na api!! {ex.Message}");
            }
        }

    }
}
