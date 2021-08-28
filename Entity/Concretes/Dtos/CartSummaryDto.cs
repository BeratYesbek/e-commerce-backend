using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concretes.Dtos
{
    public class CartSummaryDto
    {
        public int Id {  get; set; }

        public int ProductId {  get; set; }

        public int UserId { get; set; }

        public Category Category { get; set; }

        public Product Product { get; set; }

        public Brand Brand { get; set; }

        public Color Color { get; set; }

        public List<string> Images { get; set; }

    }
}
