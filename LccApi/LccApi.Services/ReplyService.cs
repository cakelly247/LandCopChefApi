using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LccApi.Models;
using LccApi.Models.Reply;
using LccApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LccApi.Services
{
    public class ReplyService : IReplyService
    {
        private readonly LccDbContext _dbContext;

        public ReplyService(LccDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ReplyEntity> CreateReplyAsync(CreateReplyModel model)
        {
            var reply = new ReplyEntity()
            {
                Text = model.Text,
                ParentId = model.CommentId,
                AuthorId = model.AuthorId
            };

            await _dbContext.Replies.AddAsync(reply);
            await _dbContext.SaveChangesAsync();
            return reply;
        }

        public Task<List<ReplyEntity>> GetRepliesByCommentIdAsync(int commentId)
        {
            return _dbContext.Replies.Where(r => r.ParentId == commentId).ToListAsync();
        }
    }
}