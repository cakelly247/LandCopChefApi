using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LccApi.Models;

public class CommentModel
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Text { get; set; } = string.Empty;

    [Required, ForeignKey("UserModel")]
    public int AuthorId { get; set; }

    [Required, ForeignKey("PostModel")]
    public int PostId { get; set; }
}