using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BlazorSozluk.Api.Application.Features.Queries.GetEntries;

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, List<GetEntriesViewModel>>
{
    private readonly IEntryRepository entryRepository;
    private readonly IMapper mapper;

    public GetEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        this.entryRepository = entryRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetEntriesViewModel>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = entryRepository.AsQueryable();

        if (request.TodaysEntries)
        {
            query = query
                .Where(i => i.CreateDate >= DateTime.Now.Date)
                .Where(i => i.CreateDate <= DateTime.Now.AddDays(1).Date);
        }

        query = query.Include(i => i.EntryComments)
            .OrderBy(i => Guid.NewGuid())
            .Take(request.Count);

        return await query.ProjectTo<GetEntriesViewModel>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
