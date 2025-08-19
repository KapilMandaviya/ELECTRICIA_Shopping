using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class LoginStatus
{
    public int LoginId { get; set; }

    public int UserId { get; set; }

    public string? Token { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? TokenExpiration { get; set; }

    public string? IpAddress { get; set; }

    public string? LoginStatus1 { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
