using System;
using System.Collections.Generic;

namespace FaOuHaterApi.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public string? Comentario1 { get; set; }

    public int IdOrigem { get; set; }

    public int ReviewId { get; set; }

    public string TipoOrigem { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
