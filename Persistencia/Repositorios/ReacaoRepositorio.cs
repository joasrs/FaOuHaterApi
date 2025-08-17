using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.Context;
using Infra.Repositorios.Base;

namespace Infra.Repositorios
{
    public class ReacaoRepositorio : RepositorioBase<Reacao>, IReacaoRepositorio
    {
        public ReacaoRepositorio(DbFaOuHaterContext context) : base(context)
        {
        }

        public Reacao? ObterReacaoPorUsuarioReview(int idUsuario, int idReview)
        {
            return DbSet.FirstOrDefault(r => r.UsuarioId == idUsuario && r.ReviewId == idReview);
        }
    }
}
