using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Events.EntryComment;
public class DeleteEntryCommentVoteEvent
{
    public Guid EntryCommentId { get; set; }

    public Guid CreatedBy { get; set; }
}
