using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class AccessoriesMaster
{
    public int AccessoryId { get; set; }

    public string? Name { get; set; }

    public string? CompatibleProductId { get; set; }

    public double? Price { get; set; }

    public int? Stock { get; set; }

    public string? Description { get; set; }

    public string? ImgName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
