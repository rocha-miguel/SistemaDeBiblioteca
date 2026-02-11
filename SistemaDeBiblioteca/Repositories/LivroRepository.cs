

using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDeBiblioteca.Entities;


namespace SistemaDeBiblioteca.Repositories {

    /// <summary>
    /// Classe responsável por inserir, atualizar, listar e deletar livros do banco de dados.
    /// </summary>
    public class LivroRepository {

        public void Inserir(Livro livro) {

            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDBiblioteca;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString)) {

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

            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDBiblioteca;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString)) {

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

        public void ListarResumido () {

            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDBiblioteca;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString)) {

                var query = """
                    SELECT ID, NOME FROM LIVROS
                    """;

                connection.Execute(query);
            }
        }

        public void ListarPorId(int id) {

            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDBiblioteca;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString)) {

                var query = """
                    SELECT NOME, EDITORA, AUTOR, PRECO, QUANTIDADEPAGINAS, QUANTIDADE, ANOEDICAO, TIPOLIVRO, GENERO FROM LIVROS
                    WHERE ID = @ID
                    """;

                connection.Execute(query, new {
                    @ID = id
                });
            }

        }

        public void Deletar(int id) {

            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDBiblioteca;Integrated Security=True;";

            using ( var connection = new SqlConnection(connectionString)) {

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
