using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstracts;

namespace Entity.Concretes
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}