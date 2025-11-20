using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Domain.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
    }
}
