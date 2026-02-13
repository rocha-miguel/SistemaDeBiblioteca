

using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDeBiblioteca.Entities;


namespace SistemaDeBiblioteca.Repositories {

    /// <summary>
    /// Classe responsável por inserir, atualizar, listar e deletar livros do banco de dados.
    /// </summary>
    public class LivroRepository {

        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDBiblioteca;Integrated Security=True;";

        public void Inserir(Livro livro) {

            

            using (var connection = new SqlConnection(_connectionString)) {

                var query = """
                    INSERT INTO LIVROS(NOME, EDITORA, AUTOR, QUANTIDADE, PRECO, QUANTIDADEPAGINAS, ANOEDICAO, TIPOLIVRO, GENERO)
                    VALUES(@NOME, @EDITORA, @AUTOR, @QUANTIDADE, @PRECO, @QUANTIDADEPAGINAS, @ANOEDICAO, @TIPOLIVRO, @GENERO)
                    """;

                connection.Execute(query, new {
                    @NOME = livro.Nome,
                    @EDITORA = livro.Editora,
                    @AUTOR = livro.Autor,
                    @QUANTIDADE = livro.Quantidade,
                    @PRECO = livro.Preco,
                    @QUANTIDADEPAGINAS = livro.QuantidadePaginas,
                    @ANOEDICAO = livro.AnoEdicao,
                    @TIPOLIVRO = livro.Tipo.ToString(),
                    @GENERO = livro.Genero.ToString()
                });
            }

        }

        public void Atualizar(int id, decimal precoAtualizado, int quantidadeAtualizada) {

            

            using (var connection = new SqlConnection(_connectionString)) {

                var query = """
                    UPDATE LIVROS 
                    SET PRECO = @PRECO,
                    QUANTIDADE = @QUANTIDADE 
                    WHERE ID = @ID
                    """;

                connection.Execute(query, new {
                    @ID = id,
                    @PRECO = precoAtualizado,
                    @QUANTIDADE = quantidadeAtualizada
                });
            }

            
        }

        public List<Livro> ListarResumido () {

            

            using (var connection = new SqlConnection(_connectionString)) {

                var query = """
                    SELECT ID, NOME FROM LIVROS
                    """;

                return connection.Query<Livro>(query).ToList();
            }
        }

        public Livro? ListarPorId(int id) {

           

            using (var connection = new SqlConnection(_connectionString)) {

                var query = """
                    SELECT NOME, EDITORA, AUTOR, PRECO, QUANTIDADEPAGINAS, QUANTIDADE, ANOEDICAO, TIPOLIVRO, GENERO FROM LIVROS
                    WHERE ID = @ID
                    """;

                return connection.QueryFirstOrDefault<Livro>(query, new {
                    @ID = id
                });

                          
                
            }

        }

        public void Deletar(int id) {

            

            using ( var connection = new SqlConnection(_connectionString)) {

                var query = """
                    DELETE FROM LIVROS 
                    WHERE ID = @ID
                    """;

                connection.Execute(query, new {
                    @ID = id
                });
            }

            

        }


    }
}
