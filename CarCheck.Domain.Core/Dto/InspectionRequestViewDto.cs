using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Domain.Core.Dto
{
    public class InspectionRequestViewDto
    {
        public int RequestId { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public string PlateNumber { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Status { get; set; }
    }


}
