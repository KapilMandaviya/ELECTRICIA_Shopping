using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class RoleMaster_DTO
    {
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}