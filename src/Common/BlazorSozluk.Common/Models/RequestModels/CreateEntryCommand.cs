using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Models.RequestModels;
public class CreateEntryCommand: IRequest<Guid>
{
    public string Subject { get; set; }

    public string Content { get; set; }

    public Guid? CreatedById { get; set; }

    public CreateEntryCommand()
    {

    }

    public CreateEntryCommand(string subject, string content, Guid? createdById)
    {
        Subject = subject;
        Content = content;
        CreatedById = createdById;
    }
}
