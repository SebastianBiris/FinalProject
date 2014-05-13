using System;
namespace InterfaceLayer
{
   public interface IStaffMember
    {

        string Cpr { get;}
        string Email { get; }
        string Password { get; }
        string PhoneNumber { get;}
        string StaffMemberName { get; }
        int StaffMemeberId { get;}
        string StatusDescription { get; }
        int TitleId { get; }
        int RoleId { get; }
    }
    
}
