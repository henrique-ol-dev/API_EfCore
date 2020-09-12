using EfCore.Contexts;
using EfCore.Domains;
using EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }
      
        /// <summary>
        /// Busca um produto pelo seu id
        /// </summary>
        /// <param name="id">Id do Produto</param>
        /// <returns>Lista de Produtos</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return _ctx.Produtos.FirstOrDefault(c => c.Id == id);
                return _ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca produtos pelo nome
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        /// <returns>Retorna um produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos osa produtos produtos cadastrados       
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex) 
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Produto a ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se o produto existe
                //Caso não exista gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista altera suas propriedades
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera produto no contexto
                _ctx.Produtos.Update(produtoTemp);

                //Salva o contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo projeto
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                _ctx.Produtos.Add(produto);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(id);

                //Verifica se o produto existe
                //Caso não exista gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Remove o produto do dbSet
                _ctx.Produtos.Remove(produtoTemp);
                //Salva as alterações do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
