namespace Domain.Interfaces.Base
{
    public interface IRepositorioBase<TEntidade>
    {
        TEntidade? Obter(int id);
        IEnumerable<TEntidade> ObterTodos();
        bool Add(TEntidade entity);
        bool Update(TEntidade entity);
        bool Delete(int id);
        bool SalvarAlteracaoes();
    }
}
