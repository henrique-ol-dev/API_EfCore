using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCore.Domains
{
    /// < summmary >
    /// Definir uma classe produto
    /// </ summary >
    public class Produto : BaseDomain
    {
    public string Nome { get; set;}
    public float Preco { get; set; }
    
    //Relacionamento com a tabela peiddoItem 1,4
    public List<PedidoItem> PedidosItens { get; set; }

    }
}
