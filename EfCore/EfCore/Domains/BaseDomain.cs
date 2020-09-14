using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Domains
{
    public abstract class BaseDomain
    {
        [Key]
        public Guid Id { get; private set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();  
        }
        public void setId(Guid id)
        {
            this.Id = id;
        }
    }
}
