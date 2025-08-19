using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class EnquiryDetail
{
    public int EnqId { get; set; }

    public string? EnqName { get; set; }

    public string? EmailAddress { get; set; }

    public int? PhoneNo { get; set; }

    public string? EnqSubject { get; set; }

    public string? EnqMessage { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
