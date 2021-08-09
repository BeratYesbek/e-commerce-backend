using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstracts;

namespace Entity.Concretes.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
