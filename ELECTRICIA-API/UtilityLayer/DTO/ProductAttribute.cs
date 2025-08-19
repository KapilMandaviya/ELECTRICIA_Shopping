using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{
    public partial class ProductAttribute_DTO
    {
        public int AttributeId { get; set; }

        public int? ProductId { get; set; }

        public string? PaName { get; set; }

        public string? PaValue { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}