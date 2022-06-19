namespace BlazorSozluk.WebApp.Infrastructure.Models;

public class VoteClickedEventArgs: EventArgs
{
    public Guid EntryId { get; set; }

    public bool IsUpVoteClicked { get; set; }

    public bool UpVoteDeleted { get; set; }


    public bool IsDownVoteClicked { get; set; }
    public bool DownVoteDeleted { get; set; }
}
