using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class UserAddress
{
    public int AddId { get; set; }

    public int? UserId { get; set; }

    public string? AddressType { get; set; }

    public string? StreetName { get; set; }

    public int? CityId { get; set; }

    public int? ZipCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
