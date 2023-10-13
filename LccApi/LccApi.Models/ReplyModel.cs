using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LccApi.Models;

public class ReplyModel
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Text { get; set; } = string.Empty;

    [Required, ForeignKey("CommentModel")]
    public int ParentId { get; set; }

    [Required, ForeignKey("UserModel")]
    public int AuthorId { get; set; }
}
