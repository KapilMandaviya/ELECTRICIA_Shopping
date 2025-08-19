using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLayer.DTO
{
    public class ContactUs
    {
        public int ContactId { get; set; }

        public string? EmailAddress { get; set; }

        public int? PhoneNumber { get; set; }

        public string? OfficeAddress { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}
