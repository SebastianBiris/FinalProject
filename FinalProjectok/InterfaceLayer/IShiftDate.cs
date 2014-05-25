using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IShiftDate
    {

        DateTime DateWorked { get; }
        int DateId { get; }
        IStaffMember MyIStaffMember { get; }
        int StaffMemberId { get; }
        int ShiftId { get; }
        string StaffMemberName { get; }
        DateTime ActualDate { get; }
        string ShiftType { get; }
    }
}
