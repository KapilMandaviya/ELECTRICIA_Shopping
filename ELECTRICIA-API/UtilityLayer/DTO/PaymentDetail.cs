using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class PaymentDetail_DTO
    {
        public int PaymentId { get; set; }

        public int? OrderId { get; set; }

        public string? PaymentMethod { get; set; }

        public string? TransactionId { get; set; }

        public int? PaymentStatusId { get; set; }

        public double? Amount { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}