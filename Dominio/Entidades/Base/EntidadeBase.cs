namespace Dominio.Entidades.Base;

public abstract class EntidadeBase
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
