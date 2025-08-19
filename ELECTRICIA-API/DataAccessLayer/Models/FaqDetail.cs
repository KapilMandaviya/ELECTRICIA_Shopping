using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class FaqDetail
{
    public int FaqId { get; set; }

    public string? FaqQuestion { get; set; }

    public string? FaqAnswer { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
