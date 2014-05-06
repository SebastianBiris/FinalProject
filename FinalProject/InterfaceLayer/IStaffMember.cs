using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IStaffMember
    {
        int cpr {get;}
        int userId { get; }
        string phoneNumber { get; }
        string password { get; }
        string staffMemberName { get; }
        string email { get; }
    }
}
