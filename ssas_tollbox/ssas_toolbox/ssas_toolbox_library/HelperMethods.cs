using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssas_toolbox_library
{
    public static class HelperMethods
    {
        public static List<string> ParseMemberSetToList(string MemberSet)
        {
            List<string> memberSetList = new List<string>();

            memberSetList = MemberSet.TrimStart('{').TrimEnd('}').Split(',').ToList().Select( x=> x.Trim()).ToList();

            return memberSetList;
        }
    }
}
