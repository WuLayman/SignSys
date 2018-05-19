using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicBaseClassProj
{
    public class LeaveMessage
    {
        private string leaveState;
        private DateTime leaveTime;
        private string message;

        public string RealName { get; set; }
        public string LeaveState { get => leaveState; set => leaveState = value; }
        public DateTime LeaveTime { get => leaveTime; set => leaveTime = value; }
        public string Message { get => message; set => message = value; }
    }
}
