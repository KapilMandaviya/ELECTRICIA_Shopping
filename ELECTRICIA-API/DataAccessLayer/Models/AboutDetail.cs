using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class AboutDetail
{
    public int AbId { get; set; }

    public string? AboutHeader { get; set; }

    public string? AboutImgName { get; set; }

    public string? AboutDescription { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
