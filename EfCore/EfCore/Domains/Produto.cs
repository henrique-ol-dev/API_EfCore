using System;
using System.ComponentModel.DataAnnotations;

namespace EfCore.Domains
{
    /// < summmary >
    /// Definir uma classe produto
    /// </ summary >
    public class Produto
    {
    [Key] 
    public Guid Id { get; set; }
    public string Nome { get; set;}
    public float Preco { get; set; }

    public Produto ()
    {
        Id = Guid.NewGuid();
    }
}
}
