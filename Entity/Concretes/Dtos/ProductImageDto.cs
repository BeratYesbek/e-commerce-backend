using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Entities.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Entity.Concretes.Dtos
{
    public class ProductImageDto : IDto
    {
        public int Id { get; set; }

        public IFormFile[] File { get; set; }

        public int ProductId { get; set; }

        public string ImagePath { get; set; }
    }
}