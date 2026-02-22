using Domain.Interfaces.Base;
using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.Context;
using Infra.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Infra.Repositorios
{
    public class ComentarioRepositorio : RepositorioBase<Comentario>, IComentarioRepositorio
    {
        public ComentarioRepositorio(DbFaOuHaterContext context) : base(context)
        {
        }

        public IEnumerable<Comentario> ObterComentariosPorReview(int idReview)
        {
            return DbSet
                .Where(c => c.ReviewId == idReview)
                .OrderByDescending(c => c.CreatedAt);
        }
    }
}
