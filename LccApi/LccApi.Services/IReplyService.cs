using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LccApi.Models;
using LccApi.Models.Reply;

namespace LccApi.Services
{
    public interface IReplyService
    {
        Task<List<ReplyEntity>> GetRepliesByCommentIdAsync(int commentId);

        Task<ReplyEntity> CreateReplyAsync(CreateReplyModel model);
    }
}