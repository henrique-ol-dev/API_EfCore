using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCore.Domains;
using EfCore.Interfaces;
using EfCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public List<Produto> Get()
        {
            return _produtoRepository.Listar();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Produto Get(Guid id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public void Post(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Produto produto)
        {
            produto.Id = id;
            _produtoRepository.Editar(produto);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _produtoRepository.Remover(id);
        }
    }
}