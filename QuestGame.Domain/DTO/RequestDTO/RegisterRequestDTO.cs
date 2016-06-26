using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.DTO.RequestDTO
{
    public class RegisterRequestDTO
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
