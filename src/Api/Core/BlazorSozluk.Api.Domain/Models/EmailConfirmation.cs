using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models;
public class EmailConfirmation : BaseEntity
{
    public string OldEmailAddress { get; set; }

    public string NewEmailAddress { get; set; }
}
