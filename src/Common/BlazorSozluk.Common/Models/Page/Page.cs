using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Models.Page;

public class Page
{
    public Page() : this(0)
    {

    }

    public Page(int totalRowCount) :
        this(1, 10, totalRowCount)
    {

    }

    public Page(int pageSize, int totalRowCount) :
        this(1, pageSize, totalRowCount)
    {

    }

    public Page(int currentPage, int pageSize, int totalRowCount)
    {
        if (currentPage < 1)
            throw new ArgumentException("Invalid page number!");

        if (pageSize < 1)
            throw new ArgumentException("Invalid page size!");

        TotalRowCount = totalRowCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalRowCount { get; set; }

    public int TotalPageCount => (int)Math.Ceiling((double)TotalRowCount / PageSize);

    public int Skip => (CurrentPage - 1) * PageSize;
}
