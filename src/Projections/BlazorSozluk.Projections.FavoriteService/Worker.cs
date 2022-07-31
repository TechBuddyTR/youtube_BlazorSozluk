using BlazorSozluk.Common;
using BlazorSozluk.Common.Events.Entry;
using BlazorSozluk.Common.Events.EntryComment;
using BlazorSozluk.Common.Infrastructure;

namespace BlazorSozluk.Projections.FavoriteService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        this.configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var connStr = configuration.GetConnectionString("SqlServer");

        var favService = new Services.FavoriteService(connStr);

        QueueFactory.CreateBasicConsumer()
            .EnsureExchange(SozlukConstants.FavExchangeName)
            .EnsureQueue(SozlukConstants.CreateEntryFavQueueName, SozlukConstants.FavExchangeName)
            .Receive<CreateEntryFavEvent>(fav =>
            {
                favService.CreateEntryFav(fav).GetAwaiter().GetResult();
                _logger.LogInformation($"Received EntryId {fav.EntryId}");
            })
            .StartConsuming(SozlukConstants.CreateEntryFavQueueName);

        QueueFactory.CreateBasicConsumer()
            .EnsureExchange(SozlukConstants.FavExchangeName)
            .EnsureQueue(SozlukConstants.DeleteEntryFavQueueName, SozlukConstants.FavExchangeName)
            .Receive<DeleteEntryFavEvent>(fav =>
            {
                favService.DeleteEntryFav(fav).GetAwaiter().GetResult();
                _logger.LogInformation($"Deleted Received EntryId {fav.EntryId}");
            })
            .StartConsuming(SozlukConstants.DeleteEntryFavQueueName);


        
        QueueFactory.CreateBasicConsumer()
            .EnsureExchange(SozlukConstants.FavExchangeName)
            .EnsureQueue(SozlukConstants.CreateEntryCommentFavQueueName, SozlukConstants.FavExchangeName)
            .Receive<CreateEntryCommentFavEvent>(fav =>
            {
                favService.CreateEntryCommentFav(fav).GetAwaiter().GetResult();
                _logger.LogInformation($"Create EntryComment Received EntryCommentId {fav.EntryCommentId}");
            })
            .StartConsuming(SozlukConstants.CreateEntryCommentFavQueueName);


        QueueFactory.CreateBasicConsumer()
            .EnsureExchange(SozlukConstants.FavExchangeName)
            .EnsureQueue(SozlukConstants.DeleteEntryCommentFavQueueName, SozlukConstants.FavExchangeName)
            .Receive<DeleteEntryCommentFavEvent>(fav =>
            {
                favService.DeleteEntryCommentFav(fav).GetAwaiter().GetResult();
                _logger.LogInformation($"Deleted Received EntryCommentId {fav.EntryCommentId}");
            })
            .StartConsuming(SozlukConstants.DeleteEntryCommentFavQueueName);
    }
}
