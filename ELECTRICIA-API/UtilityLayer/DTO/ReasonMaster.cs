using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class ReasonMaster_DTO
    {
        public int ReasonId { get; set; }

        public string? ReasonType { get; set; }

        public string? ReasonRemarks { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}