using Dominio.Dtos.Review;
using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Context;

namespace Aplicacao.Services
{
    public class ReviewService : IServiceBase<ReviewRequisicaoDto, ReviewRespostaDto>
    {
        DbFaOuHaterContext _context;
        private readonly IUsuarioContext _usuarioContext;

        public ReviewService( DbFaOuHaterContext dbFaOuHaterContext, IUsuarioContext usuarioContext )
        {
            _context = dbFaOuHaterContext;
            _usuarioContext = usuarioContext;
        }

        public IEnumerable<ReviewRespostaDto> Get()
        {
            try
            {
                var usuarioId = 1;

                var r = usuarioId switch
                {
                    1 => "teste switch",
                    2 => "teste switch",
                    3 => "teste switch",
                    _ => "default swicth"
                };

                var consulta = _context.Reviews
                                //.Include( r => r.Usuario )
                                //.Include( r => r.Reacoes )
                                //.Include( r => r.Comentarios )
                                .Select( r => new ReviewRespostaDto
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
                                        .Where( reacao => reacao.UsuarioId == usuarioId )
                                        .Select( reacao => reacao.Like )
                                        .FirstOrDefault(),

                                    UsuarioDislike = r.Reacoes
                                        .Where( reacao => reacao.UsuarioId == usuarioId )
                                        .Select( reacao => reacao.Dislike )
                                        .FirstOrDefault(),

                                    QtdLikes = r.Reacoes.Count( reacao => reacao.Like == true ),
                                    QtdDislikes = r.Reacoes.Count( reacao => reacao.Dislike == true ),
                                    QtdComentarios = r.Comentarios.Count
                                } )
                                .OrderByDescending( r => r.CreatedAt );

                return consulta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception( "Erro ao buscar as reviews", ex );
            }
        }

        public ReviewRespostaDto Get( int id )
        {
            throw new NotImplementedException();
        }

        public ReviewRespostaDto Post( ReviewRequisicaoDto target )
        {
            throw new NotImplementedException();
        }
    }
}