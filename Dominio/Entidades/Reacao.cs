using Dominio.Entidades.Base;
using Dominio.Enum;

namespace Dominio.Entidades;

public partial class Reacao : EntidadeBase
{
    public bool? Like { get; set; }
    public bool? Dislike { get; set; }
    public int? ReviewId { get; set; }
    public virtual Review? Review { get; set; }
    public int? UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public EnumTipoReacao TipoReacao { get; set; }
}
