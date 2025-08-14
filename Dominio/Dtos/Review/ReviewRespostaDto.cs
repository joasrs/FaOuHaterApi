using Dominio.Entidades;

namespace Dominio.Dtos.Review
{
    public class ReviewRespostaDto
    {
        public int Id { get; set; }

        public string Artista { get; set; } = null!;

        public string Musica { get; set; } = null!;

        public string Review1 { get; set; } = null!;

        public int? Like { get; set; }

        public int? Dislike { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Reacao> Reacoes { get; set; } = new List<Reacao>();

        public virtual Usuario? Usuario { get; set; }

        public bool? UsuarioLike { get; set; } = false;

        public bool? UsuarioDislike { get; set; } = false;

        public int? QtdLikes { get; set; } = 0;

        public int? QtdDislikes { get; set; } = 0;

        public int? QtdComentarios { get; set; } = 0;
    }
}
