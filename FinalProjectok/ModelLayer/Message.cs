using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer;

namespace ModelLayer
{
    //chris 15.05
   public class Message : IMessage
    {
        int _messageId;
        int _staffMemberId;
         string _inboxMessage;
       

       public Message(int messageId, string inboxMessage,int staffMemberId)
       {
           _messageId = messageId;
           _inboxMessage = inboxMessage;
           _staffMemberId = staffMemberId;
       }

       public int MessageId
       {
           get { return _messageId; }
           set { _messageId = value; }
       }

       public string InboxMessage
       {
           get { return _inboxMessage; }
           set { _inboxMessage = value; }
       }

       public int StaffMemberId
       {
           get { return _staffMemberId; }
           set { _staffMemberId = value; }
       }

       public override string ToString()
       {
           return MessageId.ToString() + "  " + StaffMemberId.ToString() + "  " + InboxMessage;
       }
    }
}
