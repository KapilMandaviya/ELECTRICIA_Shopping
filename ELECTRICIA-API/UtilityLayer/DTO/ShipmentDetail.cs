using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class ShipmentDetail_DTO
    {
        public int ShipmentId { get; set; }

        public int? OrderId { get; set; }

        public int? ProviderId { get; set; }

        public string? TrackingNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}