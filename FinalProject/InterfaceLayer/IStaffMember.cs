using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IStaffMember
    {
        int Cpr {get;}
        int StaffMemsberId { get; }
        string PhoneNumber { get; }
        string Password { get; }
        string StaffMemberName { get; }
        string Email { get; }
    }
}
