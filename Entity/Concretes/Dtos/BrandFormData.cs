using Core.Entities.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concretes.Dtos
{
    public class BrandFormData : IDto
    {
        public IFormFile file { get; set; }

        public string BrandName { get; set; }
    }
}
