using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Entity;

namespace Assignment.Service
{
    interface MemberService
    {
        String Login(MemberLogin memberLogin);
        Member Register(Member member);
        Member GetInformation(string token);
    }
}
