
using SistemaDeBiblioteca.Entities;
using SistemaDeBiblioteca.Enums;
using SistemaDeBiblioteca.UseCases;
using System.Globalization;

namespace SistemaDeBiblioteca.Controllers {
    public class LivroController {

        private readonly LivroUseCase _livroUseCase = new LivroUseCase();
        private bool _validacao;


        public void GerenciarLivro() {

            int opcao;

            do {
                Console.WriteLine("\n\t===== SISTEMA DE BIBLIOTECA =====\n");

                Console.WriteLine("\nESCOLHA UMA DAS OPÇÕES: " +
                                  "\n(1) CADASTRAR LIVRO " +
                                  "\n(2) EXIBIR LIVROS" +
                                  "\n(3) ATUALIZAR LIVRO" +
                                  "\n(4) DELETAR LIVRO" +
                                  "\n(0) SAIR\n");

                opcao = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (opcao) {

                    case 1:
                        CadastrarLivro();
                        break;

                    case 2:
                        ListarLivros();
                        break;

                    case 3:
                        AtualizarLivro();
                        break;

                    case 4:
                        DeletarLivro();
                        break;

                    case 0:
                        Console.WriteLine("\nFINALIZANDO...");
                        break;

                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                        break;
                }
            } while (opcao != 0);




        }

        private void CadastrarLivro() {

            var livro = new Livro();

            Console.WriteLine("\n\t===== INSIRA OS DADOS DO LIVRO =====\n");

            Console.Write("\nNOME........................: ");
            livro.Nome = Console.ReadLine() ?? string.Empty;

            Console.Write("\nEDITORA.....................: ");
            livro.Editora = Console.ReadLine() ?? string.Empty;

            Console.Write("\nAUTOR.......................: ");
            livro.Autor = Console.ReadLine() ?? string.Empty;

            Console.Write("\nPREÇO.......................: ");
            livro.Preco = decimal.Parse(Console.ReadLine() ?? string.Empty, CultureInfo.InvariantCulture);

            Console.Write("\nQUANTIDADE..................: ");
            livro.Quantidade = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("\nQUANTIDADE PÁGINAS..........: ");
            livro.QuantidadePaginas = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("\nANO EDIÇÃO..................: ");
            livro.AnoEdicao = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("\nTIPOS: \n" +
                              "\n(1) CAPA MOLE \n(2) CAPA DURA \n(3) EBOOK");

            Console.Write("\nESCOLHA.....................: ");
            livro.Tipo = Enum.Parse<TipoLivro>(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("\nGÊNEROS: \n" +
                              "\n(1)  FICÇÃO \n(2)  FANTASIA \n(3)  ROMANCE \n(4)  TERROR \n(5)  HQ" +
                              "\n(6)  AUTOAJUDA \n(7)  RELIGIÃO \n(8)  SOCIOLOGIA \n(9)  FILOSOFIA \n(10) SUSPENSE");

            Console.Write("\nESCOLHA.....................: ");

            livro.Genero = Enum.Parse<GeneroLivro>(Console.ReadLine() ?? string.Empty);

            _validacao = _livroUseCase.CadastrarLivro(livro);

            if (_validacao) {
                Console.WriteLine("\nLIVRO CADASTRADO COM SUCESSO!");
            } else {
                Console.WriteLine("\nERRO: NOME INVÁLIDO!");
            }

        }

        private void ListarLivros() {

            var livros = _livroUseCase.ListarLivrosResumido();

            if (livros.Count == 0 || livros == null) {
                Console.WriteLine("\nNENHUM LIVRO CADASTRADO!");
                return;
            }

            Console.WriteLine("\n\t===== LISTA DE LIVROS =====");

            foreach (var livro in livros) {

                Console.WriteLine($"\n{livro.Id} - {livro.Nome}");

            }

            Console.Write("\nESCOLHA O ID..............: ");
            int id = int.Parse(Console.ReadLine() ?? string.Empty);

            var livroSelecionado = _livroUseCase.ListarLivros(id);

            if (livroSelecionado == null) {
                Console.WriteLine("\nLIVRO NÃO ENCONTRADO!");
                return;
            }

            Console.WriteLine("\n\t===== DADOS DO LIVRO =====");

            Console.WriteLine($"\nID........................: {livroSelecionado.Id}" +
                              $"\nNOME......................: {livroSelecionado.Nome}" +
                              $"\nEDITORA...................: {livroSelecionado.Editora}" +
                              $"\nAUTOR.....................: {livroSelecionado.Autor}" +
                              $"\nPREÇO.....................: R$ {livroSelecionado.Preco.ToString("F2", CultureInfo.InvariantCulture)}" +
                              $"\nQUANTIDADE................: {livroSelecionado.Quantidade}" +
                              $"\nQUANTIDADE DE PÁGINAS.....: {livroSelecionado.QuantidadePaginas}" +
                              $"\nANO EDIÇÃO................: {livroSelecionado.AnoEdicao}" +
                              $"\nTIPO DO LIVRO.............: {livroSelecionado.Tipo}" +
                              $"\nGÊNERO....................: {livroSelecionado.Genero}");


        }


        private void AtualizarLivro() {

            var livros = _livroUseCase.ListarLivrosResumido();

            if (livros.Count == 0 || livros == null) {
                Console.WriteLine("\nNENHUM LIVRO CADASTRADO!");
                return;
            }

            Console.WriteLine("\n\t===== LISTA DE LIVROS =====");

            foreach (var livro in livros) {

                Console.WriteLine($"\n{livro.Id} - {livro.Nome}");

            }

            Console.Write("\nESCOLHA O ID..............: ");
            int id = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("PREÇO ATUALIZADO..........: ");
            decimal preco = decimal.Parse(Console.ReadLine() ?? string.Empty, CultureInfo.InvariantCulture);

            Console.Write("QUANTIDADE ATUALIZADA.....: ");
            int quantidade = int.Parse(Console.ReadLine() ?? string.Empty);

            _validacao = _livroUseCase.AtualizarLivro(id, preco, quantidade);

            if (_validacao) {
                Console.WriteLine("\nLIVRO ATUALIZADO COM SUCESSO!");

            } else {
                Console.WriteLine("\nERRO: PREÇO OU QUANTIDADE INVÁLIDA!");
            }
        }



        private void DeletarLivro() {

            var livros = _livroUseCase.ListarLivrosResumido();

            if (livros.Count == 0 || livros == null) {
                Console.WriteLine("\nNENHUM LIVRO CADASTRADO!");
                return;
            }

            Console.WriteLine("\n\t===== LISTA DE LIVROS =====");

            foreach (var livro in livros) {

                Console.WriteLine($"\n{livro.Id} - {livro.Nome}");

            }

            Console.Write("\nESCOLHA O ID..............: ");
            int id = int.Parse(Console.ReadLine() ?? string.Empty);

            _validacao = _livroUseCase.DeletarLivro(id);

            if (_validacao) {
                Console.WriteLine("\nLIVRO DELETADO COM SUCESSO!");
            } else {
                Console.WriteLine("\nERRO: ID NÃO EXISTE!");
            }


        }
    }

}
