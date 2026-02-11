using Microsoft.IdentityModel.Tokens;
using SistemaDeBiblioteca.Entities;
using SistemaDeBiblioteca.Enums;
using SistemaDeBiblioteca.Repositories;

namespace SistemaDeBiblioteca.Controllers {
    public class LivroController {

        public void GerenciarLivro() {

            int opcao;

            do {
                Console.WriteLine("\n\t===== SISTEMA DE BIBLIOTECA =====\n");

                Console.WriteLine("\nESCOLHA UMA DAS OPÇÕES: " +
                                  "\n(1) CADASTRAR LIVRO " +
                                  "\n(2) EXIBIR LIVROS" +
                                  "\n(3) ATUALIZAR LIVRO" +
                                  "\n(4) DELETAR LIVRO" +
                                  "\n(0) SAIR");

                 opcao = int.Parse(Console.ReadLine());

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

                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA!");
                        return;
                }
            } while (opcao != 0);

           
            
            
        }

        private void CadastrarLivro() {

        }

        private void ListarLivros() {

        }

        private void AtualizarLivro() {

        }

        private void DeletarLivro() {

        }
    }
}
