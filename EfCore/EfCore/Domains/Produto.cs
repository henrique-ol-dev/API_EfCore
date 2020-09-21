using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EfCore.Domains
{
    /// < summmary >
    /// Definir uma classe produto
    /// </ summary >
    public class Produto : BaseDomain
    {
         public string Nome { get; set;}
        public float Preco { get; set; }
    

        [NotMapped] //Não mapeia a propriedade no banco de dados
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        //Url da imagem salva no servidor
        public string UrlImagem { get; set; }

        //Relacionamento com a tabela peiddoItem 1,4
        public List<PedidoItem> PedidosItens { get; set; }

    }
}
