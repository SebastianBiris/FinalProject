using System;
namespace InterfaceLayer
{
   public interface IStaffMember
    {

        int Cpr { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
        string StaffMemberName { get; set; }
        int StaffMemeberId { get; set; }
    }
}
