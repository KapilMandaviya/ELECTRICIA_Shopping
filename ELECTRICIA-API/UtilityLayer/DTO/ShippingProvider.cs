using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{
    public partial class ShippingProvider_DTO
    {
        public int ProviderId { get; set; }

        public string? ProviderName { get; set; }

        public string? TrackingUrl { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}