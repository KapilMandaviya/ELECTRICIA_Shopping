using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ReasonMaster
{
    public int ReasonId { get; set; }

    public string? ReasonType { get; set; }

    public string? ReasonRemarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
