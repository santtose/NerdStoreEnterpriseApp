using NSE.Core.Data;
using NSE.Pedidos.Domain.Pedidos;
using System.Data.Common;

namespace NSE.Pedidos.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosContext _context;

        public PedidoRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DbConnection ObterConexao()
        {
            throw new NotImplementedException();
        }

        public Task<PedidoItem> ObterItemPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
