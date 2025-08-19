using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CategoriesMaster
{
    public int CategoriesId { get; set; }

    public int? PcId { get; set; }

    public string? CatName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
