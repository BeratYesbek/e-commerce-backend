using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concretes
{
    public class Comment :  IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Rating { get; set; }

        public string ProductComment { get; set; }
    }
}
