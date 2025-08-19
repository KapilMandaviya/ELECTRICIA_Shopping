using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLayer.DTO
{
    public class BlogDetailCommentsDto
    {
        public int CmId { get; set; }

        public int? BlogId { get; set; }
        public int? UserId { get; set; }

        public DateTime? CommentDate { get; set; }

        public string? CommentDescription { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsDelete { get; set; }

        public string? ModifyAction { get; set; }
    }
}
