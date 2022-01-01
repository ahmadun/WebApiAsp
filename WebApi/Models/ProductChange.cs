using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ProductChange
    {
 
        public int Id { get; set; }
        public string product_no { get; set; }
        public int target{ get; set; }
        public int mp{ get; set; }
        public DateTime speed{ get; set; }
        public DateTime ent_dtm{ get; set; }
    }
}
