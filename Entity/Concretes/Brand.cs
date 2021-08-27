using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concretes
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public string BrandImagePath { get; set; }

        
    }
}
