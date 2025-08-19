using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class ProductVariant_DTO
    {
        public int VarientId { get; set; }

        public int? ProductId { get; set; }

        public string? PvName { get; set; }

        public double? PvPrice { get; set; }

        public int? PvStock { get; set; }

        public string? PvSku { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}