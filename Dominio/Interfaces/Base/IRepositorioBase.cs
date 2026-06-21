namespace Dominio.Interfaces.Base;

public interface IRepositorioBase<TEntidade>
{
    TEntidade? GetById(int id);
    IEnumerable<TEntidade> ObterTodos();
    bool Add(TEntidade entity);
    bool Update(TEntidade entity);
    bool Delete(TEntidade entity);
    bool SaveChanges();
    bool Existe(int id);
}
