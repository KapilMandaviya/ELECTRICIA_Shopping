using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? OrderStatusId { get; set; }

    public int? TotalAmount { get; set; }

    public int? PaymentStatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
