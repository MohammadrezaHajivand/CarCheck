using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Domain.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public int ModelId { get; set; }
        public int OwnerId { get; set; }
    }

}
