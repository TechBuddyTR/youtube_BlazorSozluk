using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Events.User;
public class UserEmailChangedEvent
{
    public string OldEmailAddress { get; set; }

    public string NewEmailAddress { get; set; }
}
