using Dominio.Entidades.Base;

namespace Dominio.Entidades;

public partial class Review : EntidadeBase
{
    public Guid? IdTrack { get; set; }
    public string Artista { get; set; } = null!;
    public string Musica { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public int? Like { get; set; }
    public int? Dislike { get; set; }
    public string? ImagemUrl { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Reacao> Reacoes { get; set; } = new List<Reacao>();
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}
