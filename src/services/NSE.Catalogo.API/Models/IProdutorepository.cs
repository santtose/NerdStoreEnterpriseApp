using NSE.Core.Data;

namespace NSE.Catalogo.API.Models
{
    public interface IProdutorepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
