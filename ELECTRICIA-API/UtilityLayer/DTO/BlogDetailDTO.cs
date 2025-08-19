using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLayer.DTO
{
    public class BlogDetailDTO
    {
        public int Blog_Id { get; set; }

        public string? Blog_Image { get; set; }

        public string? Blog_Caption { get; set; }

        public string? Blog_By { get; set; }

        public DateOnly? Blog_Date { get; set; }

        public string? Blog_Description { get; set; }

        public string? Blog_Tags { get; set; }

        public DateTime? comment_date { get; set; }

        public string? Comment_Description { get; set; }

        public int?  Cm_Id { get; set; }

        public string? Name { get; set; }

    }
}
