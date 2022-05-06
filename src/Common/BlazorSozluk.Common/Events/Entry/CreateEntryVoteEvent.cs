using BlazorSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Events.Entry;
public class CreateEntryVoteEvent
{
    public Guid EntryId { get; set; }

    public VoteType  VoteType { get; set; }

    public Guid CreatedBy { get; set; }
}
