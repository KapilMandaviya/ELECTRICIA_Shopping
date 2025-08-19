using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ProductAttribute
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
