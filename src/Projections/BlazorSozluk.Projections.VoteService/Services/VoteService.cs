using BlazorSozluk.Common.Events.Entry;
using BlazorSozluk.Common.Events.EntryComment;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Projections.VoteService.Services;
public class VoteService
{
    private readonly string connectionString;

    public VoteService(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task CreateEntryVote(CreateEntryVoteEvent vote)
    {
        await DeleteEntryVote(vote.EntryId, vote.CreatedBy);

        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync("INSERT INTO ENTRYVOTE (Id, CreateDate, EntryId, VoteType, CreatedById) VALUES (@Id, GETDATE(), @EntryId, @VoteType, @CreatedById)",
            new
            {
                Id = Guid.NewGuid(),
                EntryId = vote.EntryId,
                VoteType = (int)vote.VoteType,
                CreatedById = vote.CreatedBy
            });
    }

    public async Task DeleteEntryVote(Guid entryId, Guid userId)
    {
        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync("DELETE FROM EntryVote WHERE EntryId = @EntryId AND CREATEDBYID = @UserId",
            new
            {
                EntryId = entryId,
                UserId = userId
            });
    }

    public async Task CreateEntryCommentVote(CreateEntryCommentVoteEvent vote)
    {
        await DeleteEntryCommentVote(vote.EntryCommentId, vote.CreatedBy);

        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync("INSERT INTO ENTRYCOMMENTVOTE (Id, CreateDate, EntryCommentId, VoteType, CREATEDBYID) VALUES (@Id, GETDATE(), @EntryCommentId, @VoteType, @CreatedById)",
            new
            {
                Id = Guid.NewGuid(),
                EntryCommentId = vote.EntryCommentId,
                VoteType = Convert.ToInt16(vote.VoteType),
                CreatedById = vote.CreatedBy
            });
    }

    public async Task DeleteEntryCommentVote(Guid entryCommentId, Guid userId)
    {
        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync("DELETE FROM EntryCommentVote WHERE EntryCommentId = @EntryCommentId AND CREATEDBYID = @UserId",
            new
            {
                EntryCommentId = entryCommentId,
                UserId = userId
            });
    }
}
