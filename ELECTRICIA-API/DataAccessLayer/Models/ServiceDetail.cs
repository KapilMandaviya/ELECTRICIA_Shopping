using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ServiceDetail
{
    public int ServiceId { get; set; }

    public string? ServiceCaption { get; set; }

    public string? ServiceDetail1 { get; set; }

    public string? ServiceLink { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
