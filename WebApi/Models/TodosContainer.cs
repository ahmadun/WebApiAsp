using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class TodosContainer
    {

        public int Count { get; set; }
        public List<ProductChange> Product { get; set; }
    }
}
