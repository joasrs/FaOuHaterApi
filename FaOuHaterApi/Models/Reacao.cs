using System;
using System.Collections.Generic;

namespace FaOuHaterApi.Models;

public partial class Reacao
{
    public int Id { get; set; }

    public bool? Like { get; set; }

    public bool? Dislike { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? UsuarioId { get; set; }

    public int? ReviewId { get; set; }

    public virtual Review? Review { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
