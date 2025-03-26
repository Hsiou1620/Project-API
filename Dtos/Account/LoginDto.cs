using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace game_shop.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}
