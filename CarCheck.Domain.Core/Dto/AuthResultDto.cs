using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Domain.Core.Dto
{
    public class AuthResultDto
    {
        public bool IsSuccess { get; set; }
        public bool IsAdmin { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }
    }


}
