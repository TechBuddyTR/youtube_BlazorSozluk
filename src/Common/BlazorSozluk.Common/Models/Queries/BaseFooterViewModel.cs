using BlazorSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Models.Queries;
public class BaseFooterRateViewModel
{
    public VoteType VoteType { get; set; }
}

public class BaseFooterFavoritedViewModel
{
    public bool IsFavorited { get; set; }

    public int FavoritedCount { get; set; }
}

public class BaseFooterRateFavoritedViewModel: BaseFooterFavoritedViewModel
{
    public VoteType VoteType { get; set; }
}
