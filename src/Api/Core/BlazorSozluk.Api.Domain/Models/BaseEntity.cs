using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models;
public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreateDate { get; set; }
}
