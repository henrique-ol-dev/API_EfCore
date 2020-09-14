using EfCore.Contexts;
using EfCore.Domains;
using EfCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> pedidoItens)
        {
            try
            {
                //Criação do objeto do tipo pedido passando os valores
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now
                };

                //Percorre a lista de pedidos itens e adiciona a lista de pedidos itens 
                foreach (var item in pedidoItens)
                {
                    //Adiciona um pedidoitem a lista
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, //Id do produto pedido acima
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }

                //Adicionar o pedido ao contexto
                _ctx.Pedidos.Add(pedido);
                //Salva as alterações do contexto no banco de dados
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos.Include(c => c.PedidosItens ).ThenInclude(c => c.Produto).FirstOrDefault(p => p.Id == id);//inner join
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }

}
