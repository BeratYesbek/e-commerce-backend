using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concretes
{
    public class Color :IEntity
    {
        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public string ColorCode { get; set; }
    }
}
