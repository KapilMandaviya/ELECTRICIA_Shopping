using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ReviewVote
{
    public int VoteId { get; set; }

    public int? ReviewId { get; set; }

    public int? UserId { get; set; }

    public string? VoteType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
