using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ProductsMaster
{
    public int ProductId { get; set; }

    public string? PName { get; set; }

    public string? PSku { get; set; }

    public int? CategoryId { get; set; }

    public double? PBasePrice { get; set; }

    public int? PStock { get; set; }

    public string? PDescription { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
