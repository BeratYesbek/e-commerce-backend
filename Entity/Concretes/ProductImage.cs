using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstracts;

namespace Entity.Concretes
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public int ProductId { get; set; }
    }
}