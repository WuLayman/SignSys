using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PublicBaseClassProj
{
    [DataContract]
    public enum TimetableAndExpPic
    {
        [EnumMember]
        课程表,
        [EnumMember]
        实验表
    }
}
