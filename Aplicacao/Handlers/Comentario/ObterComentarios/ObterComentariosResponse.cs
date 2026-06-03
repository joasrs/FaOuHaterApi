namespace Aplicacao.Handlers.Comentario.ObterComentarios;

public class ObterComentariosResponse
{
    public int IdUsuario { get; set; }
    public string NomeUsuario { get; set; } = null!;
    public string LoginUsuario { get; set; } = null!;
    public string? UrlImagemPerfilUsuario { get; set; } = null!;
    public string Comentario { get; set; } = string.Empty;
}
