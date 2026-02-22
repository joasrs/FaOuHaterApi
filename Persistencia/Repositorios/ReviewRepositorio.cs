using Dominio.Dtos.Review;
using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.Context;
using Infra.Repositorios.Base;

namespace Infra.Repositorios
{
    public class ReviewRepositorio : RepositorioBase<Review>, IReviewRepositorio
    {
        public ReviewRepositorio(DbFaOuHaterContext context) : base(context)
        {
        }

        public IEnumerable<ReviewRespostaDto> ObterReviews(int idUsuario)
        {
            return DbSet
                        //.Include( r => r.Usuario )
                        //.Include( r => r.Reacoes )
                        //.Include( r => r.Comentarios )
                        .Select(r => new ReviewRespostaDto
                        {
                            Id = r.Id,
                            Artista = r.Artista,
                            Musica = r.Musica,
                            Review1 = r.Review1,
                            Like = r.Like,
                            Dislike = r.Dislike,
                            CreatedAt = r.CreatedAt,
                            Usuario = r.Usuario,

                            UsuarioLike = r.Reacoes
                                .Where(reacao => reacao.UsuarioId == idUsuario)
                                .Select(reacao => reacao.Like)
                                .FirstOrDefault(),

                            UsuarioDislike = r.Reacoes
                                .Where(reacao => reacao.UsuarioId == idUsuario)
                                .Select(reacao => reacao.Dislike)
                                .FirstOrDefault(),

                            QtdLikes = r.Reacoes.Count(reacao => reacao.Like == true),
                            QtdDislikes = r.Reacoes.Count(reacao => reacao.Dislike == true),
                            QtdComentarios = r.Comentarios.Count
                        })
                        .OrderByDescending(r => r.CreatedAt);
        }
    }
}
