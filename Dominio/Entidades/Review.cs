using Dominio.Entidades.Base;

namespace Dominio.Entidades;

public partial class Review : EntidadeBase
{
    public string Artista { get; set; } = null!;
    public string Musica { get; set; } = null!;
    public string Review1 { get; set; } = null!;
    public int? Like { get; set; }
    public int? Dislike { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Reacao> Reacoes { get; set; } = new List<Reacao>();
    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}
