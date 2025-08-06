using System;
using System.Collections.Generic;

namespace FaOuHaterApi.Models;

public partial class Review
{
    public int Id { get; set; }

    public string Artista { get; set; } = null!;

    public string Musica { get; set; } = null!;

    public string Review1 { get; set; } = null!;

    public int? Like { get; set; }

    public int? Dislike { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Reacao> Reacoes { get; set; } = new List<Reacao>();

    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}
