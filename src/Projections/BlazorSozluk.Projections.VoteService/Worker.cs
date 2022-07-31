using BlazorSozluk.Common;
using BlazorSozluk.Common.Events.Entry;
using BlazorSozluk.Common.Events.EntryComment;
using BlazorSozluk.Common.Infrastructure;
using Microsoft.Extensions.Logging;

namespace BlazorSozluk.Projections.VoteService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly IConfiguration configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var connStr = configuration.GetConnectionString("SqlServer");

        var voteService = new Services.VoteService(connStr);

        QueueFactory.CreateBasicConsumer()
            .EnsureExchange(SozlukConstants.VoteExchangeName)
            .EnsureQueue(SozlukConstants.CreateEntryVoteQueueName, SozlukConstants.VoteExchangeName)
            .Receive<CreateEntryVoteEvent>(vote =>
            {
                voteService.CreateEntryVote(vote).GetAwaiter().GetResult();
                logger.LogInformation("Create Entry Received EntryId: {0}, VoteType: {1}", vote.EntryId, vote.VoteType);
            })
            .StartConsuming(SozlukConstants.CreateEntryVoteQueueName);

        QueueFactory.CreateBasicConsumer()
            .EnsureExchange(SozlukConstants.VoteExchangeName)
            .EnsureQueue(SozlukConstants.DeleteEntryVoteQueueName, SozlukConstants.VoteExchangeName)
            .Receive<DeleteEntryVoteEvent>(vote =>
            {
                voteService.DeleteEntryVote(vote.EntryId, vote.CreatedBy).GetAwaiter().GetResult();
                logger.LogInformation("Delete Entry Received EntryId: {0}", vote.EntryId);
            })
            .StartConsuming(SozlukConstants.DeleteEntryVoteQueueName);


        QueueFactory.CreateBasicConsumer()
                .EnsureExchange(SozlukConstants.VoteExchangeName)
                .EnsureQueue(SozlukConstants.CreateEntryCommentVoteQueueName, SozlukConstants.VoteExchangeName)
                .Receive<CreateEntryCommentVoteEvent>(vote =>
                {
                    voteService.CreateEntryCommentVote(vote).GetAwaiter().GetResult();
                    logger.LogInformation("Create Entry Comment Received EntryCommentId: {0}, VoteType: {1}", vote.EntryCommentId, vote.VoteType);
                })
                .StartConsuming(SozlukConstants.CreateEntryCommentVoteQueueName);

        QueueFactory.CreateBasicConsumer()
                .EnsureExchange(SozlukConstants.VoteExchangeName)
                .EnsureQueue(SozlukConstants.DeleteEntryCommentVoteQueueName, SozlukConstants.VoteExchangeName)
                .Receive<DeleteEntryCommentVoteEvent>(vote =>
                {
                    voteService.DeleteEntryCommentVote(vote.EntryCommentId, vote.CreatedBy).GetAwaiter().GetResult();
                    logger.LogInformation("Delete Entry Comment Received EntryCommentId: {0}", vote.EntryCommentId);
                })
                .StartConsuming(SozlukConstants.DeleteEntryCommentVoteQueueName);
    }
}
