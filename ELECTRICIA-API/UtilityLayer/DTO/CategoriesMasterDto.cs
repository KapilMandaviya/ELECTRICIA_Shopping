using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class CategoriesMasterDto
    {
        public int CategoriesId { get; set; }

        public int? PC_Id { get; set; }

        public string? PC_Name { get; set; }

        public string? Cat_Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }

        public string? category{ get; set; }

        public string? subcategories { get; set; }
    }
}