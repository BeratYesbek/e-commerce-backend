using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concretes
{
    public class CartSummary : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }
    }
}
