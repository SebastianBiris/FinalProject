using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    //chris 15.05
    public interface IMessage
    {
        int MessageId { get; }
        int StaffMemberId { get; }
        string InboxMessage { get; }

    }
}
