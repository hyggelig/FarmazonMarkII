using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Farmazon.DAL
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long productId { get; set; }
        public string productName { get; set; }
        public long? productOwnerId { get; set; }
        public string productOwnerName { get; set; }
        public string productOwnerLastName { get; set; }
    }
}
