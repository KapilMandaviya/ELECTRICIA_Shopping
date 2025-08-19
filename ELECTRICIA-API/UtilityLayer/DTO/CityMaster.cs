using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class CityMaster_DTO
    {
        public int CityId { get; set; }

        public int? StateId { get; set; }

        public string? CityName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}