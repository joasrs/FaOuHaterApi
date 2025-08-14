namespace Dominio.Dtos.Review
{
    public class ReviewRequisicaoDto
    {
        public string Artista { get; set; } = null!;

        public string Musica { get; set; } = null!;

        public string Review1 { get; set; } = null!;

        public int? Like { get; set; }

        public int? Dislike { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? UsuarioId { get; set; }
    }
}
