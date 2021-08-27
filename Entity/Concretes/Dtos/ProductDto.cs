using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concretes.Dtos
{
    public class ProductDto : IDto
    {
        public int ProductId { get; set; }

        public string ProductDescription { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int BrandId {  get; set; }

        public string BrandName { get; set; }

        public string BrandLogo { get; set; }

        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public string ColorCode { get; set; }

        public List<Comment> Comments { get; set; }

        public List<String> Images { get;set; }
    }
}
