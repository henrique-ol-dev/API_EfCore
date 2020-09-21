using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EfCore.Domains;
using EfCore.Interfaces;
using EfCore.Repositories;
using EfCore.Utils;
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
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repository
                var produtos = _produtoRepository.Listar();

                //Verifica se existe produtos, caso não exista retorna NoContent - Sem conteúdo
                if (produtos.Count == 0)
                    return NoContent();

                //Caso exista retorna ok e produtos
                return Ok(new
                {
                    totalCount = produtos.Count,
                    data = produtos
                }); 
            }
            catch (Exception ex)
            {
                //TODO : Cadastrar mensagem de erro no dominio logErro
                return BadRequest(new {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos, envie umeamil para emial@email.com informando"
                    });
            }
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busca os produtos no repository
                Produto produto = _produtoRepository.BuscarPorId(id);

                //Verifica se existe produtos, caso não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso exista retorna ok e os dados do produto
                return Ok(produto);

            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensgaem de erro
                return BadRequest(ex.Message);
            }
        }

        //[FromForm] Recebe os dados do produto via form-data
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                //Verifica se foi enviado um arquibo com a imagem
                if (produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = urlImagem;

                }
                //Adiciona um produto
                _produtoRepository.Adicionar(produto);

                //retorna ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensgaem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);

                if (produtoTemp == null)
                    return NotFound();

               
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensgaem de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensgaem de erro
                return BadRequest(ex.Message);
            }
        }
    }
}