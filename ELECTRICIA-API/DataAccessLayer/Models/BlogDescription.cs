using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class BlogDescription
{
    public int BlogId { get; set; }

    public string? BlogImage { get; set; }

    public string? BlogCaption { get; set; }

    public string? BlogBy { get; set; }

    public DateOnly? BlogDate { get; set; }

    public string? BlogDescription1 { get; set; }

    public string? BlogTags { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsDelete { get; set; }

    public string? ModifyAction { get; set; }
}
