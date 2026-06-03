using Dominio.Dtos.Review;
using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.Context;
using Infra.Repositorios.Base;

namespace Infra.Repositorios;

public class ReviewRepositorio : RepositorioBase<Review>, IReviewRepositorio
{
    public ReviewRepositorio(DbFaOuHaterContext context) : base(context)
    {
    }

    public IEnumerable<ReviewRespostaDto> ObterReviews(ObterReviewsFiltroDto filtro)
    {
        var query = DbSet
            .Select(r => new ReviewRespostaDto
            {
                Id = r.Id,
                Artista = r.Artista,
                Musica = r.Musica,
                Review1 = r.Review1,
                Like = r.Like,
                Dislike = r.Dislike,
                CreatedAt = r.CreatedAt,

                Usuario = new ReviewRespostaUsuarioDto
                {
                    Id = r.Usuario.Id,
                    Nome = r.Usuario.Nome,
                    Login = r.Usuario.Login,
                    UrlImagemPerfil = r.Usuario.UrlImagemPerfil ?? string.Empty
                },

                UsuarioLike = r.Reacoes
                    .Where(reacao => reacao.UsuarioId == filtro.IdUsuarioAutenticado)
                    .Select(reacao => reacao.Like)
                    .FirstOrDefault(),

                UsuarioDislike = r.Reacoes
                    .Where(reacao => reacao.UsuarioId == filtro.IdUsuarioAutenticado)
                    .Select(reacao => reacao.Dislike)
                    .FirstOrDefault(),

                QtdLikes = r.Reacoes.Count(reacao => reacao.Like == true),
                QtdDislikes = r.Reacoes.Count(reacao => reacao.Dislike == true),
                QtdComentarios = r.Comentarios.Count
            });

        if(filtro.IdUsuario > 0)
            query = query.Where(r => r.Usuario.Id == filtro.IdUsuario);

        return query.OrderByDescending(r => r.CreatedAt).ToList();
    }
}
