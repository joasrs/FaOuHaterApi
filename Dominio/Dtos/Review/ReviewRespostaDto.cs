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
        public virtual ReviewRespostaUsuarioDto Usuario { get; set; } = null!;
        public bool? UsuarioLike { get; set; } = false;
        public bool? UsuarioDislike { get; set; } = false;
        public int? QtdLikes { get; set; } = 0;
        public int? QtdDislikes { get; set; } = 0;
        public int? QtdComentarios { get; set; } = 0;
    }

    public class ReviewRespostaUsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string UrlImagemPerfil { get; set; } = null!;
    }
}
