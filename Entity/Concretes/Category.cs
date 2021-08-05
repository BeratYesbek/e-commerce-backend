using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstracts;

namespace Entity.Concretes
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
