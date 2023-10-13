using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LccApi.Models.Reply
{
    public class CreateReplyModel
    {
        public string Text { get; set; } = string.Empty;
        public int CommentId { get; set; }
        public int AuthorId { get; set; }
    }
}