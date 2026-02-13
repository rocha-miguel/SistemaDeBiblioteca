using Microsoft.IdentityModel.Tokens;
using SistemaDeBiblioteca.Entities;
using SistemaDeBiblioteca.Repositories;

namespace SistemaDeBiblioteca.UseCases {
    public class LivroUseCase {

        private readonly LivroRepository _livroRepository = new LivroRepository();



        private bool CheckLivroNome(Livro livro) {

            if (livro == null) return false;

            if (string.IsNullOrWhiteSpace(livro.Nome)) {
                return false;
            }

            return true;

        }

        public bool CadastrarLivro(Livro livro) {

            if (!CheckLivroNome(livro)) {
                return false;
            }



            _livroRepository.Inserir(livro);

            return true;

        }

        public List<Livro> ListarLivrosResumido() {

            return _livroRepository.ListarResumido();
        }

        public Livro? ListarLivros(int id) {

            return _livroRepository.ListarPorId(id);

        }

        public bool AtualizarLivro(int id, decimal preco, int quantidade) {

            if (id <= 0) return false;

            if (preco <= 0) return false;

            if (quantidade < 0) return false;

            _livroRepository.Atualizar(id, preco, quantidade);

            return true;
        }

        public bool DeletarLivro(int id) {

            if (id <= 0) return false;

            _livroRepository.Deletar(id);

            return true;
        }

    }
}
