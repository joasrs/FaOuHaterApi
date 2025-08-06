using Dominio.Base;
using System;
using System.Collections.Generic;

namespace FaOuHaterApi.Models;

public partial class Usuario : EntidadeBase
{
    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? UrlImagemPerfil { get; set; }

    public bool? Admin { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Reacao> Reacoes { get; set; } = new List<Reacao>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
