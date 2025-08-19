using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ReturnsMaster
{
    public int ReturnId { get; set; }

    public int? OrderId { get; set; }

    public int? ReasonId { get; set; }

    public string? ReturnStatus { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
