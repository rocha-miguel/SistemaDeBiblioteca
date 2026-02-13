

using SistemaDeBiblioteca.Enums;

namespace SistemaDeBiblioteca.Entities {
    public class Livro {

        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Editora { get; set; } = string.Empty;

        public string Autor { get; set; } = string.Empty;

        public decimal Preco { get; set; } = 0.0m;

        public int Quantidade { get; set; } = 0;

        public int QuantidadePaginas { get; set; } = 0;

        public int AnoEdicao { get; set; }

        public TipoLivro Tipo { get; set; }

        public GeneroLivro Genero { get; set; }
    }
}
