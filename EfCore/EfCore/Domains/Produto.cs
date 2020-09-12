using System;
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

    }
}
