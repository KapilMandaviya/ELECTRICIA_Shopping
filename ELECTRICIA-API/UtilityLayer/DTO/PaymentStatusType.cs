using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class PaymentStatusType_DTO
    {
        public int PaymentStatusId { get; set; }

        public string? PstatusTyp { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}