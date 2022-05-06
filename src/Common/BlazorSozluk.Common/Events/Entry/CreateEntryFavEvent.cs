using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Events.Entry;
public class CreateEntryFavEvent
{
    public Guid EntryId { get; set; }

    public Guid CreatedBy { get; set; }
}
