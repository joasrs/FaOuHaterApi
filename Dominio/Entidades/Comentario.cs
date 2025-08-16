using Dominio.Entidades.Base;

namespace Dominio.Entidades;

public partial class Comentario : EntidadeBase
{
    public string? Comentario1 { get; set; }
    public int IdOrigem { get; set; }
    public int ReviewId { get; set; }
    public string TipoOrigem { get; set; } = null!;
    public int? UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
}
