using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Business.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = new int();
        }
        public int Id { get; set; }
    }
}
